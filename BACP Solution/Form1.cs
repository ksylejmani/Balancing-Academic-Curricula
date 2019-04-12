using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BACP_Solution
{
    public partial class Form1 : Form
    {
        Curriculum objCurriculum = new Curriculum();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            GeneticAlgorithm ga = new GeneticAlgorithm();
            Individ BestSolution = ga.Apply(objCurriculum);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            EnableDisableFields(true);
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                txtPathFile.Text = openFileDialog.FileName;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPathFile.Text = "";
            EnableDisableFields(true);
            this.dgvData.Rows.Clear();
            this.dgvData.Refresh();
            this.txtMaxCourses.Clear();
            this.txtMaxCredits.Clear();
            this.txtMinCourses.Clear();
            this.txtMinCredits.Clear();
            this.txtNoPeriods.Clear();
        }

        private void EnableDisableFields(bool state)
        {
            txtMaxCourses.Enabled = state;
            txtMaxCredits.Enabled = state;
            txtMinCourses.Enabled = state;
            txtMinCredits.Enabled = state;
            txtNoPeriods.Enabled = state;
        }

        private void btnReadFromFile_Click(object sender, EventArgs e)
        {
            int NumberOfPeriods = (txtNoPeriods.Text.Length > 0 ? int.Parse(txtNoPeriods.Text) : 4),
               NumberOfMinimalCourses = (txtMinCourses.Text.Length > 0 ? int.Parse(txtMinCourses.Text) : 2),
               NumberOfMaximalCourses = (txtMaxCourses.Text.Length > 0 ? int.Parse(txtMaxCourses.Text) : 4),
               NumberOfMinimalCredits = (txtMinCredits.Text.Length > 0 ? int.Parse(txtMinCredits.Text) : 3),
               NumberOfMaximalCredits = (txtMaxCredits.Text.Length > 0 ? int.Parse(txtMaxCredits.Text) : 15);

            Data objData = new Data();
            dgvData.Rows.Clear();

            if (txtPathFile.Text.Trim().Length > 0)
            {
                //Fill dataset automatically from FILE
                objCurriculum = objData.GetDataFromFile(txtPathFile.Text);
                txtNoPeriods.Text = objCurriculum.noPeriods.ToString();
                NumberOfPeriods = objCurriculum.noPeriods;

                txtMinCredits.Text = objCurriculum.minCredits.ToString();
                NumberOfMinimalCredits = objCurriculum.minCredits;

                txtMaxCredits.Text = objCurriculum.maxCredits.ToString();
                NumberOfMaximalCredits = objCurriculum.maxCredits;

                txtMinCourses.Text = objCurriculum.minCourses.ToString();
                NumberOfMinimalCourses = objCurriculum.minCourses;

                txtMaxCourses.Text = objCurriculum.maxCourses.ToString();
                NumberOfMaximalCourses = objCurriculum.maxCourses;

                EnableDisableFields(false);
            }
            else
            {
                //Fill dataset manually
                EnableDisableFields(true);

                txtNoPeriods.Text = NumberOfPeriods.ToString();
                txtMaxCourses.Text = NumberOfMaximalCourses.ToString();
                txtMinCourses.Text = NumberOfMinimalCourses.ToString();
                txtMaxCredits.Text = NumberOfMaximalCredits.ToString();
                txtMinCredits.Text = NumberOfMinimalCredits.ToString();

                objCurriculum = objData.getData(NumberOfPeriods,
                                        NumberOfMinimalCredits,
                                        NumberOfMaximalCredits,
                                        NumberOfMinimalCourses,
                                        NumberOfMaximalCourses);
            }

            //All Courses read from File
            var Courses = new List<Course>();
            Courses = objCurriculum.courses;

            if (dgvData.Columns.Count == 0)
            {
                dgvData.Columns.Add("Id", "Id");
                dgvData.Columns.Add("Name", "Name");
                dgvData.Columns.Add("Prereq", "Prereq"); 
                dgvData.Columns.Add("Credit", "Credit"); 
                dgvData.Columns.Add("Description", "Description");
            }

            foreach (var course in Courses)
            {
                dgvData.Rows.Add(course.ID,
                course.name,
                course.RequiredCourses != null ? string.Join(", ", Courses.Where(a => course.RequiredCourses.Contains(a.ID)).Select(a => a.name)) : "", 
                course.credit,
                course.description);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
