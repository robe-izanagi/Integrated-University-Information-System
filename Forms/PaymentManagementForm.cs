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
    // form for managing student payments
    public partial class PaymentManagementForm : Form
    {
        // repositories for data access
        private readonly PaymentRepository _paymentRepo;
        private readonly StudentRepository _studentRepo;
        private List<Payment> _payments; // holds all payments
        public PaymentManagementForm()
        {
            InitializeComponent();

            // initialize repositories
            _paymentRepo = new PaymentRepository();
            _studentRepo = new StudentRepository();

            // load data
            LoadPayments();
            LoadStudents();
        }

        // loads all payments from JSON
        private void LoadPayments()
        {
            try
            {
                _payments = _paymentRepo.GetAll();
                dgvPayments.DataSource = null;
                dgvPayments.DataSource = _payments.Select(p => new
                {
                    p.Id,
                    Student = GetStudentName(p.StudentId),
                    p.Amount,
                    p.PaymentDate,
                    p.PaymentMethod,
                    p.ReferenceNo,
                    p.Remarks
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payments: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // gets student full name by ID
        private string GetStudentName(int studentId)
        {
            var student = _studentRepo.GetById(s => s.Id == studentId);
            return student != null ? $"{student.FirstName} {student.LastName}" : "N/A";
        }

        // loads active students into dropdown
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

        // clears all input fields
        private void ClearFields()
        {
            txtID.Clear();
            cmbStudent.SelectedIndex = -1;
            txtAmount.Clear();
            dtpPaymentDate.Value = DateTime.Now;
            cmbPaymentMethod.SelectedIndex = -1;
            txtReferenceNo.Clear();
            txtRemarks.Clear();
            txtID.Focus();
        }

        // adds new payment record
        private void lblAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // validate student selection
                if (cmbStudent.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Student.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStudent.Focus();
                    return;
                }

                // validate amount
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

                // validate payment method
                if (cmbPaymentMethod.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Payment Method.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbPaymentMethod.Focus();
                    return;
                }

                // create new payment
                var payment = new Payment
                {
                    Id = _payments.Count > 0 ? _payments.Max(p => p.Id) + 1 : 1,
                    StudentId = (int)cmbStudent.SelectedValue,
                    Amount = amount,
                    PaymentDate = dtpPaymentDate.Value,
                    PaymentMethod = cmbPaymentMethod.Text,
                    ReferenceNo = txtReferenceNo.Text,
                    Remarks = txtRemarks.Text
                };

                // save and refresh
                _paymentRepo.Add(payment);
                LoadPayments();
                ClearFields();
                MessageBox.Show("Payment added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding payment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // clears all fields
        private void lblClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // deletes selected payment
        private void lblDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // check if record is selected
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a payment to delete.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var payment = _paymentRepo.GetById(p => p.Id == id);
                if (payment == null)
                {
                    MessageBox.Show("Payment not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // confirm deletion
                DialogResult result = MessageBox.Show("Are you sure you want to delete this payment?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _paymentRepo.Delete(payment);
                    LoadPayments();
                    ClearFields();
                    MessageBox.Show("Payment deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting payment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // updates selected payment
        private void lblUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // check if record is selected
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a payment to update.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // validate fields
                int id = int.Parse(txtID.Text);
                var payment = _paymentRepo.GetById(p => p.Id == id);
                if (payment == null)
                {
                    MessageBox.Show("Payment not found.", "Error",
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

                if (cmbPaymentMethod.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Payment Method.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbPaymentMethod.Focus();
                    return;
                }

                // update payment
                payment.StudentId = (int)cmbStudent.SelectedValue;
                payment.Amount = amount;
                payment.PaymentDate = dtpPaymentDate.Value;
                payment.PaymentMethod = cmbPaymentMethod.Text;
                payment.ReferenceNo = txtReferenceNo.Text;
                payment.Remarks = txtRemarks.Text;

                // save and refresh
                _paymentRepo.Update(p => p.Id == id, payment);
                LoadPayments();
                ClearFields();
                MessageBox.Show("Payment updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating payment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // refreshes the list
        private void pbRefresh_Click(object sender, EventArgs e)
        {
            LoadPayments();
            ClearFields();
        }

        // search filter
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchPayments();
        }

        // loads selected row into fields
        private void dgvPayments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPayments.SelectedRows.Count > 0)
            {
                var selectedRow = dgvPayments.SelectedRows[0];
                var payment = _paymentRepo.GetById(p => p.Id == (int)selectedRow.Cells["Id"].Value);
                if (payment != null)
                {
                    txtID.Text = payment.Id.ToString();
                    cmbStudent.SelectedValue = payment.StudentId;
                    txtAmount.Text = payment.Amount.ToString();
                    dtpPaymentDate.Value = payment.PaymentDate;
                    cmbPaymentMethod.Text = payment.PaymentMethod;
                    txtReferenceNo.Text = payment.ReferenceNo;
                    txtRemarks.Text = payment.Remarks;
                }
            }
        }

        // filters payments by student name, method, or reference
        private void SearchPayments()
        {
            try
            {
                string keyword = txtSearch.Text.ToLower();
                var filtered = _payments.Where(p =>
                    GetStudentName(p.StudentId).ToLower().Contains(keyword) ||
                    p.PaymentMethod.ToLower().Contains(keyword) ||
                    p.ReferenceNo.ToLower().Contains(keyword)
                ).ToList();

                dgvPayments.DataSource = null;
                dgvPayments.DataSource = filtered.Select(p => new
                {
                    p.Id,
                    Student = GetStudentName(p.StudentId),
                    p.Amount,
                    p.PaymentDate,
                    p.PaymentMethod,
                    p.ReferenceNo,
                    p.Remarks
                }).ToList();
            }
            catch (Exception)
            {
                // Ignore
            }
        }
    }
}
