using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACP_Solution
{
    public class Individ
    {
        public List<int> [] Representation;
        public int[] PeriodCreditLoad;
        public double Evaluation;
        public Individ(int _NumberOfPeriods)
        {
            Representation = new List<int>[_NumberOfPeriods];
            for (int i = 0; i < _NumberOfPeriods; i++)
            {
                Representation[i] = new List<int>();
            }
            PeriodCreditLoad = new int[_NumberOfPeriods];
            Evaluation = -1;
        }

        public Individ Clone()
        {
            Individ ClonedIndivid = new Individ(PeriodCreditLoad.Length);
            for (int i = 0; i < this.Representation.Length; i++)
            {
                ClonedIndivid.Representation[i].AddRange(this.Representation[i]);
            }
            Array.Copy(this.PeriodCreditLoad, ClonedIndivid.PeriodCreditLoad, this.PeriodCreditLoad.Length);
            ClonedIndivid.Evaluation = this.Evaluation;
            return ClonedIndivid;
        }
    }
}
