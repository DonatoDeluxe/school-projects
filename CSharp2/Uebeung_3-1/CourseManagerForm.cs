using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uebeung_3_1.Model;

namespace Uebeung_3_1
{
    public partial class CourseManagerForm : Form
    {
        BindingList<Department> _departments;
        BindingList<Course> _courses;

        public CourseManagerForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CourseManagerForm_Load(object sender, EventArgs e)
        {
            ReadDepartments();
            ReadCourses();
        }

        private void ReadDepartments()
        {
            using (SchoolEntities context = new SchoolEntities())
            {
                _departments = new BindingList<Department>(context.Departments.ToList());
                comboBoxDepartments.DataSource = null;
                comboBoxDepartments.DataSource = _departments;
                comboBoxDepartments.DisplayMember = "Name";
            }
        }

        private void ReadCourses()
        {
            using (SchoolEntities context = new SchoolEntities())
            {
                _courses = new BindingList<Course>(context.Courses.ToList());
                listBoxAllCourses.DataSource = null;
                listBoxAllCourses.DataSource = _courses;
                listBoxAllCourses.DisplayMember = "Title";
            }
        }

        private void comboBoxDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDepartments.SelectedIndex >= 0)
            {
                Department selectedDepartment = comboBoxDepartments.SelectedItem as Department;

                using (SchoolEntities context = new SchoolEntities())
                {
                    var departmentCourses = context.Courses.Where(c => c.DepartmentID == selectedDepartment.DepartmentID).ToList();

                    listBoxCourses.DataSource = null;
                    listBoxCourses.DataSource = departmentCourses;
                    listBoxCourses.DisplayMember = "Title";
                }
            }
        }

        private void buttonAddCourse_Click(object sender, EventArgs e)
        {
            if (comboBoxDepartments.SelectedIndex >= 0 && listBoxAllCourses.SelectedIndex >= 0)
            {
                Department selectedDepartment = comboBoxDepartments.SelectedItem as Department;
                Course selectedCourse = listBoxAllCourses.SelectedItem as Course;

                using (SchoolEntities context = new SchoolEntities())
                {
                    var course = context.Courses.FirstOrDefault(
                            c => c.CourseID == selectedCourse.CourseID
                        );
                    var department = context.Departments.FirstOrDefault(
                            d => d.DepartmentID == selectedDepartment.DepartmentID
                        );

                    course.Department = department;
                    context.SaveChanges();
                }
            }
        }
    }
}
