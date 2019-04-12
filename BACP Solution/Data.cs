using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACP_Solution
{
    class Data
    {
        Curriculum objCurriculum = new Curriculum();

        public Curriculum getData(int p, int minCredits, int maxCredits, int minCourses, int maxCourses)
        {
            objCurriculum.noPeriods = p;
            objCurriculum.minCredits = minCredits;
            objCurriculum.maxCredits = maxCredits;
            objCurriculum.minCourses = minCourses;
            objCurriculum.maxCourses = maxCourses;

            objCurriculum.courses.Add(new Course(1, "dew100", 1, new List<int>()));
            objCurriculum.courses.Add(new Course(2, "fis100", 3, new List<int>()));
            objCurriculum.courses.Add(new Course(3, "hcw310", 1, new List<int>()));
            objCurriculum.courses.Add(new Course(4, "iwg101", 2, new List<int>()));
            objCurriculum.courses.Add(new Course(5, "mat190", 4, new List<int>()));
            objCurriculum.courses.Add(new Course(6, "mat192", 4, new List<int>()));
            objCurriculum.courses.Add(new Course(7, "dew101", 1, new List<int>() {1}));
            objCurriculum.courses.Add(new Course(8, "fis101", 5, new List<int>() {2}));
            objCurriculum.courses.Add(new Course(9, "iwi131", 3, new List<int>()));
            objCurriculum.courses.Add(new Course(10, "mat191", 4, new List<int>() {5}));

            this.setPrerequringCourses();
            return objCurriculum;
        }

        /// <summary>
        /// This method gets data from file
        /// </summary>
        /// <returns>object of type Curriculum</returns>
        public Curriculum GetDataFromFile(string filePath)
        {
            //Create a list of Params from File to organize easier parameters
            var listOfParams = new List<DataFileParameters>();

            var isArray = false;
            string nameOfArray = "";
            string valuesOfArray = "";

            //Read line per line the file
        foreach (var line in File.ReadAllLines(@filePath))
            {
                //Detect assigning values to variables and not start of the array
                if (line.IndexOf('=') != -1 && line.IndexOf('[') == -1 && line.IndexOf('{') == -1)
                {
                    DataFileParameters newParameter = new DataFileParameters();
                    newParameter.Name = line.Split('=')[0];
                    if (line.Split('=')[1].Replace(';', ' ').Trim().IndexOf(' ') != -1)
                    {
                        newParameter.Value = line.Split('=')[1].Replace(';', ' ').Trim().Split(' ')[0].Trim();
                    }
                    else
                    {
                        newParameter.Value = line.Split('=')[1].Replace(';', ' ').Trim();
                    }


                    listOfParams.Add(newParameter);
                }
                //Detect start of the arrays
                else if ((line.IndexOf('{') != -1 || line.IndexOf('[') != -1) && line.IndexOf('=') != -1)
                {
                    isArray = true;
                    nameOfArray = line.Split('=')[0].Trim();
                }
                //Detect the end of the array
                else if (line.IndexOf('}') != -1 || line.IndexOf(']') != -1)
                {
                    isArray = false;
                    DataFileParameters newParameter = new DataFileParameters();
                    newParameter.Name = nameOfArray;
                    newParameter.Value = valuesOfArray + (line.IndexOf('}') != -1 ? line.Split('}')[0].Replace(">,", "|").Trim() : line.Split(']')[0]);

                    listOfParams.Add(newParameter);
                    valuesOfArray = "";
                }
                //Insert members of arrays
                else if (isArray)
                {
                    valuesOfArray += line.Replace('<', ' ').Replace((line.IndexOf(">,") != -1 ? ">," : ">"), "|").Trim();
                }
            }

            objCurriculum.noPeriods = int.Parse(listOfParams.FirstOrDefault(a => a.Name == "p").Value);
            objCurriculum.minCredits = int.Parse(listOfParams.FirstOrDefault(a => a.Name == "a").Value);
            objCurriculum.maxCredits = int.Parse(listOfParams.FirstOrDefault(a => a.Name == "b").Value);
            objCurriculum.minCourses = int.Parse(listOfParams.FirstOrDefault(a => a.Name == "c").Value);
            objCurriculum.maxCourses = int.Parse(listOfParams.FirstOrDefault(a => a.Name == "d").Value);

            var courses = listOfParams.FirstOrDefault(a => a.Name == "courses").Value.Trim().Split(',').ToList();
            var credits = listOfParams.FirstOrDefault(a => a.Name == "credit").Value.Trim().Split(',').ToList();
            var prereq = listOfParams.FirstOrDefault(a => a.Name == "prereq").Value.Trim().Split('|').ToList();

            int i = 1;
            //Loop through all courses
            foreach (var c in courses)
            {
                //Get pre-courses list if there are any for this course (c)
                var preCourses = prereq.Where(a => a.Trim().Length > 0 && a.Split(',')[0].Trim() == c.Trim()).Select(a => a.Split(',')[1].Replace('|', ' ').Trim()).ToList();

                //If there are any prerequisits, go and find them
                if (preCourses.Count > 0)
                {
                    //Get positions of the courses on the list
                    List<int> positions = courses.Select((item, index) => new
                    {
                        ItemName = item.Trim(),
                        Position = (index + 1)
                    }).Where(a => preCourses.Contains(a.ItemName)).Select(a => a.Position).ToList();

                    //Add course with its information
                    objCurriculum.courses.Add(new Course(i, c.Trim(), int.Parse(credits[i - 1]), positions));
                }
                //There are no prereq for the course c, so just add course and its information
                else
                {
                    objCurriculum.courses.Add(new Course(i, c.Trim(), int.Parse(credits[i - 1]),new List<int>()));
                }
                i++;
            }

            this.setPrerequringCourses();
            return objCurriculum;
        }

        public void setPrerequringCourses()
        {
            foreach (Course c in objCurriculum.courses)
            {
                c.RequiringCourses = BasicFunctions.getPrerequringCourses(objCurriculum, c.ID);
            }
        }
    }
}
    