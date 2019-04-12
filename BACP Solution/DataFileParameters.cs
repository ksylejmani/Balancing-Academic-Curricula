using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACP_Solution
{
    class DataFileParameters
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    class PeriodTracker
    {
        public int period { get; set; }
        public bool Done { get; set; }
    }
}
