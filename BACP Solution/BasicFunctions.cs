using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACP_Solution
{
    class BasicFunctions
    {
        public static Random randomGenerator;
        static BasicFunctions()
        {
            randomGenerator = new Random(DateTime.Now.Millisecond);
        }

        public static double AssessFitnessSquareDeviation(Individ _Individ)
        {
            double averagePeriodLoad = AveragePeriodLoad(_Individ.PeriodCreditLoad);
            double stDev = 0;

            for (int i = 0; i < _Individ.PeriodCreditLoad.Length; i++)
            {
                stDev += Math.Pow(_Individ.PeriodCreditLoad[i]-averagePeriodLoad,2);
            }

            return stDev;
        }

        public static int AssessFitnessMaximumLoad(Individ _Individ)
        {
            int MaxLoad = _Individ.PeriodCreditLoad[0];
            for (int i = 1; i < _Individ.PeriodCreditLoad.Length; i++)
            {
                if (MaxLoad < _Individ.PeriodCreditLoad[i])
                    MaxLoad = _Individ.PeriodCreditLoad[i];
            }

            return MaxLoad;
        }

        private static double AveragePeriodLoad(int[] _PeriodCreditLoad)
        {
            int s = 0;
            for (int i = 0; i < _PeriodCreditLoad.Length; i++)
            {
                s += _PeriodCreditLoad[i];
            }

            return (double)s / _PeriodCreditLoad.Length;
        }

        public static List<int> getPrerequringCourses(Curriculum _c, int CourseID)
        {
            List<int> result = new List<int>();
            foreach (Course c in _c.courses)
            {
                if (c.ID != CourseID && c.RequiredCourses != null)
                {
                    if (c.RequiredCourses.Contains(CourseID))
                        result.Add(c.ID);
                }
            }
            return result;
        }

        List<int> getPrerequiredCourses(List<Course> courses)
        {
            List<int> result = new List<int>();
            foreach (Course c in courses)
            {
                if (c.RequiredCourses != null)
                {
                    foreach (int i in c.RequiredCourses)
                    {
                        if (!result.Contains(i))
                            result.Add(i);
                    }
                }
            }
            return result;
        }

       public static  bool checkMinMaxCourse(List<int>[] individRepresentation, int maxCourses, int minCourses)
        {
            for (int i = 0; i < individRepresentation.Length; i++)
            {
                if (individRepresentation[i].Count > maxCourses || individRepresentation[i].Count < minCourses)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool checkMinMaxCredit(int[] PeriodCreditLoad, int maxCredits, int minCredits)
        {
            for (int i = 0; i < PeriodCreditLoad.Length; i++)
            {
                if (PeriodCreditLoad[i] > maxCredits || PeriodCreditLoad[i] < minCredits)
                {
                    return false;
                }
            }

            return true;
        }

      public static bool checkPrerequisites(List<int>[] individRepresentation, Curriculum _c)
        {
            List<int> prerequisiteCoursesPeriod;
            int coursePeriod;

            foreach (Course c in _c.courses)
            {
                if (c.RequiredCourses != null)
                {
                    coursePeriod = CoursePeriod(individRepresentation, c.ID);
                    prerequisiteCoursesPeriod = PrerequisitesPeriods(individRepresentation, c);
                    foreach (int i in prerequisiteCoursesPeriod)
                    {
                        if (i > coursePeriod)
                            return false;
                    }
                }
            }

            return true;
        }

        public static bool checkFitnessMaximumLoad(List<int>[] Representation, Curriculum _c, double Evaluation)
        {
            bool result = true;
            int maxLoad = int.MinValue;
            for (int i = 0; i < Representation.Length; i++)
            {
                List<int> CurrentPeriod = Representation[i];
                int CurrentPeriodLoad = 0;
                for (int j = 0; j < CurrentPeriod.Count; j++)
                {
                    int currentCourseID = CurrentPeriod[j];
                    CurrentPeriodLoad += _c.courses[currentCourseID - 1].credit;
                }

                if (CurrentPeriodLoad > maxLoad)
                    maxLoad = CurrentPeriodLoad;
            }
            if (maxLoad != Evaluation)
                result = false;
            else
                result = true;
            return result;
        }

        static int CoursePeriod(List<int>[] individRepresentation, int courseID)
        {
            for (int i = 0; i < individRepresentation.Length; i++)
            {
                if (individRepresentation[i].Contains(courseID))
                    return i;
            }

            return -1;
        }

        static List<int> PrerequisitesPeriods(List<int>[] individRepresentation, Course _c)
        {
            List<int> result = new List<int>();

            foreach (int c in _c.RequiredCourses)
            {
                result.Add(CoursePeriod(individRepresentation, c));
            }

            return result;
        }


        public static Individ GetBestParent(Individ[] population)
        {

            int[] SelectedIndivids = GetSelectedIndivids(population.Length);
             int BestIndividIndex =SelectedIndivids[0], CurrentIndivid;
            double BestIndividQuality = population[BestIndividIndex].Evaluation;
          
            for (int i = 1; i < SelectedIndivids.Length; i++)
            {
                CurrentIndivid = SelectedIndivids[i];
                if (population[CurrentIndivid].Evaluation < BestIndividQuality)
                {
                    BestIndividQuality = population[CurrentIndivid].Evaluation;
                    BestIndividIndex = CurrentIndivid;
                }
            }


                return population[BestIndividIndex];
        }
        
       static int [] GetSelectedIndivids(int popsize)
        {
            List<int> PopulationIndexes = new List<int>();
            for (int i = 0; i < popsize; i++)
            {
                PopulationIndexes.Add(i);

            }
            int[] SelectedIndivids = new int[Parameters.TournamentSelectionSize];
            for (int i = 0; i < SelectedIndivids.Length; i++)
            {
                int randomIndex = BasicFunctions.randomGenerator.Next(0, PopulationIndexes.Count);
                SelectedIndivids[i] = PopulationIndexes[randomIndex];
                PopulationIndexes.RemoveAt(randomIndex);
            }
            return SelectedIndivids;
        }
       List<int> getPeriodList(int NumberOfPeriods)
       {
           List<int> result = new List<int>();
           for (int i = 0; i < NumberOfPeriods; i++)
           {
               result.Add(i);
           }
           return result;
       }
       public static List<int> getRandomPeriodList(int NumberOfPeriods)
       {
           List<int> orderedList = new List<int>();
           for (int i = 0; i < NumberOfPeriods; i++)
           {
               orderedList.Add(i);
           }
           List<int> RandomList = new List<int>();
           int RandomIndex = 0;
           while(orderedList.Count>0)
           {
               RandomIndex=randomGenerator.Next(0, orderedList.Count);
               RandomList.Add(orderedList[RandomIndex]);
               orderedList.RemoveAt(RandomIndex);
           }
           return RandomList;
       }

       public static List<int> getCreditLoadSortedPeriodList(int [] PeriodCreditLoad)
       {
           List<int> result=new List<int>();
           for (int i = 0; i < PeriodCreditLoad.Length; i++)
           {
               result.Add(i);
           }

           for (int i = 0; i < result.Count-1; i++)
           {
               for (int j = i+1; j < result.Count; j++)
               {
                   if (PeriodCreditLoad[result[i]] < PeriodCreditLoad[result[j]])
                   {
                       int temp = result[i];
                       result[i] = result[j];
                       result[j] = temp;
                   }
               }
           }
           return result;
       }

       #region Fisi
       public static bool CheckCreditLoad(List<Course> _SortedCourses, int _Period, int _MinCredits, int _MaxCredits, int _AddCredits)
       {
           return (
                   _SortedCourses.Where(a => a.period == _Period).Sum(a => a.credit) < _MinCredits ||
                   (
                       (_SortedCourses.Where(a => a.period == _Period).Sum(a => a.credit) >= _MinCredits)
                       && ((_SortedCourses.Where(a => a.period == _Period).Sum(a => a.credit) + _AddCredits) <= _MaxCredits)
                   )
                  );
       }

       public static bool CheckCourseLoad(List<Course> _SortedCourses, int _Period, int _MinCourses, int _MaxCourses)
       {
           return (
                   _SortedCourses.Count(a => a.period == _Period) < _MinCourses ||
                   (
                       (_SortedCourses.Count(a => a.period == _Period) >= _MinCourses)
                       && (_SortedCourses.Count(a => a.period == _Period) + 1 <= _MaxCourses)
                   )
                  );
       }
       #endregion 

       public static List<int> getRandomCourseList(List<int> PeriodCourses)
       {
           List<int> orderedList = new List<int>();
           for (int i = 0; i < PeriodCourses.Count; i++)
           {
               orderedList.Add(i);
           }
           List<int> RandomList = new List<int>();
           int RandomIndex = 0;
           while(orderedList.Count>0)
           {
               RandomIndex = randomGenerator.Next(0, orderedList.Count);
               RandomList.Add(PeriodCourses[orderedList[RandomIndex]]);
               orderedList.RemoveAt(RandomIndex);
           }
           return RandomList;
       }
       public static String getSolutionDetails(Individ S)
       {
           String result;
           result="Solution quality is " + S.Evaluation+"\n";
           for (int i = 0; i < S.PeriodCreditLoad.Length; i++)
           {
               result=result+ "Period " + (i+1) + " with credit load "+S.PeriodCreditLoad[i]+" has the following courses : ";
               for (int j = 0; j < S.Representation[i].Count; j++)
               {
                   result=result+S.Representation[i][j] + " ";
               }
               result = result + "\n";
           }
           return result;
       }
    }


}
