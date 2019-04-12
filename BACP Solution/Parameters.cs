using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACP_Solution
{
    class Parameters
    {
        public static int popSize = 100;
        public static int MaxGeneration = 50;
        public static int TournamentSelectionSize = (int)(popSize*0.1);
        public static int InitialSolutionRandomnessIntensity = 50;
        public static int SwapMutateIntensity = 5;
        public static int ShiftMutateIntensity = 1;
        public static double MutationAlternationFrequency = 0.01;
    }
}
