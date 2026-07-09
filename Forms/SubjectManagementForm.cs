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
        public SubjectManagementForm()
        {
            InitializeComponent();
            _subjectRepo = new SubjectRepository();
            _courseRepo = new CourseRepository();
            LoadSubjects();
            LoadCourses();
        }

        private void LoadSubjects()
        {
            try
            {
                _subjects = _subjectRepo.GetAll();
                dgvSubjects.DataSource = null;
                dgvSubjects.DataSource = _subjects.Select(s => new
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading subjects: {ex.Message}", "Error",
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
            txtCode.Clear();
            txtName.Clear();
            txtDescription.Clear();
            numUnits.Value = 3;
            cmbCourse.SelectedIndex = -1;
            cmbYearLevel.SelectedIndex = -1;
            cmbSemester.SelectedIndex = -1;
            chkActive.Checked = true;
            txtID.Focus();
        }


        private void SubjectManagementForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
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
                    IsActive = chkActive.Checked
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
                    chkActive.Checked = subject.IsActive;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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
                subject.IsActive = chkActive.Checked;

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

        private void btnDelete_Click(object sender, EventArgs e)
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSubjects();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
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

                dgvSubjects.DataSource = null;
                dgvSubjects.DataSource = filtered.Select(s => new
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
            }
            catch (Exception)
            {
                // Ignore
            }
        }
    }
}
