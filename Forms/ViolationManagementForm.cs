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
    public partial class ViolationManagementForm : Form
    {
        private readonly ViolationRepository _violationRepo;
        private readonly StudentRepository _studentRepo;
        private List<Violation> _violations;

        public ViolationManagementForm()
        {
            InitializeComponent();
            _violationRepo = new ViolationRepository();
            _studentRepo = new StudentRepository();

            LoadViolations();
            LoadStudents();
        }

        private void LoadViolations()
        {
            try
            {
                _violations = _violationRepo.GetAll();

                dgvViolations.DataSource = null;

                dgvViolations.DataSource = _violations.Select(v => new
                {
                    v.Id,
                    Student = GetStudentName(v.StudentId),
                    v.ViolationType,
                    v.Description,
                    v.DateOfViolation,
                    v.Sanction,
                    v.Status,
                    v.Remarks
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading violations: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetStudentName(int studentId)
        {
            var student = _studentRepo.GetById(s => s.Id == studentId);
            return student != null ? $"{student.FirstName} {student.LastName}" : "N/A";
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

        private void ClearFields()
        {
            txtID.Clear();
            cmbStudent.SelectedIndex = -1;
            cmbViolationType.SelectedIndex = -1;
            txtDescription.Clear();
            dtpDateOfViolation.Value = DateTime.Now;
            txtSanction.Clear();
            cmbStatus.SelectedIndex = -1;
            txtRemarks.Clear();
            txtID.Focus();
        }

        private void lblAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // validate fields
                if (cmbStudent.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Student.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStudent.Focus();
                    return;
                }

                if (cmbViolationType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Violation Type.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbViolationType.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    MessageBox.Show("Please enter Description.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDescription.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSanction.Text))
                {
                    MessageBox.Show("Please enter Sanction.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSanction.Focus();
                    return;
                }

                if (cmbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                // create new violation record
                var violation = new Violation
                {
                    Id = _violations.Count > 0 ? _violations.Max(v => v.Id) + 1 : 1,
                    StudentId = (int)cmbStudent.SelectedValue,
                    ViolationType = cmbViolationType.Text,
                    Description = txtDescription.Text,
                    DateOfViolation = dtpDateOfViolation.Value,
                    Sanction = txtSanction.Text,
                    Status = cmbStatus.Text,
                    Remarks = txtRemarks.Text
                };

                _violationRepo.Add(violation);
                LoadViolations();
                ClearFields();

                MessageBox.Show("Violation record added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding violation: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvViolations_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvViolations.SelectedRows.Count > 0)
            {
                var selectedRow = dgvViolations.SelectedRows[0];
                var violation = _violationRepo.GetById(v => v.Id == (int)selectedRow.Cells["Id"].Value);

                if (violation != null)
                {
                    txtID.Text = violation.Id.ToString();
                    cmbStudent.SelectedValue = violation.StudentId;
                    cmbViolationType.Text = violation.ViolationType;
                    txtDescription.Text = violation.Description;
                    dtpDateOfViolation.Value = violation.DateOfViolation;
                    txtSanction.Text = violation.Sanction;
                    cmbStatus.Text = violation.Status;
                    txtRemarks.Text = violation.Remarks;
                }
            }
        }

        private void lblUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a violation record to update.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var violation = _violationRepo.GetById(v => v.Id == id);

                if (violation == null)
                {
                    MessageBox.Show("Violation record not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // validate fields
                if (cmbStudent.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Student.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStudent.Focus();
                    return;
                }

                if (cmbViolationType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Violation Type.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbViolationType.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    MessageBox.Show("Please enter Description.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDescription.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSanction.Text))
                {
                    MessageBox.Show("Please enter Sanction.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSanction.Focus();
                    return;
                }

                if (cmbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                // update violation record
                violation.StudentId = (int)cmbStudent.SelectedValue;
                violation.ViolationType = cmbViolationType.Text;
                violation.Description = txtDescription.Text;
                violation.DateOfViolation = dtpDateOfViolation.Value;
                violation.Sanction = txtSanction.Text;
                violation.Status = cmbStatus.Text;
                violation.Remarks = txtRemarks.Text;

                _violationRepo.Update(v => v.Id == id, violation);
                LoadViolations();
                ClearFields();

                MessageBox.Show("Violation record updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating violation: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a violation record to delete.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var violation = _violationRepo.GetById(v => v.Id == id);

                if (violation == null)
                {
                    MessageBox.Show("Violation record not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to delete this violation record?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _violationRepo.Delete(violation);
                    LoadViolations();
                    ClearFields();

                    MessageBox.Show("Violation record deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting violation: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            LoadViolations();
            LoadStudents();
            ClearFields();
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchViolations();
        }
        private void SearchViolations()
        {
            try
            {
                string keyword = txtSearch.Text.ToLower();

                var filtered = _violations.Where(v =>
                    GetStudentName(v.StudentId).ToLower().Contains(keyword) ||
                    v.ViolationType.ToLower().Contains(keyword) ||
                    v.Status.ToLower().Contains(keyword) ||
                    v.Description.ToLower().Contains(keyword)
                ).ToList();

                dgvViolations.DataSource = null;
                dgvViolations.DataSource = filtered.Select(v => new
                {
                    v.Id,
                    Student = GetStudentName(v.StudentId),
                    v.ViolationType,
                    v.Description,
                    v.DateOfViolation,
                    v.Sanction,
                    v.Status,
                    v.Remarks
                }).ToList();
            }
            catch (Exception)
            {
                // ignore
            }
        }

    }
}
