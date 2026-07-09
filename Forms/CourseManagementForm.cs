using IntegratedUniversityInformationSystem.Models;
using IntegratedUniversityInformationSystem.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegratedUniversityInformationSystem.Forms
{
    public partial class CourseManagementForm : Form
    {
        private readonly CourseRepository _courseRepo;
        private List<Course> _courses;
        public CourseManagementForm()
        {
            InitializeComponent();

            _courseRepo = new CourseRepository();
            string path = Path.Combine(Application.StartupPath, "Data", "courses.json");
            MessageBox.Show($"File path: {path}\nExists: {File.Exists(path)}\n\nKung may laman, ito ang ginagamit ng app.");
            LoadCourses();
        }

        private void LoadCourses()
        {
            try
            {
                _courses = _courseRepo.GetAll();
                dgvCourses.DataSource = null;
                dgvCourses.DataSource = _courses.Select(c => new
                {
                    c.Id,
                    c.Code,
                    c.Name,
                    c.Description,
                    c.DurationYears,
                    c.IsActive
                }).ToList();
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
            txtCode.Clear();
            txtName.Clear();
            txtDescription.Clear();
            numDuration.Value = 4;
            chkActive.Checked = true;
            txtID.Focus();
        }

        private void CourseManagementForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    MessageBox.Show("Please enter Course Code.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Please enter Course Name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                if (_courseRepo.GetById(c => c.Code == txtCode.Text) != null)
                {
                    MessageBox.Show("Course Code already exists.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Focus();
                    return;
                }

                var course = new Course
                {
                    Id = _courses.Count > 0 ? _courses.Max(c => c.Id) + 1 : 1,
                    Code = txtCode.Text,
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    DurationYears = (int)numDuration.Value,
                    IsActive = chkActive.Checked
                };

                _courseRepo.Add(course);
                LoadCourses();
                ClearFields();
                MessageBox.Show("Course added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding course: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCourses_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count > 0)
            {
                var selectedRow = dgvCourses.SelectedRows[0];
                var course = _courseRepo.GetById(c => c.Id == (int)selectedRow.Cells["Id"].Value);
                if (course != null)
                {
                    txtID.Text = course.Id.ToString();
                    txtCode.Text = course.Code;
                    txtName.Text = course.Name;
                    txtDescription.Text = course.Description;
                    numDuration.Value = course.DurationYears;
                    chkActive.Checked = course.IsActive;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a course to update.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var course = _courseRepo.GetById(c => c.Id == id);
                if (course == null)
                {
                    MessageBox.Show("Course not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    MessageBox.Show("Please enter Course Code.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Please enter Course Name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                course.Code = txtCode.Text;
                course.Name = txtName.Text;
                course.Description = txtDescription.Text;
                course.DurationYears = (int)numDuration.Value;
                course.IsActive = chkActive.Checked;

                _courseRepo.Update(c => c.Id == id, course);
                LoadCourses();
                ClearFields();
                MessageBox.Show("Course updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating course: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a course to delete.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var course = _courseRepo.GetById(c => c.Id == id);
                if (course == null)
                {
                    MessageBox.Show("Course not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to delete this course?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Soft delete
                    course.IsActive = false;
                    _courseRepo.Update(c => c.Id == id, course);
                    LoadCourses();
                    ClearFields();
                    MessageBox.Show("Course deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting course: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCourses();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchCourses();
        }

        private void SearchCourses()
        {
            try
            {
                string keyword = txtSearch.Text.ToLower();
                var filtered = _courses.Where(c =>
                    c.Code.ToLower().Contains(keyword) ||
                    c.Name.ToLower().Contains(keyword) ||
                    c.Description.ToLower().Contains(keyword)
                ).ToList();

                dgvCourses.DataSource = null;
                dgvCourses.DataSource = filtered.Select(c => new
                {
                    c.Id,
                    c.Code,
                    c.Name,
                    c.Description,
                    c.DurationYears,
                    c.IsActive
                }).ToList();
            }
            catch (Exception)
            {
                // Ignore
            }
        }
    }
}
