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
    public partial class TuitionManagementForm : Form
    {
        private readonly TuitionRepository _tuitionRepo;
        private readonly StudentRepository _studentRepo;
        private readonly PaymentRepository _paymentRepo;
        private List<Tuition> _tuitions;
        public TuitionManagementForm()
        {
            InitializeComponent();
            _tuitionRepo = new TuitionRepository();
            _studentRepo = new StudentRepository();
            _paymentRepo = new PaymentRepository();
            LoadTuitions();
            LoadStudents();
        }

        private void LoadTuitions()
        {
            try
            {
                _tuitions = _tuitionRepo.GetAll();
                dgvTuitions.DataSource = null;
                dgvTuitions.DataSource = _tuitions.Select(t => new
                {
                    t.Id,
                    Student = GetStudentName(t.StudentId),
                    t.Semester,
                    t.SchoolYear,
                    t.TotalUnits,
                    t.UnitFee,
                    t.TotalAmount,
                    t.AmountPaid,
                    t.Balance,
                    t.Status
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tuitions: {ex.Message}", "Error",
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

        private void CalculateTuition()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTotalUnits.Text) || string.IsNullOrWhiteSpace(txtUnitFee.Text))
                    return;

                if (int.TryParse(txtTotalUnits.Text, out int totalUnits) &&
                    decimal.TryParse(txtUnitFee.Text, out decimal unitFee))
                {
                    decimal totalAmount = totalUnits * unitFee;
                    txtTotalAmount.Text = totalAmount.ToString("N2");

                    // Get total payments for this student
                    if (cmbStudent.SelectedIndex != -1)
                    {
                        int studentId = (int)cmbStudent.SelectedValue;
                        var payments = _paymentRepo.GetAll().Where(p => p.StudentId == studentId);
                        decimal amountPaid = payments.Sum(p => p.Amount);
                        txtAmountPaid.Text = amountPaid.ToString("N2");

                        decimal balance = totalAmount - amountPaid;
                        txtBalance.Text = balance.ToString("N2");

                        // Auto-update status
                        if (balance <= 0)
                            cmbStatus.Text = "Paid";
                        else if (amountPaid > 0 && balance > 0)
                            cmbStatus.Text = "Partial";
                        else
                            cmbStatus.Text = "Pending";
                    }
                }
            }
            catch (Exception)
            {
                // Ignore calculation errors
            }
        }

        private void ClearFields()
        {
            txtID.Clear();
            cmbStudent.SelectedIndex = -1;
            cmbSemester.SelectedIndex = -1;
            txtSchoolYear.Clear();
            txtTotalUnits.Clear();
            txtUnitFee.Clear();
            txtTotalAmount.Clear();
            txtAmountPaid.Clear();
            txtBalance.Clear();
            cmbStatus.SelectedIndex = -1;
            txtID.Focus();
        }

        private void lblCalculate_Click(object sender, EventArgs e)
        {
            CalculateTuition();
        }

        private void txtTotalUnits_TextChanged(object sender, EventArgs e)
        {
            CalculateTuition();
        }

        private void txtUnitFee_TextChanged(object sender, EventArgs e)
        {
            CalculateTuition();
        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTuition();
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

                if (cmbSemester.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Semester.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSemester.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSchoolYear.Text))
                {
                    MessageBox.Show("Please enter School Year.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSchoolYear.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTotalUnits.Text) ||
                    !int.TryParse(txtTotalUnits.Text, out int totalUnits) || totalUnits <= 0)
                {
                    MessageBox.Show("Please enter valid Total Units.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTotalUnits.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtUnitFee.Text) ||
                    !decimal.TryParse(txtUnitFee.Text, out decimal unitFee) || unitFee <= 0)
                {
                    MessageBox.Show("Please enter valid Unit Fee.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnitFee.Focus();
                    return;
                }

                if (cmbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                // Check if tuition already exists for this student/semester/year
                int studentId = (int)cmbStudent.SelectedValue;
                var existing = _tuitionRepo.GetById(t =>
                    t.StudentId == studentId &&
                    t.Semester == cmbSemester.Text &&
                    t.SchoolYear == txtSchoolYear.Text);

                if (existing != null)
                {
                    MessageBox.Show("Tuition already exists for this student in this semester/year.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal totalAmount = totalUnits * unitFee;
                decimal amountPaid = 0;
                decimal balance = totalAmount;

                var tuition = new Tuition
                {
                    Id = _tuitions.Count > 0 ? _tuitions.Max(t => t.Id) + 1 : 1,
                    StudentId = studentId,
                    Semester = cmbSemester.Text,
                    SchoolYear = txtSchoolYear.Text,
                    TotalUnits = totalUnits,
                    UnitFee = unitFee,
                    TotalAmount = totalAmount,
                    AmountPaid = amountPaid,
                    Balance = balance,
                    Status = cmbStatus.Text
                };

                _tuitionRepo.Add(tuition);
                LoadTuitions();
                ClearFields();
                MessageBox.Show("Tuition added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding tuition: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTuitions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTuitions.SelectedRows.Count > 0)
            {
                var selectedRow = dgvTuitions.SelectedRows[0];
                var tuition = _tuitionRepo.GetById(t => t.Id == (int)selectedRow.Cells["Id"].Value);
                if (tuition != null)
                {
                    txtID.Text = tuition.Id.ToString();
                    cmbStudent.SelectedValue = tuition.StudentId;
                    cmbSemester.Text = tuition.Semester;
                    txtSchoolYear.Text = tuition.SchoolYear;
                    txtTotalUnits.Text = tuition.TotalUnits.ToString();
                    txtUnitFee.Text = tuition.UnitFee.ToString();
                    txtTotalAmount.Text = tuition.TotalAmount.ToString("N2");
                    txtAmountPaid.Text = tuition.AmountPaid.ToString("N2");
                    txtBalance.Text = tuition.Balance.ToString("N2");
                    cmbStatus.Text = tuition.Status;
                }
            }
        }

        private void lblUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a tuition to update.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var tuition = _tuitionRepo.GetById(t => t.Id == id);
                if (tuition == null)
                {
                    MessageBox.Show("Tuition not found.", "Error",
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

                if (cmbSemester.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Semester.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSemester.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSchoolYear.Text))
                {
                    MessageBox.Show("Please enter School Year.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSchoolYear.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTotalUnits.Text) ||
                    !int.TryParse(txtTotalUnits.Text, out int totalUnits) || totalUnits <= 0)
                {
                    MessageBox.Show("Please enter valid Total Units.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTotalUnits.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtUnitFee.Text) ||
                    !decimal.TryParse(txtUnitFee.Text, out decimal unitFee) || unitFee <= 0)
                {
                    MessageBox.Show("Please enter valid Unit Fee.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnitFee.Focus();
                    return;
                }

                if (cmbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                decimal totalAmount = totalUnits * unitFee;
                decimal amountPaid = tuition.AmountPaid;
                decimal balance = totalAmount - amountPaid;

                tuition.StudentId = (int)cmbStudent.SelectedValue;
                tuition.Semester = cmbSemester.Text;
                tuition.SchoolYear = txtSchoolYear.Text;
                tuition.TotalUnits = totalUnits;
                tuition.UnitFee = unitFee;
                tuition.TotalAmount = totalAmount;
                tuition.AmountPaid = amountPaid;
                tuition.Balance = balance;
                tuition.Status = cmbStatus.Text;

                _tuitionRepo.Update(t => t.Id == id, tuition);
                LoadTuitions();
                ClearFields();
                MessageBox.Show("Tuition updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating tuition: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a tuition to delete.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var tuition = _tuitionRepo.GetById(t => t.Id == id);
                if (tuition == null)
                {
                    MessageBox.Show("Tuition not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to delete this tuition?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _tuitionRepo.Delete(tuition);
                    LoadTuitions();
                    ClearFields();
                    MessageBox.Show("Tuition deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting tuition: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            LoadTuitions();
            ClearFields();
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchTuitions();
        }

        private void SearchTuitions()
        {
            try
            {
                string keyword = txtSearch.Text.ToLower();
                var filtered = _tuitions.Where(t =>
                    GetStudentName(t.StudentId).ToLower().Contains(keyword) ||
                    t.Semester.ToLower().Contains(keyword) ||
                    t.SchoolYear.ToLower().Contains(keyword) ||
                    t.Status.ToLower().Contains(keyword)
                ).ToList();

                dgvTuitions.DataSource = null;
                dgvTuitions.DataSource = filtered.Select(t => new
                {
                    t.Id,
                    Student = GetStudentName(t.StudentId),
                    t.Semester,
                    t.SchoolYear,
                    t.TotalUnits,
                    t.UnitFee,
                    t.TotalAmount,
                    t.AmountPaid,
                    t.Balance,
                    t.Status
                }).ToList();
            }
            catch (Exception)
            {
                // Ignore
            }
        }
    }
}
