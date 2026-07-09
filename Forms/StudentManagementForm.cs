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
    public partial class StudentManagementForm : Form
    {
        private readonly StudentRepository _studentRepo;
        private readonly CourseRepository _courseRepo;
        private List<Student> _students;
        public StudentManagementForm()
        {
            InitializeComponent();
            _studentRepo = new StudentRepository();
            _courseRepo = new CourseRepository();
            LoadStudents();
            LoadCourses();
        }

        private void LoadStudents()
        {
            try
            {
                _students = _studentRepo.GetAll();
                dgvStudents.DataSource = null;
                dgvStudents.DataSource = _students.Select(s => new
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetCourseName(int courseId)
        {
            var course = _courseRepo.GetById(c => c.Id == courseId);
            return course != null ? course.Name : "N/A";
        }

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

        private void StudentManagementForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
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

        private void btnUpdate_Click(object sender, EventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStudents();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchStudents();
        }

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

                dgvStudents.DataSource = null;
                dgvStudents.DataSource = filtered.Select(s => new
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
            }
            catch (Exception)
            {
                // Ignore search errors
            }
        }
    }
}
