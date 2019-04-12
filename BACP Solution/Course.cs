using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACP_Solution
{
    public class Course
    {
        public int ID;
        public string name;
        public int credit;
        public List<int> RequiredCourses;
        public List<int> RequiringCourses;
        public string description;
        public int period;
        public List<int> prereq;

        #region Fisi
        public int MoveDownIndex;
        public int MoveUpIndex;
        #endregion
        public Course(int _id, string _name, int _credit, List<int> _prereq)
        {
            ID = _id;
            name = _name;
            credit = _credit;
            RequiredCourses = _prereq;
            prereq = _prereq;
            period = -1;
        }
    }
}
