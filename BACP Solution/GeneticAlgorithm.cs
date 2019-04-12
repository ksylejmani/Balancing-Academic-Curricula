using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BACP_Solution
{
    public class GeneticAlgorithm:InitialIndivid

    {
        Crossover objCross = new Crossover();
        SwapMutate objSwapMutate = new SwapMutate();
        ShiftMutate objShiftMutate = new ShiftMutate();
        InitialIndividAH iah = new InitialIndividAH();
        InitialIndividFA ifa = new InitialIndividFA();
        bool SwapMutationOn = true;
        public Individ Apply(Curriculum objCurriculum)
        {
            Individ Best=new Individ(objCurriculum.noPeriods);
            Individ[] P = Enumerable.Repeat(
                new Individ(objCurriculum.noPeriods), Parameters.popSize).ToArray();
            Individ[] Q = Enumerable.Repeat(
               new Individ(objCurriculum.noPeriods), Parameters.popSize).ToArray();
            for (int i = 0; i < Parameters.popSize; i++)
            {
                Individ currentIndivid = getRandomIndivid(objCurriculum);
                //Individ currentIndivid = iah.getRandomIndivid(objCurriculum);
                //Individ currentIndivid = ifa.getRandomIndivid(objCurriculum);

                Boolean preReq = BasicFunctions.checkPrerequisites(currentIndivid.Representation, objCurriculum);
                Boolean ChecMinMaxCredits = BasicFunctions.checkMinMaxCredit(currentIndivid.PeriodCreditLoad, objCurriculum.maxCredits, objCurriculum.minCredits);
                Boolean ChecMinMaxCourses = BasicFunctions.checkMinMaxCourse(currentIndivid.Representation, objCurriculum.maxCourses, objCurriculum.minCourses);
                Boolean CheckEvaluation = BasicFunctions.checkFitnessMaximumLoad(currentIndivid.Representation, objCurriculum, currentIndivid.Evaluation);
                P[i] = (Individ)currentIndivid.Clone();
            }

            Best = (Individ)P[0].Clone();

            int CurrentGeneration=1;
            do
            {
                for (int i = 0; i < Parameters.popSize; i++)
                {

                    Boolean preReq = BasicFunctions.checkPrerequisites(P[i].Representation, objCurriculum);
                    Boolean ChecMinMaxCredits = BasicFunctions.checkMinMaxCredit(P[i].PeriodCreditLoad, objCurriculum.maxCredits, objCurriculum.minCredits);
                    Boolean ChecMinMaxCourses = BasicFunctions.checkMinMaxCourse(P[i].Representation, objCurriculum.maxCourses, objCurriculum.minCourses);
                    Boolean CheckEvaluation = BasicFunctions.checkFitnessMaximumLoad(P[i].Representation, objCurriculum, P[i].Evaluation);

                    if (P[i].Evaluation < Best.Evaluation)
                    {
                        Best = (Individ)P[i].Clone(); ;
                        Console.WriteLine("Current generation: " + CurrentGeneration);
                        Console.WriteLine(BasicFunctions.getSolutionDetails(Best));                       
                    }
                }
                for (int i = 0; i < Parameters.popSize ; i += 2)
                {
                    Individ ParentA = BasicFunctions.GetBestParent(P);                   
                    Individ ParentB = BasicFunctions.GetBestParent(P);

                    Individ childA, childB;
                    if (SwapMutationOn)
                    {
                        childA = objSwapMutate.GetChild(ParentA, objCurriculum);
                        childB = objSwapMutate.GetChild(ParentB, objCurriculum);
                    }
                    else
                    {
                        Boolean preReq = BasicFunctions.checkPrerequisites(ParentA.Representation, objCurriculum);
                        Boolean ChecMinMaxCredits = BasicFunctions.checkMinMaxCredit(ParentA.PeriodCreditLoad, objCurriculum.maxCredits, objCurriculum.minCredits);
                        Boolean ChecMinMaxCourses = BasicFunctions.checkMinMaxCourse(ParentA.Representation, objCurriculum.maxCourses, objCurriculum.minCourses);
                        Boolean CheckEvaluation = BasicFunctions.checkFitnessMaximumLoad(ParentA.Representation, objCurriculum, ParentA.Evaluation);

                        childA = objShiftMutate.GetChild(ParentA, objCurriculum);

                        Boolean preReq2 = BasicFunctions.checkPrerequisites(childA.Representation, objCurriculum);
                        Boolean ChecMinMaxCredits2 = BasicFunctions.checkMinMaxCredit(childA.PeriodCreditLoad, objCurriculum.maxCredits, objCurriculum.minCredits);
                        Boolean ChecMinMaxCourses2 = BasicFunctions.checkMinMaxCourse(childA.Representation, objCurriculum.maxCourses, objCurriculum.minCourses);
                        Boolean CheckEvaluation2 = BasicFunctions.checkFitnessMaximumLoad(childA.Representation, objCurriculum, childA.Evaluation);

                        Boolean preReq3 = BasicFunctions.checkPrerequisites(ParentB.Representation, objCurriculum);
                        Boolean ChecMinMaxCredits3 = BasicFunctions.checkMinMaxCredit(ParentB.PeriodCreditLoad, objCurriculum.maxCredits, objCurriculum.minCredits);
                        Boolean ChecMinMaxCourses3 = BasicFunctions.checkMinMaxCourse(ParentB.Representation, objCurriculum.maxCourses, objCurriculum.minCourses);
                        Boolean CheckEvaluation3 = BasicFunctions.checkFitnessMaximumLoad(ParentB.Representation, objCurriculum, ParentB.Evaluation);

                        childB = objShiftMutate.GetChild(ParentB, objCurriculum);

                        Boolean preReq4 = BasicFunctions.checkPrerequisites(childB.Representation, objCurriculum);
                        Boolean ChecMinMaxCredits4 = BasicFunctions.checkMinMaxCredit(childB.PeriodCreditLoad, objCurriculum.maxCredits, objCurriculum.minCredits);
                        Boolean ChecMinMaxCourses4 = BasicFunctions.checkMinMaxCourse(childB.Representation, objCurriculum.maxCourses, objCurriculum.minCourses);
                        Boolean CheckEvaluation4 = BasicFunctions.checkFitnessMaximumLoad(childB.Representation, objCurriculum, childB.Evaluation);


                    }


                    Q[i] = (Individ)childA.Clone();
                    Q[i + 1] = (Individ)childB.Clone();                    

                }

                P = (Individ[])Q.Clone();
                
                CurrentGeneration++;
                if (CurrentGeneration % (Parameters.MutationAlternationFrequency * Parameters.MaxGeneration) == 0)
                {
                    SwapMutationOn = !SwapMutationOn;
                }
            }
            while (CurrentGeneration <= Parameters.MaxGeneration);

            MessageBox.Show("Best solution details:\n" + BasicFunctions.getSolutionDetails(Best));

            return Best;           
            }
      }
}
