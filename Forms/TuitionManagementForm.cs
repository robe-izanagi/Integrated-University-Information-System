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
    // form for managing tuition assessments
    public partial class TuitionManagementForm : Form
    {
        // repositories for data access
        private readonly TuitionRepository _tuitionRepo;
        private readonly StudentRepository _studentRepo;
        private readonly PaymentRepository _paymentRepo;
        private List<Tuition> _tuitions; // holds all tuition records
        private List<Tuition> _displayedList;

        // define sortable columns for this form
        private readonly string[] _sortColumns = new string[]
        {
            "ID",
            "Student",
            "Semester",
            "SchoolYear",
            "TotalUnits",
            "UnitFee",
            "TotalAmount",
            "AmountPaid",
            "Balance",
            "Status"
        };
        public TuitionManagementForm()
        {
            InitializeComponent();

            // initialize repositories
            _tuitionRepo = new TuitionRepository();
            _studentRepo = new StudentRepository();
            _paymentRepo = new PaymentRepository();

            // load sort dropdowns
            SortHelper.LoadSortColumns(cmbSortColumn, _sortColumns);
            SortHelper.LoadSortOrders(cmbSortOrder);

            // load data
            LoadTuitions();
            LoadStudents();
        }

        // loads all tuition records from JSON
        private void LoadTuitions()
        {
            try
            {
                _tuitions = _tuitionRepo.GetAll();

                // Recalculate all tuitions based on payments
                RecalculateAllTuitions();

                _displayedList = _tuitions;
                DisplayTuitions(_displayedList);
                UpdateSummary(); // update summary after loading
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tuitions: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // recalculates AmountPaid, Balance, and Status for ALL tuition records
        private void RecalculateAllTuitions()
        {
            if (_tuitions == null || _tuitions.Count == 0) return;

            // get all payments once
            var allPayments = _paymentRepo.GetAll();

            // use for loop instead of foreach para hindi mag-error
            for (int i = 0; i < _tuitions.Count; i++)
            {
                var tuition = _tuitions[i];

                // get total payments for this student
                decimal totalPaid = allPayments
                    .Where(p => p.StudentId == tuition.StudentId)
                    .Sum(p => p.Amount);

                // update tuition
                tuition.AmountPaid = totalPaid;
                tuition.Balance = tuition.TotalAmount - totalPaid;

                // update status based on balance
                if (tuition.Balance <= 0)
                    tuition.Status = "Paid";
                else if (totalPaid > 0 && tuition.Balance > 0)
                    tuition.Status = "Partial";
                else
                    tuition.Status = "Pending";

                // save changes to JSON
                _tuitionRepo.Update(t => t.Id == tuition.Id, tuition);
            }
        }

        private void DisplayTuitions(List<Tuition> list)
        {
            dgvTuitions.DataSource = null;
            dgvTuitions.DataSource = list.Select(t => new
            {
                t.Id,
                Student = GetStudentName(t.StudentId),
                t.Semester,
                t.SchoolYear,
                t.TotalUnits,
                UnitFee = t.UnitFee.ToString("N2"),
                TotalAmount = t.TotalAmount.ToString("N2"),
                AmountPaid = t.AmountPaid.ToString("N2"),
                Balance = t.Balance.ToString("N2"),
                t.Status
            }).ToList();

            // update summary after displaying
            UpdateSummary();
        }

        // updates the summary box at the top
        private void UpdateSummary()
        {
            // use displayed list (filtered + sorted) or fallback to all tuitions
            var list = _displayedList ?? _tuitions ?? new List<Tuition>();

            if (list.Count == 0)
            {
                lblTotalUnitsSummary.Text = "0";
                lblUnitFeeSummary.Text = "0.00";
                lblTotalAmountSummary.Text = "0.00";
                lblAmountPaidSummary.Text = "0.00";
                lblBalanceSummary.Text = "0.00";
                return;
            }

            // compute totals
            int totalUnits = list.Sum(t => t.TotalUnits);
            decimal totalAmount = list.Sum(t => t.TotalAmount);
            decimal amountPaid = list.Sum(t => t.AmountPaid);
            decimal balance = list.Sum(t => t.Balance);
            decimal avgUnitFee = list.Average(t => t.UnitFee);

            // display with formatting
            lblTotalUnitsSummary.Text = totalUnits.ToString("N0");
            lblUnitFeeSummary.Text = avgUnitFee.ToString("N2"); // average unit fee
            lblTotalAmountSummary.Text = totalAmount.ToString("N2");
            lblAmountPaidSummary.Text = amountPaid.ToString("N2");
            lblBalanceSummary.Text = balance.ToString("N2");
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

        // applies sorting on current list
        private void ApplySort()
        {
            if (_tuitions == null) return;

            string sortColumn = cmbSortColumn.Text;
            string sortOrder = cmbSortOrder.Text;

            _displayedList = SortHelper.SortList(
                _tuitions,
                sortColumn,
                sortOrder,
                dgvTuitions,
                t => GetStudentName(t.StudentId) // pass the function to get student name for sorting
            );

            DisplayTuitions(_displayedList);
        }

        // computes total amount, paid amount, balance, and auto-updates status
        private void CalculateTuition()
        {
            try
            {
                // exit if units or fee are empty
                if (string.IsNullOrWhiteSpace(txtTotalUnits.Text) || string.IsNullOrWhiteSpace(txtUnitFee.Text))
                    return;

                // compute total amount
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

                        // compute balance
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

        // clears all input fields
        private void ClearFields()
        {
            txtID.Clear();
            cmbStudent.SelectedIndex = -1;
            cmbSemester.SelectedIndex = -1;
            txtTotalUnits.Clear();
            txtUnitFee.Clear();
            txtTotalAmount.Clear();
            txtAmountPaid.Clear();
            txtBalance.Clear();
            cmbStatus.SelectedIndex = -1;
            txtID.Focus();
        }

        // auto-calculate when total units changes
        private void txtTotalUnits_TextChanged(object sender, EventArgs e)
        {
            CalculateTuition();
        }

        // auto-calculate when unit fee changes
        private void txtUnitFee_TextChanged(object sender, EventArgs e)
        {
            CalculateTuition();
        }

        // auto-calculate when student changes
        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTuition();
        }

        // adds new tuition record
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

                if (cmbSemester.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Semester.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSemester.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(cmbSchoolYear.Text))
                {
                    MessageBox.Show("Please enter School Year.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSchoolYear.Focus();
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

                // check for duplicate tuition (same student, semester, school year)
                int studentId = (int)cmbStudent.SelectedValue;
                var existing = _tuitionRepo.GetById(t =>
                    t.StudentId == studentId &&
                    t.Semester == cmbSemester.Text &&
                    t.SchoolYear == cmbSchoolYear.Text);

                if (existing != null)
                {
                    MessageBox.Show("Tuition already exists for this student in this semester/year.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // compute values
                decimal totalAmount = totalUnits * unitFee;
                decimal amountPaid = 0;
                decimal balance = totalAmount;

                // create new tuition
                var tuition = new Tuition
                {
                    Id = _tuitions.Count > 0 ? _tuitions.Max(t => t.Id) + 1 : 1,
                    StudentId = studentId,
                    Semester = cmbSemester.Text,
                    SchoolYear = cmbSchoolYear.Text,
                    TotalUnits = totalUnits,
                    UnitFee = unitFee,
                    TotalAmount = totalAmount,
                    AmountPaid = amountPaid,
                    Balance = balance,
                    Status = cmbStatus.Text
                };

                // save and refresh
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

        // loads selected row into fields
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
                    cmbSchoolYear.Text = tuition.SchoolYear;
                    txtTotalUnits.Text = tuition.TotalUnits.ToString();
                    txtUnitFee.Text = tuition.UnitFee.ToString("N2");
                    txtTotalAmount.Text = tuition.TotalAmount.ToString("N2");
                    txtAmountPaid.Text = tuition.AmountPaid.ToString("N2");
                    txtBalance.Text = tuition.Balance.ToString("N2");
                    cmbStatus.Text = tuition.Status;
                }
            }
        }

        // updates selected tuition record
        private void lblUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // check if record is selected
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

                // validate fields
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

                if (string.IsNullOrWhiteSpace(cmbSchoolYear.Text))
                {
                    MessageBox.Show("Please enter School Year.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSchoolYear.Focus();
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

                // update only the fields that are editable
                tuition.StudentId = (int)cmbStudent.SelectedValue;
                tuition.Semester = cmbSemester.Text;
                tuition.SchoolYear = cmbSchoolYear.Text;
                tuition.TotalUnits = totalUnits;
                tuition.UnitFee = unitFee;
                tuition.TotalAmount = totalUnits * unitFee;
                tuition.Status = cmbStatus.Text;

                // Recalculate AmountPaid and Balance based on payments
                decimal totalPaid = _paymentRepo.GetAll()
                    .Where(p => p.StudentId == tuition.StudentId)
                    .Sum(p => p.Amount);

                tuition.AmountPaid = totalPaid;
                tuition.Balance = tuition.TotalAmount - totalPaid;

                // Auto-update status if needed
                if (tuition.Balance <= 0)
                    tuition.Status = "Paid";
                else if (totalPaid > 0 && tuition.Balance > 0)
                    tuition.Status = "Partial";
                // else keep the selected status

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

        // deletes selected tuition record
        private void lblDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // check if record is selected
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

                // confirm deletion
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

        // refreshes the list
        private void pbRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbSortColumn.SelectedIndex = 0;
            cmbSortOrder.SelectedIndex = 0;

            // Refresh all data
            _tuitionRepo.Refresh();
            _paymentRepo.Refresh();

            LoadTuitions();
            ClearFields();
        }

        // clears all fields
        private void lblClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // search filter
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchTuitions();
        }

        // filters tuitions by student name, semester, school year, or status
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

                _displayedList = filtered;
                DisplayTuitions(_displayedList);
            }
            catch (Exception)
            {
                // Ignore
            }
        }

        private void cmbSortColumn_TextChanged(object sender, EventArgs e)
        {
            ApplySort();
        }

        private void cmbSortOrder_TextChanged(object sender, EventArgs e)
        {
            ApplySort();
        }

        private void cmbSortColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySort();
        }

        private void cmbSortOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySort();
        }

        private void TuitionManagementForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
