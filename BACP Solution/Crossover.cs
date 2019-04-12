using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACP_Solution
{
    class Crossover
    {
        public Individ GetChild2(Individ parentA,Curriculum c)
        {
            //step 1: construct list of period loads
            int[] tempPeriodList = new int[]{0,1,2,3,4,5,6,7};
            int[] tempPeriodListCredits = (int[])parentA.PeriodCreditLoad.Clone();
            for (int i = 0; i < tempPeriodListCredits.Length-1; i++)
            { 
                for(int j=i+1;j<tempPeriodListCredits.Length;j++)
                    if (tempPeriodListCredits[i] < tempPeriodListCredits[j])
                    {
                        int temp = tempPeriodListCredits[i];
                        tempPeriodListCredits[i] = tempPeriodListCredits[j];
                        tempPeriodListCredits[j] = temp;

                        temp = tempPeriodList[i];
                        tempPeriodList[i] = tempPeriodList[j];
                        tempPeriodList[j] = temp;
                    }
            }
            //start swaping by most and least loaded period
            int left = 0, right = tempPeriodList.Length - 1;
            List<int> candidatePeriod1 = parentA.Representation[tempPeriodList[left]];
            List<int> candidatePeriod2 = parentA.Representation[tempPeriodList[right]];

            for (int i = 0; i < candidatePeriod1.Count; i++)
            {
                //krahasimi me mesataren e period load
                if (parentA.PeriodCreditLoad[tempPeriodList[right]] > parentA.PeriodCreditLoad[tempPeriodList[left]])
                    break;

                int candidateCourse = candidatePeriod1[i];
                parentA.Representation[tempPeriodList[left]].Remove(candidateCourse);
                parentA.Representation[tempPeriodList[right]].Add(candidateCourse);
                if (!BasicFunctions.checkPrerequisites(parentA.Representation, c) || !BasicFunctions.checkMinMaxCourse(parentA.Representation, c.maxCourses, c.minCourses)
                    || !BasicFunctions.checkMinMaxCredit(parentA.PeriodCreditLoad, c.maxCredits, c.minCredits))
                {
                    parentA.Representation[tempPeriodList[right]].Remove(candidateCourse);
                    parentA.Representation[tempPeriodList[left]].Add(candidateCourse);
                }
                
                //update periodcreditload
                int s=0;
                for (int k = 0; k < parentA.Representation[tempPeriodList[right]].Count; k++)
                    s += c.courses[parentA.Representation[tempPeriodList[right]][k]-1].credit;
                parentA.PeriodCreditLoad[tempPeriodList[right]] = s;

                s = 0;
                for (int k = 0; k < parentA.Representation[tempPeriodList[left]].Count; k++)
                    s += c.courses[parentA.Representation[tempPeriodList[left]][k]-1].credit;
                parentA.PeriodCreditLoad[tempPeriodList[left]] = s;
            }

            return parentA;
        }
        public Individ GetChild(Individ parentA, Individ parentB)
        {
        //step1: select randomly course Ca from parent A
            int RandomPeriodIndex = BasicFunctions.randomGenerator.Next(0, parentA.Representation.Length );
            List<int> ParentAselectedPeriod = parentA.Representation[RandomPeriodIndex];
            int RandomCourseIndex = BasicFunctions.randomGenerator.Next(0, ParentAselectedPeriod.Count );
            int CourseID=ParentAselectedPeriod[RandomCourseIndex];
        //step 2:  remove course Ca  from parent B
            Individ TempChildA = RemoveCourse(parentB, CourseID);
            List<int> randomPeriodList = BasicFunctions.getRandomPeriodList(TempChildA.Representation.Length);
            return null;
        }
        public Individ RemoveCourse(Individ Ind, int CourseID)
        {
            for (int i = 0; i < Ind.Representation.Length ; i++)
            {

                 List<int> CurrentPeriod = Ind.Representation[i];
                 if (CurrentPeriod.Contains(CourseID))
                 {
                     CurrentPeriod.Remove(CourseID);
                     break;
                 }
             }
            return Ind;
        
        
        }
    }
}
