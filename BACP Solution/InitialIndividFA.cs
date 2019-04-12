using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACP_Solution
{
    public class InitialIndividFA
    {
        public Individ getRandomIndivid(Curriculum _c)
        {
            //All Courses read from File
            var Courses = new List<Course>();
            Courses = _c.courses;

            //Util list to track Prereq and courses that has as a Prereq CandidateCourse
            var TempCourseList = new List<Course>();

            int t0 = DateTime.Now.Millisecond;
            #region 1. First set MoveDownIndex/MoveUpIndex to evaluate each course values for these indexes

            Courses.ForEach(a =>
            {
                if (Courses.Any(b => b.RequiredCourses != null && b.RequiredCourses.Contains(a.ID)))
                {
                    //Take courses which has this course(a) as prereq
                    TempCourseList = Courses.Where(b => b.RequiredCourses != null && b.RequiredCourses.Contains(a.ID)).ToList();

                    while (TempCourseList.Count > 0)
                    {
                        //Index that shows upper-limit of Period (NumberOfPeriods-MoveDownIndex)
                        a.MoveDownIndex++;

                        //Track courses as a prereq of other courses(in-depth search)
                        TempCourseList = Courses.Where(b => b.RequiredCourses != null && TempCourseList.Any(c => b.RequiredCourses.Contains(c.ID))).ToList();
                    }
                }

                //If this course has Prereq courses
                if (a.RequiredCourses != null && a.RequiredCourses.Count > 0)
                {
                    //Take prereq courses
                    TempCourseList = Courses.Where(b => a.RequiredCourses.Contains(b.ID)).ToList();

                    while (TempCourseList.Count > 0)
                    {
                        //Index that shows down-limit of Period (MoveUpIndex+1)
                        a.MoveUpIndex++;

                        //Take prereq of prereq courses(In-depth search)
                        TempCourseList = Courses.Where(b => TempCourseList.Any(c => c.RequiredCourses != null && c.RequiredCourses.Contains(b.ID))).ToList();
                    }
                }
            });

            #endregion

            #region Vars which we need

            int NumberOfPeriods = _c.noPeriods,
                NumberOfMinimalCourses = _c.minCourses,
                NumberOfMaximalCourses = _c.maxCourses,
                NumberOfMinimalCredits = _c.minCredits,
                NumberOfMaximalCredits = _c.maxCredits;
            Course CandidateCourse = null;
            int Period = 1;
            int randomIndex = 0; //Planning to put some crazy randomness

            #endregion

            //Util list to ensure the conditions about CourseLoad & CreditLoad are achieved
            var PeriodTracker = new List<PeriodTracker>();
            for (int i = 1; i <= NumberOfPeriods; i++)
            {
                PeriodTracker.Add(new PeriodTracker { Done = false, period = i });
            }
            //Split courses without any dependency in a list
            var FreeCourses = Courses.Where(a => a.MoveUpIndex == 0 && a.MoveDownIndex == 0).ToList();
            //Split courses with any dependency(prereqOf or hasPrereq) in a list
            var DependentCourses = Courses.Where(a => a.MoveDownIndex != 0 || a.MoveUpIndex != 0).ToList();
            var TempPeriodList = new List<PeriodTracker>();
            bool CourseLoad = false, CreditLoad = false;

            #region 2. Manage DependentCourses firstly

            while (DependentCourses.Count > 0)
            {
                //Courses without any prereq proceed first
                if (DependentCourses.Count(a => a.RequiredCourses == null) > 0)
                {
                    CandidateCourse = DependentCourses.FirstOrDefault(a => a.RequiredCourses == null);
                }
                else
                {
                    CandidateCourse = DependentCourses.Where(a => a.RequiredCourses != null).FirstOrDefault();
                }

                if (PeriodTracker.Any(a => !a.Done && a.period >= (CandidateCourse.MoveUpIndex + 1) && a.period <= (NumberOfPeriods - CandidateCourse.MoveDownIndex)))
                {
                    //For the sake of creditBalance and courseLoad we proceed with FirstOrDefault always
                    Period = PeriodTracker.FirstOrDefault(a => !a.Done && a.period >= (CandidateCourse.MoveUpIndex + 1) && a.period <= (NumberOfPeriods - CandidateCourse.MoveDownIndex)).period;
                }
                else
                {
                    //Put some randomness here
                    Period = BasicFunctions.randomGenerator.Next(CandidateCourse.MoveUpIndex + 1, NumberOfPeriods - CandidateCourse.MoveDownIndex + 1);
                }

                CourseLoad = BasicFunctions.CheckCourseLoad(Courses, Period, NumberOfMinimalCourses, NumberOfMaximalCourses);
                CreditLoad = BasicFunctions.CheckCreditLoad(Courses, Period, NumberOfMinimalCredits, NumberOfMaximalCredits, CandidateCourse.credit);
                //Check to see if constraints aboud CourseLoad and CreditLoad are met
                if (CourseLoad && CreditLoad)
                {
                    //Update Period of this course in the full Courses list
                    Courses.FirstOrDefault(a => a.ID == CandidateCourse.ID).period = Period;

                    PeriodTracker.FirstOrDefault(a => a.period == Period).Done = ((Courses.Count(a => a.period == Period) >= NumberOfMinimalCourses)
                                                                               && (Courses.Where(a => a.period == Period).Sum(a => a.credit) >= NumberOfMinimalCredits));

                    //Look at the courses that have this CandidateCourse as a Prereq and update their MoveUpIndex to this Period value
                    //because the down-limit of their Period Value must be greater than this CandidateCourse's Period value
                    //Note! The update must occur only if MoveUpIndex is less then CandidateCourse's Period value
                    Courses.Where(a => a.RequiredCourses != null && a.RequiredCourses.Contains(CandidateCourse.ID) && a.MoveUpIndex < Period)
                            .ToList()
                            .ForEach(a =>
                            {
                                a.MoveUpIndex = Period;
                            });

                    //Remove CandidateCourse from this list, so we can reduce this list until the last member
                    DependentCourses.Remove(CandidateCourse);
                }
            }

            #endregion

            #region 3. Manage FreeCourses

            //Now we deal with Free Courses which have no dependencies
            while (FreeCourses.Count > 0)
            {
                randomIndex = BasicFunctions.randomGenerator.Next(0, FreeCourses.Count);
                CandidateCourse = FreeCourses[randomIndex];

                if (PeriodTracker.Any(a => !a.Done && a.period >= (CandidateCourse.MoveUpIndex + 1) && a.period <= (NumberOfPeriods - CandidateCourse.MoveDownIndex)))
                {
                    //Again, randomness
                    TempPeriodList = PeriodTracker.Where(a => !a.Done && a.period >= (CandidateCourse.MoveUpIndex + 1) && a.period <= (NumberOfPeriods - CandidateCourse.MoveDownIndex)).ToList();

                    Period = TempPeriodList.ElementAt(BasicFunctions.randomGenerator.Next(TempPeriodList.Count)).period;
                }
                else
                {
                    //Randomn...ess here too
                    Period = BasicFunctions.randomGenerator.Next(CandidateCourse.MoveUpIndex + 1, NumberOfPeriods - CandidateCourse.MoveDownIndex);
                }

                CourseLoad = BasicFunctions.CheckCourseLoad(Courses, Period, NumberOfMinimalCourses, NumberOfMaximalCourses);
                CreditLoad = BasicFunctions.CheckCreditLoad(Courses, Period, NumberOfMinimalCredits, NumberOfMaximalCredits, CandidateCourse.credit);
                if (CourseLoad && CreditLoad)
                {
                    Courses.FirstOrDefault(a => a.ID == CandidateCourse.ID).period = Period;

                    PeriodTracker.FirstOrDefault(a => a.period == Period).Done = ((Courses.Count(a => a.period == Period) >= NumberOfMinimalCourses)
                                                                               && (Courses.Where(a => a.period == Period).Sum(a => a.credit) >= NumberOfMinimalCredits));

                    FreeCourses.Remove(CandidateCourse);
                }

            }

            #endregion

            Individ individi = new Individ(NumberOfPeriods);
            for (int i = 0; i < Courses.Count; i++)
            {
                individi.Representation[Courses[i].period - 1].Add(Courses[i].ID);
            }

            for (int p = 0; p < individi.Representation.Length; p++)
            {
                int sum = 0;
                for (int j = 0; j < individi.Representation[p].Count; j++)
                {
                    sum += Courses.FirstOrDefault(a => a.ID == (individi.Representation[p])[j]).credit;
                }
                individi.PeriodCreditLoad[p] = sum;
            }

            return individi;
        }
    }
}
