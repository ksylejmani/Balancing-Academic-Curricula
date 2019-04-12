using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACP_Solution
{
    public class Curriculum
    {
        public int noPeriods;
        public int minCredits, minCourses;
        public int maxCredits, maxCourses;
        public List<Course> courses;
        public Curriculum()
        {
            courses = new List<Course>();
        }
    }
}
