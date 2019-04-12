using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACP_Solution
{
    public class InitialIndividAH
    {
        List<Course> courses = new List<Course>();
        List<Course> coursesDependent = new List<Course>();        
        public Individ getRandomIndivid(Curriculum _c)
        {
            int t0 = DateTime.Now.Millisecond;
            courses = _c.courses;
            Individ individi = new Individ(_c.noPeriods);
            List<Course> periodCourses = new List<Course>();
            int noPeriods = 8;
            int minCredits = _c.minCredits, minCourses = _c.minCourses;
            int maxCredits = _c.maxCredits, maxCourses = _c.maxCourses;


            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].prereq != null && courses[i].prereq.Count>0)
                    coursesDependent.Add(courses[i]);
            }
            int al = 0;
            for (int k = 0; k < coursesDependent.Count; k++)
            {
                Vendos(coursesDependent[k].prereq,_c);
                int max = courses.FirstOrDefault(a => a.ID == coursesDependent[k].prereq[0]).period;// coursesDependent[k].prereq[0].period;
                for (int l = 1; l < coursesDependent[k].prereq.Count; l++)
                {
                    int temp = courses.FirstOrDefault(a => a.ID == coursesDependent[k].prereq[l]).period;
                    if (temp > max)
                        max = temp;
                }
                max++;
                int periodSumi = courses.Where(a => a.period == max).Sum(a => a.credit);
                while (periodSumi + coursesDependent[k].credit > _c.maxCredits ||
                    courses.Count(a => a.period == max) + 1 > _c.maxCourses)
                {
                    max++;
                    periodSumi = courses.Where(a => a.period == max).Sum(a => a.credit);
                }
                Random rand = new Random(DateTime.Now.Millisecond);
                max = rand.Next(max, max + 1);
                //max = (max > 8 ? max - (max % 8) : max);
                courses.FirstOrDefault(a => a.ID == coursesDependent[k].ID).period = max;
            }

            Random rnd;
            int _i;
            int periodSum;
            List<Course> inDependent = new List<Course>();
            for (int i = 0; i < courses.Count; i++)
                if (courses[i].period == -1)
                    inDependent.Add(courses[i]);
            for (int i = 1; i <= 8; i++)
            {
                while (courses.Count(a => a.period == i) < _c.minCourses)
                {
                    do
                    {
                        rnd = new Random(DateTime.Now.Millisecond);
                        _i = rnd.Next(0, inDependent.Count - 1);
                        periodSum = courses.Where(a => a.period == i).Sum(a => a.credit);
                    }
                    while (periodSum + courses[i].credit > _c.maxCredits || courses.Count(a => a.period == i) + 1 > _c.maxCourses);
                    courses.FirstOrDefault(a => a.ID == inDependent[_i].ID).period = i;
                    inDependent.RemoveAt(_i);
                }
            }

            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].period == -1)
                {
                    do
                    {
                        rnd = new Random(DateTime.Now.Millisecond);
                        _i = rnd.Next(6, 9);
                        periodSum = courses.Where(a => a.period == _i).Sum(a => a.credit);
                    }
                    while (periodSum + courses[i].credit > _c.maxCredits || courses.Count(a => a.period == _i) + 1 > _c.maxCourses);
                    courses[i].period = _i;
                }
            }

            int t1 = DateTime.Now.Millisecond;
            

            for (int i = 0; i < courses.Count; i++)
            {
                individi.Representation[courses[i].period-1].Add(courses[i].ID);
            }

            for (int p = 0; p < individi.Representation.Length; p++)
            {
                int sum = 0;
                for (int j = 0; j < individi.Representation[p].Count; j++)
                {
                    sum += courses.FirstOrDefault(a => a.ID == (individi.Representation[p])[j]).credit;
                }
                individi.PeriodCreditLoad[p] = sum;
            }

            return individi;
        }
        public void Vendos(List<int> pre, Curriculum _c)
        {
            if (pre.Count == 1)
            {
                Course c = courses.FirstOrDefault(a => a.ID == pre[0]);
                if (c.prereq != null && c.prereq.Count>0)
                    Vendos(c.prereq,_c);
                else
                //check where can be placed
                {
                    int perioda = 1;
                    for (int _i = 1; _i < 9; _i++)
                    {
                        int periodSum = courses.Where(a => a.period == _i).Sum(a => a.credit);
                        if (c.period == -1 && (periodSum + c.credit < _c.maxCredits && courses.Count(a => a.period == _i) + 1 < _c.maxCourses))
                        {
                            perioda = _i;
                            break;
                        }
                    }
                    if (c.period == -1)
                        c.period = perioda;
                }

            }
            else
                for (int _a = 0; _a < pre.Count; _a++)
                {
                    if (courses.FirstOrDefault(a => a.ID == pre[_a]).prereq.Count == 0)
                    {
                        //check where can be placed
                        int perioda = 1;
                        for (int _i = 1; _i < 9; _i++)
                        {
                            int periodSum = courses.Where(a => a.period == _i).Sum(a => a.credit);
                            if (courses.FirstOrDefault(a => a.ID == pre[_a]).period == -1 && (periodSum + courses.FirstOrDefault(a => a.ID == pre[_a]).credit < _c.maxCredits || courses.Count(a => a.period == _i) + 1 < _c.maxCourses))
                            //if (periodSum + courses.FirstOrDefault(a => a.ID == pre[_a]).credit < _c.maxCredits)
                            {
                                perioda = _i;
                                break;
                            }
                        }
                        if (courses.FirstOrDefault(a => a.ID == pre[_a]).period == -1)
                            courses.FirstOrDefault(a => a.ID == pre[_a]).period = perioda;
                    }
                    else
                        Vendos(courses.FirstOrDefault(a => a.ID == pre[_a]).prereq,_c);
                }

        }
    }
}
