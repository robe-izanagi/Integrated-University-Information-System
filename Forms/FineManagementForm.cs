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
    public partial class FineManagementForm : Form
    {
        // repositories
        private readonly FineRepository _fineRepo;
        private readonly BorrowingRepository _borrowingRepo;
        private readonly StudentRepository _studentRepo;
        private readonly BookRepository _bookRepo;
        private List<Fine> _fines;
        public FineManagementForm()
        {
            InitializeComponent();
            _fineRepo = new FineRepository();
            _borrowingRepo = new BorrowingRepository();
            _studentRepo = new StudentRepository();
            _bookRepo = new BookRepository();

            LoadFines();
            LoadBorrowingDropdown();
        }
        // loads all fines
        private void LoadFines()
        {
            try
            {
                _fines = _fineRepo.GetAll();

                dgvFines.DataSource = null;

                dgvFines.DataSource = _fines.Select(f => new
                {
                    f.Id,
                    Borrowing = GetBorrowingInfo(f.BorrowingId),
                    Student = GetStudentNameFromBorrowing(f.BorrowingId),
                    Book = GetBookTitleFromBorrowing(f.BorrowingId),
                    f.Amount,
                    f.FineDate,
                    f.Reason,
                    f.Status
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading fines: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // gets borrowing info text
        private string GetBorrowingInfo(int borrowingId)
        {
            var borrowing = _borrowingRepo.GetById(b => b.Id == borrowingId);
            if (borrowing != null)
            {
                return $"#{borrowingId} - {GetStudentName(borrowing.StudentId)} - {GetBookTitle(borrowing.BookId)}";
            }
            return $"#{borrowingId}";
        }

        // gets student name from borrowing
        private string GetStudentNameFromBorrowing(int borrowingId)
        {
            var borrowing = _borrowingRepo.GetById(b => b.Id == borrowingId);
            return borrowing != null ? GetStudentName(borrowing.StudentId) : "N/A";
        }

        // gets book title from borrowing
        private string GetBookTitleFromBorrowing(int borrowingId)
        {
            var borrowing = _borrowingRepo.GetById(b => b.Id == borrowingId);
            return borrowing != null ? GetBookTitle(borrowing.BookId) : "N/A";
        }

        // helper - gets student name
        private string GetStudentName(int studentId)
        {
            var student = _studentRepo.GetById(s => s.Id == studentId);
            return student != null ? $"{student.FirstName} {student.LastName}" : "N/A";
        }

        // helper - gets book title
        private string GetBookTitle(int bookId)
        {
            var book = _bookRepo.GetById(b => b.Id == bookId);
            return book != null ? book.Title : "N/A";
        }

        // loads borrowing records for dropdown
        private void LoadBorrowingDropdown()
        {
            try
            {
                // only show borrowings that are not returned or cancelled
                var borrowings = _borrowingRepo.GetAll()
                    .Where(b => b.Status != "Returned" && b.Status != "Cancelled")
                    .ToList();

                cmbBorrowing.DataSource = borrowings;
                cmbBorrowing.DisplayMember = "Id";
                cmbBorrowing.ValueMember = "Id";
                cmbBorrowing.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading borrowings: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // clears fields
        private void ClearFields()
        {
            txtID.Clear();
            cmbBorrowing.SelectedIndex = -1;
            txtAmount.Clear();
            dtpFineDate.Value = DateTime.Now;
            txtReason.Clear();
            cmbStatus.SelectedIndex = -1;
            txtID.Focus();
        }

        // add button
        private void lblAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // validate
                if (cmbBorrowing.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Borrowing Record.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBorrowing.Focus();
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
                    MessageBox.Show("Please select Payment Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                // check if fine already exists for this borrowing
                int borrowingId = (int)cmbBorrowing.SelectedValue;
                var existing = _fineRepo.GetById(f => f.BorrowingId == borrowingId);

                if (existing != null)
                {
                    MessageBox.Show("A fine already exists for this borrowing record.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // create new fine
                var fine = new Fine
                {
                    Id = _fines.Count > 0 ? _fines.Max(f => f.Id) + 1 : 1,
                    BorrowingId = borrowingId,
                    Amount = amount,
                    FineDate = dtpFineDate.Value,
                    Reason = txtReason.Text,
                    Status = cmbStatus.Text
                };

                _fineRepo.Add(fine);
                LoadFines();
                ClearFields();

                MessageBox.Show("Fine added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding fine: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // load selected record
        private void dgvFines_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFines.SelectedRows.Count > 0)
            {
                var selectedRow = dgvFines.SelectedRows[0];
                var fine = _fineRepo.GetById(f => f.Id == (int)selectedRow.Cells["Id"].Value);

                if (fine != null)
                {
                    txtID.Text = fine.Id.ToString();
                    cmbBorrowing.SelectedValue = fine.BorrowingId;
                    txtAmount.Text = fine.Amount.ToString();
                    dtpFineDate.Value = fine.FineDate;
                    txtReason.Text = fine.Reason;
                    cmbStatus.Text = fine.Status;
                }
            }
        }

        // update button
        private void lblUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a fine to update.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var fine = _fineRepo.GetById(f => f.Id == id);

                if (fine == null)
                {
                    MessageBox.Show("Fine not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbBorrowing.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Borrowing Record.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBorrowing.Focus();
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
                    MessageBox.Show("Please select Payment Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                // update fine
                fine.BorrowingId = (int)cmbBorrowing.SelectedValue;
                fine.Amount = amount;
                fine.FineDate = dtpFineDate.Value;
                fine.Reason = txtReason.Text;
                fine.Status = cmbStatus.Text;

                _fineRepo.Update(f => f.Id == id, fine);
                LoadFines();
                ClearFields();

                MessageBox.Show("Fine updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating fine: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // delete button
        private void lblDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a fine to delete.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var fine = _fineRepo.GetById(f => f.Id == id);

                if (fine == null)
                {
                    MessageBox.Show("Fine not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to delete this fine record?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _fineRepo.Delete(fine);
                    LoadFines();
                    ClearFields();

                    MessageBox.Show("Fine deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting fine: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            LoadFines();
            LoadBorrowingDropdown();
            ClearFields();
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchFines();
        }

        private void SearchFines()
        {
            try
            {
                string keyword = txtSearch.Text.ToLower();

                var filtered = _fines.Where(f =>
                    GetBorrowingInfo(f.BorrowingId).ToLower().Contains(keyword) ||
                    f.Status.ToLower().Contains(keyword) ||
                    f.Reason.ToLower().Contains(keyword)
                ).ToList();

                dgvFines.DataSource = null;
                dgvFines.DataSource = filtered.Select(f => new
                {
                    f.Id,
                    Borrowing = GetBorrowingInfo(f.BorrowingId),
                    Student = GetStudentNameFromBorrowing(f.BorrowingId),
                    Book = GetBookTitleFromBorrowing(f.BorrowingId),
                    f.Amount,
                    f.FineDate,
                    f.Reason,
                    f.Status
                }).ToList();
            }
            catch (Exception)
            {
                // ignore
            }
        }
    }
}
