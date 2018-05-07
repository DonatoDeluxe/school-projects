namespace Uebeung_3_1
{
    partial class CourseManagerForm
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
            this.comboBoxDepartments = new System.Windows.Forms.ComboBox();
            this.listBoxCourses = new System.Windows.Forms.ListBox();
            this.departmentsLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxAllCourses = new System.Windows.Forms.ListBox();
            this.allCoursesLabel = new System.Windows.Forms.Label();
            this.buttonAddCourse = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxDepartments
            // 
            this.comboBoxDepartments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBoxDepartments.FormattingEnabled = true;
            this.comboBoxDepartments.Location = new System.Drawing.Point(12, 65);
            this.comboBoxDepartments.Name = "comboBoxDepartments";
            this.comboBoxDepartments.Size = new System.Drawing.Size(219, 33);
            this.comboBoxDepartments.TabIndex = 0;
            this.comboBoxDepartments.SelectedIndexChanged += new System.EventHandler(this.comboBoxDepartments_SelectedIndexChanged);
            // 
            // listBoxCourses
            // 
            this.listBoxCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.listBoxCourses.FormattingEnabled = true;
            this.listBoxCourses.ItemHeight = 22;
            this.listBoxCourses.Location = new System.Drawing.Point(12, 104);
            this.listBoxCourses.Name = "listBoxCourses";
            this.listBoxCourses.Size = new System.Drawing.Size(219, 356);
            this.listBoxCourses.TabIndex = 1;
            // 
            // departmentsLabel
            // 
            this.departmentsLabel.AutoSize = true;
            this.departmentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.departmentsLabel.Location = new System.Drawing.Point(12, 38);
            this.departmentsLabel.Name = "departmentsLabel";
            this.departmentsLabel.Size = new System.Drawing.Size(116, 24);
            this.departmentsLabel.TabIndex = 2;
            this.departmentsLabel.Text = "Departments";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(868, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // listBoxAllCourses
            // 
            this.listBoxAllCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.listBoxAllCourses.FormattingEnabled = true;
            this.listBoxAllCourses.ItemHeight = 22;
            this.listBoxAllCourses.Location = new System.Drawing.Point(318, 104);
            this.listBoxAllCourses.Name = "listBoxAllCourses";
            this.listBoxAllCourses.Size = new System.Drawing.Size(219, 356);
            this.listBoxAllCourses.TabIndex = 4;
            // 
            // allCoursesLabel
            // 
            this.allCoursesLabel.AutoSize = true;
            this.allCoursesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.allCoursesLabel.Location = new System.Drawing.Point(318, 77);
            this.allCoursesLabel.Name = "allCoursesLabel";
            this.allCoursesLabel.Size = new System.Drawing.Size(106, 24);
            this.allCoursesLabel.TabIndex = 5;
            this.allCoursesLabel.Text = "All Courses";
            // 
            // buttonAddCourse
            // 
            this.buttonAddCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddCourse.Location = new System.Drawing.Point(237, 254);
            this.buttonAddCourse.Name = "buttonAddCourse";
            this.buttonAddCourse.Size = new System.Drawing.Size(75, 42);
            this.buttonAddCourse.TabIndex = 6;
            this.buttonAddCourse.Text = "<--";
            this.buttonAddCourse.UseVisualStyleBackColor = true;
            this.buttonAddCourse.Click += new System.EventHandler(this.buttonAddCourse_Click);
            // 
            // CourseManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 469);
            this.Controls.Add(this.buttonAddCourse);
            this.Controls.Add(this.allCoursesLabel);
            this.Controls.Add(this.listBoxAllCourses);
            this.Controls.Add(this.departmentsLabel);
            this.Controls.Add(this.listBoxCourses);
            this.Controls.Add(this.comboBoxDepartments);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CourseManagerForm";
            this.Text = "Course Manager";
            this.Load += new System.EventHandler(this.CourseManagerForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDepartments;
        private System.Windows.Forms.ListBox listBoxCourses;
        private System.Windows.Forms.Label departmentsLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxAllCourses;
        private System.Windows.Forms.Label allCoursesLabel;
        private System.Windows.Forms.Button buttonAddCourse;
    }
}

