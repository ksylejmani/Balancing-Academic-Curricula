using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACP_Solution
{
    public class InitialIndivid
    {
        public Individ getRandomIndivid(Curriculum _c)
        {
            Individ RandomIndivid = new Individ(_c.noPeriods);
            
            // Step 1: Consider Prerequisits and MinMaxCourses constraints
            int[] InitialNoCoursePerPeriod = this.getInitialNoCoursePerPeriod(_c.courses.Count, _c.noPeriods);
            int CourseID,PeriodStartIndex=0;
            for (int CourseIndex = 0; CourseIndex < _c.courses.Count; CourseIndex++)
            {
                CourseID = _c.courses[CourseIndex].ID;
                List<int> RequiredCourses = _c.courses[CourseIndex].RequiredCourses;
                for (int PeriodIndex = PeriodStartIndex; PeriodIndex < _c.noPeriods; PeriodIndex++)
                {
                    if (RandomIndivid.Representation[PeriodIndex].Count < InitialNoCoursePerPeriod[PeriodIndex])
                    {
                        if (
                            RandomIndivid.PeriodCreditLoad[PeriodIndex] + _c.courses[CourseIndex].credit <=_c.maxCredits &&
                            ! ContainsGroup(RandomIndivid.Representation[PeriodIndex], RequiredCourses)
                            )
                        {
                            RandomIndivid.Representation[PeriodIndex].Add(CourseID);
                            RandomIndivid.PeriodCreditLoad[PeriodIndex] += _c.courses[CourseIndex].credit;
                            break;
                        }
                    }
                    else
                        PeriodStartIndex++;
                }
            }
                    
            //Step 2 :Incorporate randomness
            int PeriodA, PeriodB;
            for (int RanInensityIndex = 0; RanInensityIndex < Parameters.InitialSolutionRandomnessIntensity; 
                RanInensityIndex++)
            {
                PeriodA = BasicFunctions.randomGenerator.Next(0, _c.noPeriods);
                PeriodB = this.getRandomPeriod(PeriodA, _c.noPeriods);
                RandomIndivid=this.SwapCourses(PeriodA, PeriodB, _c, RandomIndivid);
            }

            //Step 3 :Consider MinMaxCredits constraint
            Boolean MinMaxCreditsConstraintFulfilled = false;
            while (!MinMaxCreditsConstraintFulfilled)
            {
                int PeriodCount = 0, RandomPeriod;
                for (int CurrentPeriod = 0; CurrentPeriod < _c.noPeriods; CurrentPeriod++)
                {
                    if (RandomIndivid.PeriodCreditLoad[CurrentPeriod] > _c.maxCredits
                        || RandomIndivid.PeriodCreditLoad[CurrentPeriod] < _c.minCredits)
                    {
                        RandomPeriod = this.getRandomPeriod(CurrentPeriod, _c.noPeriods);
                        RandomIndivid=this.SwapCourses(CurrentPeriod, RandomPeriod, _c, RandomIndivid);
                        break;
                    }
                    PeriodCount++;
                }
                if (PeriodCount == _c.noPeriods)
                    MinMaxCreditsConstraintFulfilled = true;
            }

            RandomIndivid.Evaluation = BasicFunctions.AssessFitnessMaximumLoad(RandomIndivid);

            Boolean preReq = BasicFunctions.checkPrerequisites(RandomIndivid.Representation, _c);
            Boolean ChecMinMaxCredits = BasicFunctions.checkMinMaxCredit(RandomIndivid.PeriodCreditLoad, _c.maxCredits, _c.minCredits);
            Boolean ChecMinMaxCourses = BasicFunctions.checkMinMaxCourse(RandomIndivid.Representation, _c.maxCourses, _c.minCourses);
            Boolean CheckEvaluation = BasicFunctions.checkFitnessMaximumLoad(RandomIndivid.Representation, _c, RandomIndivid.Evaluation);

            return RandomIndivid;
        }

        int[] getInitialNoCoursePerPeriod(int NoCourses, int NoPeriods)
        {
            int [] result=new int[NoPeriods];
            int AboveAverageNoCoursesPerPeriod = (int)(Math.Ceiling((double)NoCourses / NoPeriods));
            int BelowAverageNoCoursesPerPeriod = (int)(Math.Floor((double)NoCourses / NoPeriods));
            double AboveAveragePercentage = (double)NoCourses / NoPeriods-NoCourses / NoPeriods;
            int AboveAverageMembers = (int)(AboveAveragePercentage * NoPeriods);
            for (int PeriodIndex = 0; PeriodIndex < AboveAverageMembers; PeriodIndex++)
            {
                result[PeriodIndex] = AboveAverageNoCoursesPerPeriod;
            }
            for (int PeriodIndex = AboveAverageMembers; PeriodIndex < NoPeriods; PeriodIndex++)
            {
                result[PeriodIndex] = BelowAverageNoCoursesPerPeriod;
            }
            return result;
        }

       

        bool ContainsGroup(List<int> currentList, List<int> OtherList)
        {
            foreach (int cp in OtherList)
            {
                if (currentList.Contains(cp))
                    return true;
            }
            return false;
        }

        public int getRandomPeriod(int CurrentPeriod, int NumberOfPeriods)
        {
            int result = -1;
            List<int> PossiblePeriods = new List<int>();
            for (int i = 0; i < NumberOfPeriods; i++)
            {
                if (i != CurrentPeriod)
                    PossiblePeriods.Add(i);
            }
            int RandomIndex = BasicFunctions.randomGenerator.Next(0, PossiblePeriods.Count);
            result = PossiblePeriods[RandomIndex];
            return result;
        }
        public Individ SwapCourses(int CurrentPeriod, int MinMaxCreditLoadPeriod,
            Curriculum _c, Individ _individ)
        {
            Individ ResultingIndivid = (Individ)_individ.Clone();
            int LeftPeriodIndex, RightPeriodIndex;
            List<int> LeftPeriodSwapCandidates, RightPeriodSwapCandidates;
            if (CurrentPeriod < MinMaxCreditLoadPeriod)
            {
                LeftPeriodIndex = CurrentPeriod;
                RightPeriodIndex = MinMaxCreditLoadPeriod;
            }
            else
            {
                LeftPeriodIndex = MinMaxCreditLoadPeriod;
                RightPeriodIndex = CurrentPeriod;
            }
            LeftPeriodSwapCandidates =
                this.getLeftPeriodSwapCandidates(_c, ResultingIndivid.Representation,
                                                LeftPeriodIndex, RightPeriodIndex);
            RightPeriodSwapCandidates =
                this.getRightPeriodSwapCandidates(_c, ResultingIndivid.Representation,
                                                LeftPeriodIndex, RightPeriodIndex);
            if (LeftPeriodSwapCandidates.Count > 0 && RightPeriodSwapCandidates.Count > 0)
            {
                List<int> RandomLeftList = BasicFunctions.getRandomCourseList(LeftPeriodSwapCandidates);
                List<int> RandomRightList = BasicFunctions.getRandomCourseList(RightPeriodSwapCandidates);
                for (int IL=0;IL< RandomLeftList.Count; IL++)
                {
                    int LeftListCourseID = RandomLeftList[IL];
                    for (int IR=0;IR< RandomRightList.Count;IR++)
                    {
                        int RightListCourseID = RandomRightList[IR];

                        int LeftPeriodForeseenCreditLoad= ResultingIndivid.PeriodCreditLoad[LeftPeriodIndex] +
                            _c.courses[RightListCourseID - 1].credit - _c.courses[LeftListCourseID - 1].credit;
                        int RightPeriodForeseenCreditLoad = ResultingIndivid.PeriodCreditLoad[RightPeriodIndex] +
                            _c.courses[LeftListCourseID - 1].credit - _c.courses[RightListCourseID - 1].credit;

                        bool LeftPeriodCreditLoadFeasible = LeftPeriodForeseenCreditLoad >= _c.minCredits && LeftPeriodForeseenCreditLoad<=_c.maxCredits;
                        bool RightPeriodCreditLoadFeasible = RightPeriodForeseenCreditLoad >= _c.minCredits && RightPeriodForeseenCreditLoad <= _c.maxCredits;
                        if (LeftPeriodCreditLoadFeasible && RightPeriodCreditLoadFeasible)
                        {
                            ResultingIndivid.Representation[LeftPeriodIndex].Remove(LeftListCourseID);
                            ResultingIndivid.Representation[LeftPeriodIndex].Add(RightListCourseID);
                            ResultingIndivid.Representation[RightPeriodIndex].Remove(RightListCourseID);
                            ResultingIndivid.Representation[RightPeriodIndex].Add(LeftListCourseID);

                            ResultingIndivid.PeriodCreditLoad[LeftPeriodIndex] +=
                                (_c.courses[RightListCourseID - 1].credit -
                                 _c.courses[LeftListCourseID - 1].credit);

                            ResultingIndivid.PeriodCreditLoad[RightPeriodIndex] +=
                                (_c.courses[LeftListCourseID - 1].credit -
                                 _c.courses[RightListCourseID - 1].credit);
                            goto ReturnIndivid;
                        }
                    }
                }              
           }

            ReturnIndivid:
            ResultingIndivid.Evaluation = BasicFunctions.AssessFitnessMaximumLoad(ResultingIndivid);
            return ResultingIndivid;
        }
        List<int> getLeftPeriodSwapCandidates(
            Curriculum _c, List<int>[] Representation,
            int LeftPeriodIndex, int RightPeriodIndex)
        {
            List<int> result = new List<int>();
            foreach (int CourseID in Representation[LeftPeriodIndex])
            {
                List<int> RequiringCourses = _c.courses[CourseID - 1].RequiringCourses;
                bool CurrenCourseCanBeSwaped = true;
                foreach (int cp in RequiringCourses)
                {
                    for (int NextPeriod = LeftPeriodIndex + 1; NextPeriod <= RightPeriodIndex; NextPeriod++)
                    {
                        List<int> nextList = Representation[NextPeriod];
                        if (nextList.Contains(cp))
                        {
                            CurrenCourseCanBeSwaped = false;
                            goto TryNextCourse;
                        }
                    }
                }
            TryNextCourse:
                if (CurrenCourseCanBeSwaped)
                    result.Add(CourseID);
            }
            return result;
        }

        List<int> getRightPeriodSwapCandidates(
            Curriculum _c, List<int>[] Representation,
            int LeftPeriodIndex, int RightPeriodIndex)
        {
            List<int> result = new List<int>();
            foreach (int CourseID in Representation[RightPeriodIndex])
            {
                bool CurrenCourseCanBeSwaped = true;
                if (_c.courses[CourseID - 1].RequiredCourses != null)
                {
                    List<int> RequiredCourses = _c.courses[CourseID - 1].RequiredCourses;
                    foreach (int cp in RequiredCourses)
                    {
                        for (int PreviousPeriod = RightPeriodIndex - 1; PreviousPeriod >= LeftPeriodIndex; PreviousPeriod--)
                        {
                            List<int> previoiusList = Representation[PreviousPeriod];
                            if (previoiusList.Contains(cp))
                            {
                                CurrenCourseCanBeSwaped = false;
                                goto TryNextCourse;
                            }
                        }
                    }
                }
            TryNextCourse:
                if (CurrenCourseCanBeSwaped)
                    result.Add(CourseID);
            }
            return result;
        }


        
    }
}
