using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACP_Solution
{
    class SwapMutate : InitialIndivid
    {
        public Individ GetChild(Individ _parent,Curriculum _c)
        {
            Individ ResultingChild = (Individ)_parent.Clone();
            int PeriodA, PeriodB;
            for (int RanInensityIndex = 0; RanInensityIndex < Parameters.SwapMutateIntensity;
                RanInensityIndex++)
            {
                PeriodA = BasicFunctions.randomGenerator.Next(0, _c.noPeriods);
                PeriodB = this.getRandomPeriod(PeriodA, _c.noPeriods);

                Boolean preReq = BasicFunctions.checkPrerequisites(_parent.Representation, _c);
                Boolean ChecMinMaxCredits = BasicFunctions.checkMinMaxCredit(_parent.PeriodCreditLoad, _c.maxCredits, _c.minCredits);
                Boolean ChecMinMaxCourses = BasicFunctions.checkMinMaxCourse(_parent.Representation, _c.maxCourses, _c.minCourses);
                Boolean CheckEvaluation = BasicFunctions.checkFitnessMaximumLoad(_parent.Representation, _c, _parent.Evaluation);
                //Console.WriteLine(BasicFunctions.getSolutionDetails(_parent));

                ResultingChild =this.SwapCourses(PeriodA, PeriodB, _c, _parent);

                //Console.WriteLine(BasicFunctions.getSolutionDetails(ResultingChild));
                Boolean preReq2 = BasicFunctions.checkPrerequisites(ResultingChild.Representation, _c);
                Boolean ChecMinMaxCredits2 = BasicFunctions.checkMinMaxCredit(ResultingChild.PeriodCreditLoad, _c.maxCredits, _c.minCredits);
                Boolean ChecMinMaxCourses2 = BasicFunctions.checkMinMaxCourse(ResultingChild.Representation, _c.maxCourses, _c.minCourses);
                Boolean CheckEvaluation2 = BasicFunctions.checkFitnessMaximumLoad(ResultingChild.Representation, _c, ResultingChild.Evaluation);
            }




            return ResultingChild;
         }
        
    }
}
