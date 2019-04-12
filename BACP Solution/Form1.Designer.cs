namespace BACP_Solution
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblMaxCourses = new System.Windows.Forms.Label();
            this.lblMinCourses = new System.Windows.Forms.Label();
            this.txtMaxCourses = new System.Windows.Forms.TextBox();
            this.txtMinCourses = new System.Windows.Forms.TextBox();
            this.txtMaxCredits = new System.Windows.Forms.TextBox();
            this.lblMaxCredits = new System.Windows.Forms.Label();
            this.txtMinCredits = new System.Windows.Forms.TextBox();
            this.lblMinCredits = new System.Windows.Forms.Label();
            this.txtNoPeriods = new System.Windows.Forms.TextBox();
            this.lblP = new System.Windows.Forms.Label();
            this.btnReadFromFile = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPathFile = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPopSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxGen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTournamentSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRandomnessIntensity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSwapMutateIntensity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtShiftMutateIntensity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMutationAlternationFrequency = new System.Windows.Forms.TextBox();
            this.btnExecuteAlg = new System.Windows.Forms.Button();
            this.gbExperimetDetails = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNumberOfInstances = new System.Windows.Forms.TextBox();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbInstanceSet = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtExecutions = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbExperimetDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(441, 6);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(62, 22);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(261, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 29;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblMaxCourses
            // 
            this.lblMaxCourses.AutoSize = true;
            this.lblMaxCourses.Location = new System.Drawing.Point(344, 63);
            this.lblMaxCourses.Name = "lblMaxCourses";
            this.lblMaxCourses.Size = new System.Drawing.Size(94, 13);
            this.lblMaxCourses.TabIndex = 28;
            this.lblMaxCourses.Text = "Max. courses (d) =";
            // 
            // lblMinCourses
            // 
            this.lblMinCourses.AutoSize = true;
            this.lblMinCourses.Location = new System.Drawing.Point(344, 37);
            this.lblMinCourses.Name = "lblMinCourses";
            this.lblMinCourses.Size = new System.Drawing.Size(91, 13);
            this.lblMinCourses.TabIndex = 27;
            this.lblMinCourses.Text = "Min. courses (c) =";
            // 
            // txtMaxCourses
            // 
            this.txtMaxCourses.Location = new System.Drawing.Point(441, 60);
            this.txtMaxCourses.Name = "txtMaxCourses";
            this.txtMaxCourses.Size = new System.Drawing.Size(62, 20);
            this.txtMaxCourses.TabIndex = 26;
            // 
            // txtMinCourses
            // 
            this.txtMinCourses.Location = new System.Drawing.Point(441, 34);
            this.txtMinCourses.Name = "txtMinCourses";
            this.txtMinCourses.Size = new System.Drawing.Size(62, 20);
            this.txtMinCourses.TabIndex = 25;
            // 
            // txtMaxCredits
            // 
            this.txtMaxCredits.Location = new System.Drawing.Point(276, 60);
            this.txtMaxCredits.Name = "txtMaxCredits";
            this.txtMaxCredits.Size = new System.Drawing.Size(62, 20);
            this.txtMaxCredits.TabIndex = 24;
            // 
            // lblMaxCredits
            // 
            this.lblMaxCredits.AutoSize = true;
            this.lblMaxCredits.Location = new System.Drawing.Point(186, 63);
            this.lblMaxCredits.Name = "lblMaxCredits";
            this.lblMaxCredits.Size = new System.Drawing.Size(88, 13);
            this.lblMaxCredits.TabIndex = 23;
            this.lblMaxCredits.Text = "Max. credits (b) =";
            // 
            // txtMinCredits
            // 
            this.txtMinCredits.Location = new System.Drawing.Point(276, 34);
            this.txtMinCredits.Name = "txtMinCredits";
            this.txtMinCredits.Size = new System.Drawing.Size(62, 20);
            this.txtMinCredits.TabIndex = 22;
            // 
            // lblMinCredits
            // 
            this.lblMinCredits.AutoSize = true;
            this.lblMinCredits.Location = new System.Drawing.Point(186, 37);
            this.lblMinCredits.Name = "lblMinCredits";
            this.lblMinCredits.Size = new System.Drawing.Size(85, 13);
            this.lblMinCredits.TabIndex = 21;
            this.lblMinCredits.Text = "Min. credits (a) =";
            // 
            // txtNoPeriods
            // 
            this.txtNoPeriods.Location = new System.Drawing.Point(92, 34);
            this.txtNoPeriods.Name = "txtNoPeriods";
            this.txtNoPeriods.Size = new System.Drawing.Size(85, 20);
            this.txtNoPeriods.TabIndex = 20;
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.Location = new System.Drawing.Point(10, 37);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(76, 13);
            this.lblP.TabIndex = 19;
            this.lblP.Text = "No. of periods:";
            // 
            // btnReadFromFile
            // 
            this.btnReadFromFile.Location = new System.Drawing.Point(339, 6);
            this.btnReadFromFile.Name = "btnReadFromFile";
            this.btnReadFromFile.Size = new System.Drawing.Size(93, 23);
            this.btnReadFromFile.TabIndex = 18;
            this.btnReadFromFile.Text = "Read from file";
            this.btnReadFromFile.UseVisualStyleBackColor = true;
            this.btnReadFromFile.Click += new System.EventHandler(this.btnReadFromFile_Click);
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 86);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(530, 358);
            this.dgvData.TabIndex = 17;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(183, 6);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 16;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPathFile
            // 
            this.txtPathFile.Location = new System.Drawing.Point(12, 8);
            this.txtPathFile.Name = "txtPathFile";
            this.txtPathFile.ReadOnly = true;
            this.txtPathFile.Size = new System.Drawing.Size(165, 20);
            this.txtPathFile.TabIndex = 15;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbExperimetDetails);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtMutationAlternationFrequency);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtShiftMutateIntensity);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSwapMutateIntensity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtRandomnessIntensity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTournamentSize);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaxGen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPopSize);
            this.groupBox1.Location = new System.Drawing.Point(559, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 438);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Experiments";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtPopSize
            // 
            this.txtPopSize.Location = new System.Drawing.Point(190, 31);
            this.txtPopSize.Name = "txtPopSize";
            this.txtPopSize.Size = new System.Drawing.Size(108, 20);
            this.txtPopSize.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Popullation size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Maximum generations:";
            // 
            // txtMaxGen
            // 
            this.txtMaxGen.Location = new System.Drawing.Point(190, 56);
            this.txtMaxGen.Name = "txtMaxGen";
            this.txtMaxGen.Size = new System.Drawing.Size(108, 20);
            this.txtMaxGen.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tournament size:";
            // 
            // txtTournamentSize
            // 
            this.txtTournamentSize.Location = new System.Drawing.Point(190, 85);
            this.txtTournamentSize.Name = "txtTournamentSize";
            this.txtTournamentSize.Size = new System.Drawing.Size(108, 20);
            this.txtTournamentSize.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Randomnes intensity:";
            // 
            // txtRandomnessIntensity
            // 
            this.txtRandomnessIntensity.Location = new System.Drawing.Point(190, 115);
            this.txtRandomnessIntensity.Name = "txtRandomnessIntensity";
            this.txtRandomnessIntensity.Size = new System.Drawing.Size(108, 20);
            this.txtRandomnessIntensity.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "SwapMutateIntensity:";
            // 
            // txtSwapMutateIntensity
            // 
            this.txtSwapMutateIntensity.Location = new System.Drawing.Point(190, 145);
            this.txtSwapMutateIntensity.Name = "txtSwapMutateIntensity";
            this.txtSwapMutateIntensity.Size = new System.Drawing.Size(108, 20);
            this.txtSwapMutateIntensity.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "ShiftMutateIntensity:";
            // 
            // txtShiftMutateIntensity
            // 
            this.txtShiftMutateIntensity.Location = new System.Drawing.Point(190, 174);
            this.txtShiftMutateIntensity.Name = "txtShiftMutateIntensity";
            this.txtShiftMutateIntensity.Size = new System.Drawing.Size(108, 20);
            this.txtShiftMutateIntensity.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "MutationAlternationFrequency:";
            // 
            // txtMutationAlternationFrequency
            // 
            this.txtMutationAlternationFrequency.Location = new System.Drawing.Point(190, 202);
            this.txtMutationAlternationFrequency.Name = "txtMutationAlternationFrequency";
            this.txtMutationAlternationFrequency.Size = new System.Drawing.Size(108, 20);
            this.txtMutationAlternationFrequency.TabIndex = 12;
            // 
            // btnExecuteAlg
            // 
            this.btnExecuteAlg.Location = new System.Drawing.Point(80, 128);
            this.btnExecuteAlg.Margin = new System.Windows.Forms.Padding(2);
            this.btnExecuteAlg.Name = "btnExecuteAlg";
            this.btnExecuteAlg.Size = new System.Drawing.Size(150, 31);
            this.btnExecuteAlg.TabIndex = 26;
            this.btnExecuteAlg.Text = "Execute algorithm";
            this.btnExecuteAlg.UseVisualStyleBackColor = true;
            // 
            // gbExperimetDetails
            // 
            this.gbExperimetDetails.Controls.Add(this.btnExecuteAlg);
            this.gbExperimetDetails.Controls.Add(this.label11);
            this.gbExperimetDetails.Controls.Add(this.txtNumberOfInstances);
            this.gbExperimetDetails.Controls.Add(this.cmbMethod);
            this.gbExperimetDetails.Controls.Add(this.label10);
            this.gbExperimetDetails.Controls.Add(this.cmbInstanceSet);
            this.gbExperimetDetails.Controls.Add(this.label9);
            this.gbExperimetDetails.Controls.Add(this.label8);
            this.gbExperimetDetails.Controls.Add(this.txtExecutions);
            this.gbExperimetDetails.Location = new System.Drawing.Point(18, 252);
            this.gbExperimetDetails.Name = "gbExperimetDetails";
            this.gbExperimetDetails.Size = new System.Drawing.Size(292, 168);
            this.gbExperimetDetails.TabIndex = 25;
            this.gbExperimetDetails.TabStop = false;
            this.gbExperimetDetails.Text = "Experiment details";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 105);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Number of instances:";
            // 
            // txtNumberOfInstances
            // 
            this.txtNumberOfInstances.Location = new System.Drawing.Point(139, 101);
            this.txtNumberOfInstances.Name = "txtNumberOfInstances";
            this.txtNumberOfInstances.Size = new System.Drawing.Size(121, 20);
            this.txtNumberOfInstances.TabIndex = 17;
            this.txtNumberOfInstances.Text = "3";
            // 
            // cmbMethod
            // 
            this.cmbMethod.FormattingEnabled = true;
            this.cmbMethod.Items.AddRange(new object[] {
            "Generational",
            "Elitism",
            "Steady state",
            "Tree style"});
            this.cmbMethod.Location = new System.Drawing.Point(139, 14);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(121, 21);
            this.cmbMethod.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(77, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Method:";
            // 
            // cmbInstanceSet
            // 
            this.cmbInstanceSet.FormattingEnabled = true;
            this.cmbInstanceSet.Items.AddRange(new object[] {
            "Set A",
            "Set B",
            "Set C"});
            this.cmbInstanceSet.Location = new System.Drawing.Point(139, 73);
            this.cmbInstanceSet.Name = "cmbInstanceSet";
            this.cmbInstanceSet.Size = new System.Drawing.Size(121, 21);
            this.cmbInstanceSet.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(65, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Instance set:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Number of executions:";
            // 
            // txtExecutions
            // 
            this.txtExecutions.Location = new System.Drawing.Point(139, 44);
            this.txtExecutions.Name = "txtExecutions";
            this.txtExecutions.Size = new System.Drawing.Size(121, 20);
            this.txtExecutions.TabIndex = 10;
            this.txtExecutions.Text = "10";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 465);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblMaxCourses);
            this.Controls.Add(this.lblMinCourses);
            this.Controls.Add(this.txtMaxCourses);
            this.Controls.Add(this.txtMinCourses);
            this.Controls.Add(this.txtMaxCredits);
            this.Controls.Add(this.lblMaxCredits);
            this.Controls.Add(this.txtMinCredits);
            this.Controls.Add(this.lblMinCredits);
            this.Controls.Add(this.txtNoPeriods);
            this.Controls.Add(this.lblP);
            this.Controls.Add(this.btnReadFromFile);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtPathFile);
            this.Controls.Add(this.btnRun);
            this.Name = "Form1";
            this.Text = "BACP problem";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbExperimetDetails.ResumeLayout(false);
            this.gbExperimetDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblMaxCourses;
        private System.Windows.Forms.Label lblMinCourses;
        private System.Windows.Forms.TextBox txtMaxCourses;
        private System.Windows.Forms.TextBox txtMinCourses;
        private System.Windows.Forms.TextBox txtMaxCredits;
        private System.Windows.Forms.Label lblMaxCredits;
        private System.Windows.Forms.TextBox txtMinCredits;
        private System.Windows.Forms.Label lblMinCredits;
        private System.Windows.Forms.TextBox txtNoPeriods;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.Button btnReadFromFile;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtPathFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPopSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaxGen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTournamentSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRandomnessIntensity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSwapMutateIntensity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMutationAlternationFrequency;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtShiftMutateIntensity;
        private System.Windows.Forms.GroupBox gbExperimetDetails;
        private System.Windows.Forms.Button btnExecuteAlg;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNumberOfInstances;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbInstanceSet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtExecutions;
    }
}

