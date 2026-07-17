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
    public partial class EnrollmentManagementForm : Form
    {
        private readonly EnrollmentRepository _enrollmentRepo;
        private readonly StudentRepository _studentRepo;
        private readonly SubjectRepository _subjectRepo;
        private List<Enrollment> _enrollments;
        private List<Enrollment> _displayedList;

        // sortable columns for this form
        private readonly string[] _sortColumns = new string[]
        {
            "ID",
            "Student",
            "Subject",
            "EnrollmentDate",
            "Status",
            "Grade"
        };

        public EnrollmentManagementForm()
        {
            InitializeComponent();
            _enrollmentRepo = new EnrollmentRepository();
            _studentRepo = new StudentRepository();
            _subjectRepo = new SubjectRepository();

            // load sort dropdowns
            SortHelper.LoadSortColumns(cmbSortColumn, _sortColumns);
            SortHelper.LoadSortOrders(cmbSortOrder);

            LoadEnrollments();
            LoadStudents();
            LoadSubjects();
        }

        private void LoadEnrollments()
        {
            try
            {
                _enrollments = _enrollmentRepo.GetAll();
                _displayedList = _enrollments;
                DisplayEnrollments(_displayedList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading enrollments: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayEnrollments(List<Enrollment> list)
        {
            dgvEnrollments.DataSource = null;
            dgvEnrollments.DataSource = list.Select(e => new
            {
                e.Id,
                Student = GetStudentName(e.StudentId),
                Subject = GetSubjectCode(e.SubjectId),
                e.EnrollmentDate,
                e.Status,
                Grade = e.Grade.ToString("N1"),
                e.Remarks
            }).ToList();

            UpdateSummary();
        }

        // updates summary box with count per status
        private void UpdateSummary()
        {
            var list = _displayedList ?? _enrollments ?? new List<Enrollment>();

            int enrolledCount = list.Count(e => e.Status == "Enrolled");
            int droppedCount = list.Count(e => e.Status == "Dropped");
            int completedCount = list.Count(e => e.Status == "Completed");
            int cancelledCount = list.Count(e => e.Status == "Cancelled");
            int totalCount = list.Count;

            lblEnrolledSummary.Text = enrolledCount.ToString("N0");
            lblDroppedSummary.Text = droppedCount.ToString("N0");
            lblCompletedSummary.Text = completedCount.ToString("N0");
            lblCancelledSummary.Text = cancelledCount.ToString("N0");
            lblTotalEnrollmentsSummary.Text = totalCount.ToString("N0");
        }

        // applies sorting on current list
        private void ApplySort()
        {
            if (_enrollments == null) return;

            string sortColumn = cmbSortColumn.Text;
            string sortOrder = cmbSortOrder.Text;

            _displayedList = SortHelper.SortList(
                _enrollments,
                sortColumn,
                sortOrder,
                dgvEnrollments,
                t => GetStudentName(t.StudentId)
            );

            DisplayEnrollments(_displayedList);
        }

        private string GetStudentName(int studentId)
        {
            var student = _studentRepo.GetById(s => s.Id == studentId);
            return student != null ? $"{student.FirstName} {student.LastName}" : "N/A";
        }

        private string GetSubjectCode(int subjectId)
        {
            var subject = _subjectRepo.GetById(s => s.Id == subjectId);
            return subject != null ? subject.Code : "N/A";
        }

        private void LoadStudents()
        {
            try
            {
                var students = _studentRepo.GetAll().Where(s => s.IsActive).ToList();
                cmbStudent.DataSource = students;
                cmbStudent.DisplayMember = "FullName";
                cmbStudent.ValueMember = "Id";
                cmbStudent.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSubjects()
        {
            try
            {
                var subjects = _subjectRepo.GetAll().Where(s => s.IsActive).ToList();
                cmbSubject.DataSource = subjects;
                cmbSubject.DisplayMember = "Code";
                cmbSubject.ValueMember = "Id";
                cmbSubject.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading subjects: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtID.Clear();
            cmbStudent.SelectedIndex = -1;
            cmbSubject.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            numGrade.Value = 0;
            txtRemarks.Clear();
            txtID.Focus();
        }

        private void EnrollmentManagementForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStudent.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Student.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStudent.Focus();
                    return;
                }

                if (cmbSubject.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Subject.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSubject.Focus();
                    return;
                }

                if (cmbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                // Check if student is already enrolled in this subject
                int studentId = (int)cmbStudent.SelectedValue;
                int subjectId = (int)cmbSubject.SelectedValue;
                var existing = _enrollmentRepo.GetById(en => en.StudentId == studentId && en.SubjectId == subjectId);
                if (existing != null)
                {
                    MessageBox.Show("Student is already enrolled in this subject.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var enrollment = new Enrollment
                {
                    Id = _enrollments.Count > 0 ? _enrollments.Max(en => en.Id) + 1 : 1,
                    StudentId = studentId,
                    SubjectId = subjectId,
                    EnrollmentDate = DateTime.Now,
                    Status = cmbStatus.Text,
                    Grade = numGrade.Value,
                    Remarks = txtRemarks.Text
                };

                _enrollmentRepo.Add(enrollment);
                LoadEnrollments();
                ClearFields();
                MessageBox.Show("Student enrolled successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding enrollment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEnrollments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEnrollments.SelectedRows.Count > 0)
            {
                var selectedRow = dgvEnrollments.SelectedRows[0];
                var enrollment = _enrollmentRepo.GetById(en => en.Id == (int)selectedRow.Cells["Id"].Value);
                if (enrollment != null)
                {
                    txtID.Text = enrollment.Id.ToString();
                    cmbStudent.SelectedValue = enrollment.StudentId;
                    cmbSubject.SelectedValue = enrollment.SubjectId;
                    cmbStatus.Text = enrollment.Status;
                    numGrade.Value = enrollment.Grade;
                    txtRemarks.Text = enrollment.Remarks;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select an enrollment to update.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var enrollment = _enrollmentRepo.GetById(en => en.Id == id);
                if (enrollment == null)
                {
                    MessageBox.Show("Enrollment not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbStudent.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Student.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStudent.Focus();
                    return;
                }

                if (cmbSubject.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Subject.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSubject.Focus();
                    return;
                }

                if (cmbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                enrollment.StudentId = (int)cmbStudent.SelectedValue;
                enrollment.SubjectId = (int)cmbSubject.SelectedValue;
                enrollment.Status = cmbStatus.Text;
                enrollment.Grade = numGrade.Value;
                enrollment.Remarks = txtRemarks.Text;

                _enrollmentRepo.Update(en => en.Id == id, enrollment);
                LoadEnrollments();
                ClearFields();
                MessageBox.Show("Enrollment updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating enrollment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select an enrollment to cancel.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var enrollment = _enrollmentRepo.GetById(en => en.Id == id);
                if (enrollment == null)
                {
                    MessageBox.Show("Enrollment not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to cancel this enrollment?",
                    "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    enrollment.Status = "Cancelled";
                    _enrollmentRepo.Update(en => en.Id == id, enrollment);
                    LoadEnrollments();
                    ClearFields();
                    MessageBox.Show("Enrollment cancelled successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cancelling enrollment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEnrollments();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchEnrollments();
        }

        private void SearchEnrollments()
        {
            try
            {
                string keyword = txtSearch.Text.ToLower();

                var filtered = _enrollments.Where(en =>
                    GetStudentName(en.StudentId).ToLower().Contains(keyword) ||
                    GetSubjectCode(en.SubjectId).ToLower().Contains(keyword) ||
                    en.Status.ToLower().Contains(keyword)
                ).ToList();

                _displayedList = filtered;

                // re-apply sort after search
                string sortColumn = cmbSortColumn.Text;
                string sortOrder = cmbSortOrder.Text;

                _displayedList = SortHelper.SortList(
                    _displayedList,
                    sortColumn,
                    sortOrder,
                    dgvEnrollments,
                    t => GetStudentName(t.StudentId)
                );

                DisplayEnrollments(_displayedList);
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
                if (cmbStudent.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Student.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStudent.Focus();
                    return;
                }

                if (cmbSubject.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Subject.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSubject.Focus();
                    return;
                }

                if (cmbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                // Check if student is already enrolled in this subject
                int studentId = (int)cmbStudent.SelectedValue;
                int subjectId = (int)cmbSubject.SelectedValue;
                var existing = _enrollmentRepo.GetById(en => en.StudentId == studentId && en.SubjectId == subjectId);
                if (existing != null)
                {
                    MessageBox.Show("Student is already enrolled in this subject.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var enrollment = new Enrollment
                {
                    Id = _enrollments.Count > 0 ? _enrollments.Max(en => en.Id) + 1 : 1,
                    StudentId = studentId,
                    SubjectId = subjectId,
                    EnrollmentDate = DateTime.Now,
                    Status = cmbStatus.Text,
                    Grade = numGrade.Value,
                    Remarks = txtRemarks.Text
                };

                _enrollmentRepo.Add(enrollment);
                LoadEnrollments();
                ClearFields();
                MessageBox.Show("Student enrolled successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding enrollment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select an enrollment to update.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var enrollment = _enrollmentRepo.GetById(en => en.Id == id);
                if (enrollment == null)
                {
                    MessageBox.Show("Enrollment not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbStudent.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Student.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStudent.Focus();
                    return;
                }

                if (cmbSubject.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Subject.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSubject.Focus();
                    return;
                }

                if (cmbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                enrollment.StudentId = (int)cmbStudent.SelectedValue;
                enrollment.SubjectId = (int)cmbSubject.SelectedValue;
                enrollment.Status = cmbStatus.Text;
                enrollment.Grade = numGrade.Value;
                enrollment.Remarks = txtRemarks.Text;

                _enrollmentRepo.Update(en => en.Id == id, enrollment);
                LoadEnrollments();
                ClearFields();
                MessageBox.Show("Enrollment updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating enrollment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select an enrollment to cancel.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var enrollment = _enrollmentRepo.GetById(en => en.Id == id);
                if (enrollment == null)
                {
                    MessageBox.Show("Enrollment not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to cancel this enrollment?",
                    "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    enrollment.Status = "Cancelled";
                    _enrollmentRepo.Update(en => en.Id == id, enrollment);
                    LoadEnrollments();
                    ClearFields();
                    MessageBox.Show("Enrollment cancelled successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cancelling enrollment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbSortColumn.SelectedIndex = 0;
            cmbSortOrder.SelectedIndex = 0;
            LoadEnrollments();
            ClearFields();
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
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
