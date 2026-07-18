using IntegratedUniversityInformationSystem.Helpers;
using IntegratedUniversityInformationSystem.Models;
using IntegratedUniversityInformationSystem.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegratedUniversityInformationSystem.Forms
{
    // form for managing student records
    public partial class StudentManagementForm : Form
    {
        // repositories for data access
        private readonly StudentRepository _studentRepo;
        private readonly CourseRepository _courseRepo;

        // holds all students and the currently displayed/filtered list
        private List<Student> _students;
        private List<Student> _displayedList;

        // columns available for sorting
        private readonly string[] _sortColumns = new string[]
        {
            "ID",
            "StudentNumber",
            "FirstName",
            "LastName",
            "Gender",
            "Course",
            "YearLevel",
            "Section"
        };

        public StudentManagementForm()
        {
            InitializeComponent();

            // fix DataGridView text color (debug code for setting color -> black)
            dgvStudents.ForeColor = Color.Black;
            dgvStudents.DefaultCellStyle.ForeColor = Color.Black;
            dgvStudents.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
            dgvStudents.RowHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            // initialize repositories
            _studentRepo = new StudentRepository();
            _courseRepo = new CourseRepository();

            // load sort dropdowns
            SortHelper.LoadSortColumns(cmbSortColumn, _sortColumns);
            SortHelper.LoadSortOrders(cmbSortOrder);

            // load initial data
            LoadStudents();
            LoadCourses();
        }

        // loads all students from JSON
        private void LoadStudents()
        {
            try
            {
                _students = _studentRepo.GetAll();
                _displayedList = _students;
                DisplayStudents(_displayedList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // displays the given student list in DataGridView
        private void DisplayStudents(List<Student> list)
        {
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = list.Select(s => new
            {
                s.Id,
                s.StudentNumber,
                s.FirstName,
                s.LastName,
                s.MiddleName,
                s.BirthDate,
                s.Gender,
                s.ContactNumber,
                s.Email,
                s.Address,
                Course = GetCourseName(s.CourseId),
                s.YearLevel,
                s.Section,
                s.IsActive
            }).ToList();

            UpdateSummary();
        }

        // updates the summary box with student counts per year level
        private void UpdateSummary()
        {
            var list = _displayedList ?? _students ?? new List<Student>();

            int year1 = list.Count(s => s.YearLevel == 1);
            int year2 = list.Count(s => s.YearLevel == 2);
            int year3 = list.Count(s => s.YearLevel == 3);
            int year4 = list.Count(s => s.YearLevel == 4);
            int year5 = list.Count(s => s.YearLevel == 5);
            int total = list.Count;

            lblYear1Summary.Text = year1.ToString("N0");
            lblYear2Summary.Text = year2.ToString("N0");
            lblYear3Summary.Text = year3.ToString("N0");
            lblYear4Summary.Text = year4.ToString("N0");
            lblYear5Summary.Text = year5.ToString("N0");
            lblTotalStudentsSummary.Text = total.ToString("N0");
        }

        // applies sorting on the current list
        private void ApplySort()
        {
            if (_students == null) return;

            string sortColumn = cmbSortColumn.Text;
            string sortOrder = cmbSortOrder.Text;

            _displayedList = SortHelper.SortList(
                _students,
                sortColumn,
                sortOrder,
                dgvStudents,
                null
            );

            DisplayStudents(_displayedList);
        }

        // gets course name by ID
        private string GetCourseName(int courseId)
        {
            var course = _courseRepo.GetById(c => c.Id == courseId);
            return course != null ? course.Name : "N/A";
        }

        // loads active courses into dropdown
        private void LoadCourses()
        {
            try
            {
                var courses = _courseRepo.GetAll().Where(c => c.IsActive).ToList();
                cmbCourse.DataSource = courses;
                cmbCourse.DisplayMember = "Name";
                cmbCourse.ValueMember = "Id";
                cmbCourse.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // clears all input fields
        private void ClearFields()
        {
            txtID.Clear();
            txtStudentNumber.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtMiddleName.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtSection.Clear();
            dtpBirthDate.Value = DateTime.Now.AddYears(-18);
            cmbGender.SelectedIndex = -1;
            cmbCourse.SelectedIndex = -1;
            cmbYearLevel.SelectedIndex = -1;
            txtID.Focus();
        }

        // loads selected student data into input fields
        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                var selectedRow = dgvStudents.SelectedRows[0];
                var student = _studentRepo.GetById(s => s.Id == (int)selectedRow.Cells["Id"].Value);
                if (student != null)
                {
                    txtID.Text = student.Id.ToString();
                    txtStudentNumber.Text = student.StudentNumber;
                    txtFirstName.Text = student.FirstName;
                    txtLastName.Text = student.LastName;
                    txtMiddleName.Text = student.MiddleName;
                    dtpBirthDate.Value = student.BirthDate;
                    cmbGender.Text = student.Gender;
                    txtContact.Text = student.ContactNumber;
                    txtEmail.Text = student.Email;
                    txtAddress.Text = student.Address;
                    cmbCourse.SelectedValue = student.CourseId;
                    cmbYearLevel.Text = student.YearLevel.ToString();
                    txtSection.Text = student.Section;
                }
            }
        }

        // triggers search when user types in search box
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchStudents();
        }

        // filters students by keyword (student number, name, email)
        private void SearchStudents()
        {
            try
            {
                string keyword = txtSearch.Text.ToLower();

                var filtered = _students.Where(s =>
                    s.StudentNumber.ToLower().Contains(keyword) ||
                    s.FirstName.ToLower().Contains(keyword) ||
                    s.LastName.ToLower().Contains(keyword) ||
                    s.Email.ToLower().Contains(keyword)
                ).ToList();

                _displayedList = filtered;

                // re-apply sort after search
                string sortColumn = cmbSortColumn.Text;
                string sortOrder = cmbSortOrder.Text;

                _displayedList = SortHelper.SortList(
                    _displayedList,
                    sortColumn,
                    sortOrder,
                    dgvStudents,
                    null
                );

                DisplayStudents(_displayedList);
            }
            catch (Exception)
            {
                // ignore
            }
        }

        // adds new student
        private void lblAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    MessageBox.Show("Please enter First Name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFirstName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    MessageBox.Show("Please enter Last Name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLastName.Focus();
                    return;
                }

                if (cmbCourse.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Course.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCourse.Focus();
                    return;
                }

                if (cmbYearLevel.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Year Level.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbYearLevel.Focus();
                    return;
                }

                // Check duplicate Student Number
                if (_studentRepo.GetById(s => s.StudentNumber == txtStudentNumber.Text) != null)
                {
                    MessageBox.Show("Student Number already exists.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtStudentNumber.Focus();
                    return;
                }

                // create new student object
                var student = new Student
                {
                    Id = _students.Count > 0 ? _students.Max(s => s.Id) + 1 : 1,
                    StudentNumber = txtStudentNumber.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    MiddleName = txtMiddleName.Text,
                    BirthDate = dtpBirthDate.Value,
                    Gender = cmbGender.Text,
                    ContactNumber = txtContact.Text,
                    Email = txtEmail.Text,
                    Address = txtAddress.Text,
                    CourseId = (int)cmbCourse.SelectedValue,
                    YearLevel = int.Parse(cmbYearLevel.Text),
                    Section = txtSection.Text,
                    EnrollmentDate = DateTime.Now,
                    IsActive = true
                };

                // save to JSON and refresh
                _studentRepo.Add(student);
                LoadStudents();
                ClearFields();
                MessageBox.Show("Student added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding student: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // updates selected student
        private void lblUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a student to update.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var student = _studentRepo.GetById(s => s.Id == id);
                if (student == null)
                {
                    MessageBox.Show("Student not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validation
                if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    MessageBox.Show("Please enter First Name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFirstName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    MessageBox.Show("Please enter Last Name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLastName.Focus();
                    return;
                }

                if (cmbCourse.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Course.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCourse.Focus();
                    return;
                }

                if (cmbYearLevel.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Year Level.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbYearLevel.Focus();
                    return;
                }

                student.FirstName = txtFirstName.Text;
                student.LastName = txtLastName.Text;
                student.MiddleName = txtMiddleName.Text;
                student.BirthDate = dtpBirthDate.Value;
                student.Gender = cmbGender.Text;
                student.ContactNumber = txtContact.Text;
                student.Email = txtEmail.Text;
                student.Address = txtAddress.Text;
                student.CourseId = (int)cmbCourse.SelectedValue;
                student.YearLevel = int.Parse(cmbYearLevel.Text);
                student.Section = txtSection.Text;

                _studentRepo.Update(s => s.Id == id, student);
                LoadStudents();
                ClearFields();
                MessageBox.Show("Student updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating student: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // soft delete - marks student as inactive
        private void lblDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a student to delete.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var student = _studentRepo.GetById(s => s.Id == id);
                if (student == null)
                {
                    MessageBox.Show("Student not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to delete this student?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Soft delete - set inactive
                    student.IsActive = false;
                    _studentRepo.Update(s => s.Id == id, student);
                    LoadStudents();
                    ClearFields();
                    MessageBox.Show("Student deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting student: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // clears input fields
        private void lblClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // refreshes data and resets filters
        private void pbRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbSortColumn.SelectedIndex = 0;
            cmbSortOrder.SelectedIndex = 0;
            LoadStudents();
            ClearFields();
        }

        // triggers sort when sort column changes
        private void cmbSortColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySort();
        }

        // triggers sort when sort order changes
        private void cmbSortOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySort();
        }
    }
}
