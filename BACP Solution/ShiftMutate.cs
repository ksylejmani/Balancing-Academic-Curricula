using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACP_Solution
{
    class ShiftMutate
    {
        public Individ GetChild(Individ _parent, Curriculum _c)
        {
            Individ ResultingChild = (Individ)_parent.Clone();
            for (int RanInensityIndex = 0; RanInensityIndex < Parameters.ShiftMutateIntensity;
               RanInensityIndex++)
            {
                //Boolean preReq4 = BasicFunctions.checkPrerequisites(ResultingChild.Representation, _c);
                int[] ShiftingSolution = this.getShiftingSolution(_c, ResultingChild);
                int OriginePeriod = ShiftingSolution[0];
                int CourseID = ShiftingSolution[1];
                int DestinationPeriod = ShiftingSolution[2];
                if (CourseID != 0)
                {
                    ResultingChild.Representation[OriginePeriod].Remove(CourseID);
                    ResultingChild.Representation[DestinationPeriod].Add(CourseID);

                    ResultingChild.PeriodCreditLoad[OriginePeriod] -= _c.courses[CourseID - 1].credit;
                    ResultingChild.PeriodCreditLoad[DestinationPeriod] += _c.courses[CourseID - 1].credit;
                    ResultingChild.Evaluation = BasicFunctions.AssessFitnessMaximumLoad(ResultingChild);
                   //Boolean preReq5 = BasicFunctions.checkPrerequisites(ResultingChild.Representation, _c);
                }
            }
            return ResultingChild;
        }

        private int[] getShiftCandidateOrigine(Individ _parent, Curriculum _c)
        {
            int[] shiftCandidate = new int[2];
            List<int> periodList = BasicFunctions.getRandomPeriodList(_c.noPeriods);
            //List<int> periodList = BasicFunctions.getCreditLoadSortedPeriodList(parentA.PeriodCreditLoad);
            int candidatePeriod = -1;
            int candidateCourse = -1;
            while (periodList.Count > 0)
            {
                //Console.WriteLine("periodList.Count: " + periodList.Count);
                candidatePeriod = periodList[0];
                int candidatePeriodCourseLoad = _parent.Representation[candidatePeriod].Count;
                
                if (candidatePeriodCourseLoad - 1 >= _c.minCourses)
                {
                    int candidatePeriodCreditLoad = _parent.PeriodCreditLoad[candidatePeriod];
                    //choosing randomly a course from this period, check minPeriodCreditLoad
                    List<int> RandomListOfCourses = BasicFunctions.getRandomCourseList(_parent.Representation[candidatePeriod]);
                    int CourseIndex;
                    for (CourseIndex = 0; CourseIndex < RandomListOfCourses.Count; CourseIndex++)
                    {
                        int tempCourseCredit = _c.courses.FirstOrDefault(a => a.ID == RandomListOfCourses[CourseIndex]).credit;
                        if ((candidatePeriodCreditLoad - tempCourseCredit) >= _c.minCredits)
                        {
                            candidateCourse = _c.courses.FirstOrDefault(a => a.ID == RandomListOfCourses[CourseIndex]).ID;
                            return new int[] { candidatePeriod, candidateCourse };
                        }
                    }
                    if( CourseIndex==RandomListOfCourses.Count)
                        periodList.RemoveAt(0);
                }
                else
                {
                    periodList.RemoveAt(0);
                }
            }

            return new int[]{-1,-1};
        }

        private int[] getShiftingSolution(Curriculum _c, Individ _individ)
        {
            int[] ResultingShiftingSolution = new int[3];
            int[] ShiftCandidate=new int[2];
            int candidateOriginePeriod, candidateOrigineCourseID;
            List<int> ShiftingPeriodCandidates;
            ShiftCandidate = this.getShiftCandidateOrigine(_individ, _c);
            candidateOriginePeriod = ShiftCandidate[0];
            candidateOrigineCourseID = ShiftCandidate[1];
            Course candidateCourse = _c.courses[candidateOrigineCourseID-1];
            ShiftingPeriodCandidates = this.getShiftingPeriodCandidates(_c, _individ.Representation, _individ.PeriodCreditLoad,
                candidateOriginePeriod, candidateCourse);
            //Console.WriteLine("ShiftingPeriodCandidates.Count" + ShiftingPeriodCandidates.Count);

            if (ShiftingPeriodCandidates.Count != 0)
            {
                int RandomListIndex = BasicFunctions.randomGenerator.Next(0, ShiftingPeriodCandidates.Count - 1);
                ResultingShiftingSolution[0] = candidateOriginePeriod;
                ResultingShiftingSolution[1] = candidateOrigineCourseID;
                ResultingShiftingSolution[2] = ShiftingPeriodCandidates[RandomListIndex];
            }
            return ResultingShiftingSolution;
        }

        private List<int> getShiftingPeriodCandidates(
           Curriculum _c, List<int>[] Representation, int[] PeriodCreditLoad,
           int _currentPeriod, Course _candidateCourse)
        {
            List<int> LeftPeriodList = new List<int>();
            List<int> RightPeriodList = new List<int>();
            List<int> resultingPeriodList = new List<int>();
            List<int> RequiringCourses = _c.courses[_candidateCourse.ID - 1].RequiringCourses;
            List<int> RequiredCourses = _c.courses[_candidateCourse.ID - 1].RequiredCourses;
            for (int PeriodIndex = 0; PeriodIndex < Representation.Length; PeriodIndex++)
            {
                if (PeriodIndex != _currentPeriod)
                {
                    List<int> PeriodCourseList = Representation[PeriodIndex];

                    //Check max courses and Check max credits
                    if ((Representation[PeriodIndex].Count + 1 > _c.maxCourses) ||
                        (PeriodCreditLoad[PeriodIndex] + _candidateCourse.credit > _c.maxCredits))
                    {
                        bool ItNeededToContinueWithRemainingPeriods = true;
                        foreach (int cp in RequiringCourses)
                        {
                            if (PeriodCourseList.Contains(cp))
                            {
                                ItNeededToContinueWithRemainingPeriods = false;
                                break;
                            }
                        }

                        foreach (int cp in RequiredCourses)
                        {
                            if (PeriodCourseList.Contains(cp))
                            {
                                LeftPeriodList.Clear();
                                ItNeededToContinueWithRemainingPeriods = true;
                                break;
                            }
                        }

                        if (ItNeededToContinueWithRemainingPeriods)
                            continue;
                        else
                            break;
                    }

                    //Check prerequisites
                    bool CurrenPeriodCanBeUsedForShifting = true;
                    if (PeriodIndex < _currentPeriod)
                    {

                        foreach (int cp in RequiredCourses)
                        {
                            if (PeriodCourseList.Contains(cp))
                            {
                                LeftPeriodList.Clear();
                                CurrenPeriodCanBeUsedForShifting = false;
                                break;
                            }
                        }
                        if (CurrenPeriodCanBeUsedForShifting)
                            LeftPeriodList.Add(PeriodIndex);
                        else
                            continue;
                    }
                    else
                    {                   
                        foreach (int cp in RequiringCourses)
                        {
                            if (PeriodCourseList.Contains(cp))
                            {
                                CurrenPeriodCanBeUsedForShifting = false;
                                break;
                            }
                        }
                        if (CurrenPeriodCanBeUsedForShifting)
                            RightPeriodList.Add(PeriodIndex);
                        else
                            break;
                    }

                }
            }
            resultingPeriodList.AddRange(LeftPeriodList);
            resultingPeriodList.AddRange(RightPeriodList);
            return resultingPeriodList;
        }

    }
}
