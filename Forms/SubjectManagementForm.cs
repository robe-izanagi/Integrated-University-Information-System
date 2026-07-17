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
    public partial class SubjectManagementForm : Form
    {
        private readonly SubjectRepository _subjectRepo;
        private readonly CourseRepository _courseRepo;
        private List<Subject> _subjects;
        private List<Subject> _displayedList;

        // sortable columns for this form
        private readonly string[] _sortColumns = new string[]
        {
            "ID",
            "Code",
            "Name",
            "Units",
            "Course",
            "YearLevel",
            "Semester"
        };

        public SubjectManagementForm()
        {
            InitializeComponent();
            _subjectRepo = new SubjectRepository();
            _courseRepo = new CourseRepository();

            // load sort dropdowns
            SortHelper.LoadSortColumns(cmbSortColumn, _sortColumns);
            SortHelper.LoadSortOrders(cmbSortOrder);

            LoadSubjects();
            LoadCourses();
        }

        private void LoadSubjects()
        {
            try
            {
                _subjects = _subjectRepo.GetAll();
                _displayedList = _subjects;
                DisplaySubjects(_displayedList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading subjects: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplaySubjects(List<Subject> list)
        {
            dgvSubjects.DataSource = null;
            dgvSubjects.DataSource = list.Select(s => new
            {
                s.Id,
                s.Code,
                s.Name,
                s.Description,
                s.Units,
                Course = GetCourseName(s.CourseId),
                s.YearLevel,
                s.Semester,
                s.IsActive
            }).ToList();

            UpdateSummary();
        }

        // updates summary box with count per year level
        private void UpdateSummary()
        {
            var list = _displayedList ?? _subjects ?? new List<Subject>();

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
            lblTotalSubjectsSummary.Text = total.ToString("N0");
        }


        // applies sorting on current list
        private void ApplySort()
        {
            if (_subjects == null) return;

            string sortColumn = cmbSortColumn.Text;
            string sortOrder = cmbSortOrder.Text;

            _displayedList = SortHelper.SortList(
                _subjects,
                sortColumn,
                sortOrder,
                dgvSubjects,
                null
            );

            DisplaySubjects(_displayedList);
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
            txtCode.Clear();
            txtName.Clear();
            txtDescription.Clear();
            numUnits.Value = 3;
            cmbCourse.SelectedIndex = -1;
            cmbYearLevel.SelectedIndex = -1;
            cmbSemester.SelectedIndex = -1;
            txtID.Focus();
        }

 

        private void dgvSubjects_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSubjects.SelectedRows.Count > 0)
            {
                var selectedRow = dgvSubjects.SelectedRows[0];
                var subject = _subjectRepo.GetById(s => s.Id == (int)selectedRow.Cells["Id"].Value);
                if (subject != null)
                {
                    txtID.Text = subject.Id.ToString();
                    txtCode.Text = subject.Code;
                    txtName.Text = subject.Name;
                    txtDescription.Text = subject.Description;
                    numUnits.Value = subject.Units;
                    cmbCourse.SelectedValue = subject.CourseId;
                    cmbYearLevel.Text = subject.YearLevel.ToString();
                    cmbSemester.Text = subject.Semester;
                }
            }
        }


        

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchSubjects();
        }

        private void SearchSubjects()
        {
            try
            {
                string keyword = txtSearch.Text.ToLower();

                var filtered = _subjects.Where(s =>
                    s.Code.ToLower().Contains(keyword) ||
                    s.Name.ToLower().Contains(keyword) ||
                    s.Description.ToLower().Contains(keyword)
                ).ToList();

                _displayedList = filtered;

                // re-apply sort after search
                string sortColumn = cmbSortColumn.Text;
                string sortOrder = cmbSortOrder.Text;

                _displayedList = SortHelper.SortList(
                    _displayedList,
                    sortColumn,
                    sortOrder,
                    dgvSubjects,
                    null
                );

                DisplaySubjects(_displayedList);
            }
            catch (Exception)
            {
                // ignore
            }
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void lblAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    MessageBox.Show("Please enter Subject Code.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Please enter Subject Name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
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

                if (cmbSemester.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Semester.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSemester.Focus();
                    return;
                }

                if (_subjectRepo.GetById(s => s.Code == txtCode.Text) != null)
                {
                    MessageBox.Show("Subject Code already exists.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Focus();
                    return;
                }

                var subject = new Subject
                {
                    Id = _subjects.Count > 0 ? _subjects.Max(s => s.Id) + 1 : 1,
                    Code = txtCode.Text,
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    Units = (int)numUnits.Value,
                    CourseId = (int)cmbCourse.SelectedValue,
                    YearLevel = int.Parse(cmbYearLevel.Text),
                    Semester = cmbSemester.Text,
                };

                _subjectRepo.Add(subject);
                LoadSubjects();
                ClearFields();
                MessageBox.Show("Subject added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding subject: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a subject to delete.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var subject = _subjectRepo.GetById(s => s.Id == id);
                if (subject == null)
                {
                    MessageBox.Show("Subject not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to delete this subject?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    subject.IsActive = false;
                    _subjectRepo.Update(s => s.Id == id, subject);
                    LoadSubjects();
                    ClearFields();
                    MessageBox.Show("Subject deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting subject: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a subject to update.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var subject = _subjectRepo.GetById(s => s.Id == id);
                if (subject == null)
                {
                    MessageBox.Show("Subject not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    MessageBox.Show("Please enter Subject Code.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Please enter Subject Name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
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

                if (cmbSemester.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Semester.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSemester.Focus();
                    return;
                }

                subject.Code = txtCode.Text;
                subject.Name = txtName.Text;
                subject.Description = txtDescription.Text;
                subject.Units = (int)numUnits.Value;
                subject.CourseId = (int)cmbCourse.SelectedValue;
                subject.YearLevel = int.Parse(cmbYearLevel.Text);
                subject.Semester = cmbSemester.Text;

                _subjectRepo.Update(s => s.Id == id, subject);
                LoadSubjects();
                ClearFields();
                MessageBox.Show("Subject updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating subject: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbSortColumn.SelectedIndex = 0;
            cmbSortOrder.SelectedIndex = 0;
            LoadSubjects();
            ClearFields();
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
