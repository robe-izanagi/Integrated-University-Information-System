using IntegratedUniversityInformationSystem.Helpers;
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
        private List<Course> _displayedList;

        // sortable columns for this form
        private readonly string[] _sortColumns = new string[]
        {
            "ID",
            "Code",
            "Name",
            "DurationYears",
            "IsActive"
        };

        public CourseManagementForm()
        {
            InitializeComponent();
            dgvCourses.ForeColor = Color.Black;
            dgvCourses.DefaultCellStyle.ForeColor = Color.Black;
            dgvCourses.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
            dgvCourses.RowHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvCourses.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            // load sort dropdowns
            SortHelper.LoadSortColumns(cmbSortColumn, _sortColumns);
            SortHelper.LoadSortOrders(cmbSortOrder);

            _courseRepo = new CourseRepository();
            LoadCourses();
        }

        private void LoadCourses()
        {
            try
            {
                _courses = _courseRepo.GetAll();
                _displayedList = _courses;
                DisplayCourses(_displayedList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayCourses(List<Course> list)
        {
            dgvCourses.DataSource = null;
            dgvCourses.DataSource = list.Select(c => new
            {
                c.Id,
                c.Code,
                c.Name,
                c.Description,
                c.DurationYears,
                c.IsActive
            }).ToList();

            UpdateSummary();
        }

        // updates summary box with active/inactive/total count
        private void UpdateSummary()
        {
            var list = _displayedList ?? _courses ?? new List<Course>();

            int activeCount = list.Count(c => c.IsActive == true);
            int inactiveCount = list.Count(c => c.IsActive == false);
            int totalCount = list.Count;

            lblActiveSummary.Text = activeCount.ToString("N0");
            lblInactiveSummary.Text = inactiveCount.ToString("N0");
            lblTotalCoursesSummary.Text = totalCount.ToString("N0");
        }

        // applies sorting on current list
        private void ApplySort()
        {
            if (_courses == null) return;

            string sortColumn = cmbSortColumn.Text;
            string sortOrder = cmbSortOrder.Text;

            _displayedList = SortHelper.SortList(
                _courses,
                sortColumn,
                sortOrder,
                dgvCourses,
                null
            );

            DisplayCourses(_displayedList);
        }

        private void ClearFields()
        {
            txtID.Clear();
            txtCode.Clear();
            txtName.Clear();
            txtDescription.Clear();
            numDuration.Value = 4;
            txtID.Focus();
        }

        private void CourseManagementForm_Load(object sender, EventArgs e)
        {

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
                }
            }
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

                _displayedList = filtered;

                // re-apply sort after search
                string sortColumn = cmbSortColumn.Text;
                string sortOrder = cmbSortOrder.Text;

                _displayedList = SortHelper.SortList(
                    _displayedList,
                    sortColumn,
                    sortOrder,
                    dgvCourses,
                    null
                );

                DisplayCourses(_displayedList);
            }
            catch (Exception)
            {
                // ignore
            }
        }

        private void lblAdd_Click(object sender, EventArgs e)
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
                    DurationYears = (int)numDuration.Value
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

        private void lblClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbSortColumn.SelectedIndex = 0;
            cmbSortOrder.SelectedIndex = 0;
            LoadCourses();
            ClearFields();
        }

        private void lblDelete_Click(object sender, EventArgs e)
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

        private void lblUpdate_Click(object sender, EventArgs e)
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

        private void cmbSortColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySort();
        }

        private void cmbSortOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySort();
        }
    }
}
