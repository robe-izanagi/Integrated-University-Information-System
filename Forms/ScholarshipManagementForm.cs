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
    public partial class ScholarshipManagementForm : Form
    {
        private readonly ScholarshipRepository _scholarshipRepo;
        private readonly StudentRepository _studentRepo;
        private List<Scholarship> _scholarships;
        public ScholarshipManagementForm()
        {
            InitializeComponent();
            _scholarshipRepo = new ScholarshipRepository();
            _studentRepo = new StudentRepository();
            LoadScholarships();
            LoadStudents();
        }
        private void LoadScholarships()
        {
            try
            {
                _scholarships = _scholarshipRepo.GetAll();
                dgvScholarships.DataSource = null;
                dgvScholarships.DataSource = _scholarships.Select(s => new
                {
                    s.Id,
                    Student = GetStudentName(s.StudentId),
                    s.ScholarshipName,
                    s.Type,
                    s.Amount,
                    s.DateAwarded,
                    s.ExpiryDate,
                    s.Status,
                    s.Remarks
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading scholarships: {ex.Message}", "Error",
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
            txtScholarshipName.Clear();
            cmbType.SelectedIndex = -1;
            txtAmount.Clear();
            dtpDateAwarded.Value = DateTime.Now;
            dtpExpiryDate.Value = DateTime.Now.AddYears(1);
            cmbStatus.SelectedIndex = -1;
            txtRemarks.Clear();
            txtID.Focus();
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

                if (string.IsNullOrWhiteSpace(txtScholarshipName.Text))
                {
                    MessageBox.Show("Please enter Scholarship Name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtScholarshipName.Focus();
                    return;
                }

                if (cmbType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Type.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbType.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAmount.Text))
                {
                    MessageBox.Show("Please enter Amount.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAmount.Focus();
                    return;
                }

                if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
                {
                    MessageBox.Show("Please enter a valid Amount.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAmount.Focus();
                    return;
                }

                if (cmbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                // Check if student already has this scholarship
                int studentId = (int)cmbStudent.SelectedValue;
                var existing = _scholarshipRepo.GetById(s =>
                    s.StudentId == studentId &&
                    s.ScholarshipName == txtScholarshipName.Text);

                if (existing != null)
                {
                    MessageBox.Show("Student already has this scholarship.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var scholarship = new Scholarship
                {
                    Id = _scholarships.Count > 0 ? _scholarships.Max(s => s.Id) + 1 : 1,
                    StudentId = studentId,
                    ScholarshipName = txtScholarshipName.Text,
                    Type = cmbType.Text,
                    Amount = amount,
                    DateAwarded = dtpDateAwarded.Value,
                    ExpiryDate = dtpExpiryDate.Value,
                    Status = cmbStatus.Text,
                    Remarks = txtRemarks.Text
                };

                _scholarshipRepo.Add(scholarship);
                LoadScholarships();
                ClearFields();
                MessageBox.Show("Scholarship added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding scholarship: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvScholarships_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvScholarships.SelectedRows.Count > 0)
            {
                var selectedRow = dgvScholarships.SelectedRows[0];
                var scholarship = _scholarshipRepo.GetById(s => s.Id == (int)selectedRow.Cells["Id"].Value);
                if (scholarship != null)
                {
                    txtID.Text = scholarship.Id.ToString();
                    cmbStudent.SelectedValue = scholarship.StudentId;
                    txtScholarshipName.Text = scholarship.ScholarshipName;
                    cmbType.Text = scholarship.Type;
                    txtAmount.Text = scholarship.Amount.ToString();
                    dtpDateAwarded.Value = scholarship.DateAwarded;
                    dtpExpiryDate.Value = scholarship.ExpiryDate;
                    cmbStatus.Text = scholarship.Status;
                    txtRemarks.Text = scholarship.Remarks;
                }
            }
        }

        private void lblUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a scholarship to update.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var scholarship = _scholarshipRepo.GetById(s => s.Id == id);
                if (scholarship == null)
                {
                    MessageBox.Show("Scholarship not found.", "Error",
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

                if (string.IsNullOrWhiteSpace(txtScholarshipName.Text))
                {
                    MessageBox.Show("Please enter Scholarship Name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtScholarshipName.Focus();
                    return;
                }

                if (cmbType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Type.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbType.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAmount.Text))
                {
                    MessageBox.Show("Please enter Amount.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAmount.Focus();
                    return;
                }

                if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
                {
                    MessageBox.Show("Please enter a valid Amount.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAmount.Focus();
                    return;
                }

                if (cmbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                scholarship.StudentId = (int)cmbStudent.SelectedValue;
                scholarship.ScholarshipName = txtScholarshipName.Text;
                scholarship.Type = cmbType.Text;
                scholarship.Amount = amount;
                scholarship.DateAwarded = dtpDateAwarded.Value;
                scholarship.ExpiryDate = dtpExpiryDate.Value;
                scholarship.Status = cmbStatus.Text;
                scholarship.Remarks = txtRemarks.Text;

                _scholarshipRepo.Update(s => s.Id == id, scholarship);
                LoadScholarships();
                ClearFields();
                MessageBox.Show("Scholarship updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating scholarship: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a scholarship to delete.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var scholarship = _scholarshipRepo.GetById(s => s.Id == id);
                if (scholarship == null)
                {
                    MessageBox.Show("Scholarship not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to delete this scholarship?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Soft delete - set status to Expired
                    scholarship.Status = "Expired";
                    _scholarshipRepo.Update(s => s.Id == id, scholarship);
                    LoadScholarships();
                    ClearFields();
                    MessageBox.Show("Scholarship expired successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting scholarship: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            LoadScholarships();
            ClearFields();
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchScholarships();
        }

        private void SearchScholarships()
        {
            try
            {
                string keyword = txtSearch.Text.ToLower();
                var filtered = _scholarships.Where(s =>
                    GetStudentName(s.StudentId).ToLower().Contains(keyword) ||
                    s.ScholarshipName.ToLower().Contains(keyword) ||
                    s.Type.ToLower().Contains(keyword) ||
                    s.Status.ToLower().Contains(keyword)
                ).ToList();

                dgvScholarships.DataSource = null;
                dgvScholarships.DataSource = filtered.Select(s => new
                {
                    s.Id,
                    Student = GetStudentName(s.StudentId),
                    s.ScholarshipName,
                    s.Type,
                    s.Amount,
                    s.DateAwarded,
                    s.ExpiryDate,
                    s.Status,
                    s.Remarks
                }).ToList();
            }
            catch (Exception)
            {
                // Ignore
            }
        }
    }
}
