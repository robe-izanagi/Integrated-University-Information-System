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
    public partial class CounselingManagementForm : Form
    {
        // repositories
        private readonly CounselingRepository _counselingRepo;
        private readonly StudentRepository _studentRepo;

        // holds all records and displayed list
        private List<Counseling> _counselingRecords;
        private List<Counseling> _displayedList;

        // columns available for sorting
        private readonly string[] _sortColumns = new string[]
        {
            "ID",
            "Student",
            "Counselor",
            "SessionDate",
            "SessionType",
            "Status"
        };

        public CounselingManagementForm()
        {
            InitializeComponent();

            // initialize repositories
            _counselingRepo = new CounselingRepository();
            _studentRepo = new StudentRepository();

            // load sort dropdowns
            SortHelper.LoadSortColumns(cmbSortColumn, _sortColumns);
            SortHelper.LoadSortOrders(cmbSortOrder);

            // load data
            LoadCounseling();
            LoadStudents();
        }

        // loads all counseling records from JSON
        private void LoadCounseling()
        {
            try
            {
                _counselingRecords = _counselingRepo.GetAll();
                _displayedList = _counselingRecords;
                DisplayCounseling(_displayedList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading counseling records: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // displays counseling records in DataGridView
        private void DisplayCounseling(List<Counseling> list)
        {
            dgvCounseling.DataSource = null;
            dgvCounseling.DataSource = list.Select(c => new
            {
                c.Id,
                Student = GetStudentName(c.StudentId),
                c.Counselor,
                c.SessionDate,
                c.SessionType,
                c.Concern,
                c.Notes,
                c.Recommendation,
                c.Status
            }).ToList();

            UpdateSummary();
        }

        // updates summary box with counts per session type
        private void UpdateSummary()
        {
            var list = _displayedList ?? _counselingRecords ?? new List<Counseling>();

            int individualCount = list.Count(c => c.SessionType == "Individual");
            int groupCount = list.Count(c => c.SessionType == "Group");
            int careerCount = list.Count(c => c.SessionType == "Career");
            int academicCount = list.Count(c => c.SessionType == "Academic");
            int personalCount = list.Count(c => c.SessionType == "Personal");
            int totalCount = list.Count;

            lblIndividualSummary.Text = individualCount.ToString("N0");
            lblGroupSummary.Text = groupCount.ToString("N0");
            lblCareerSummary.Text = careerCount.ToString("N0");
            lblAcademicSummary.Text = academicCount.ToString("N0");
            lblPersonalSummary.Text = personalCount.ToString("N0");
            lblTotalCounselingSummary.Text = totalCount.ToString("N0");
        }

        // applies sorting on current list
        private void ApplySort()
        {
            if (_counselingRecords == null) return;

            string sortColumn = cmbSortColumn.Text;
            string sortOrder = cmbSortOrder.Text;

            _displayedList = SortHelper.SortList(
                _counselingRecords,
                sortColumn,
                sortOrder,
                dgvCounseling,
                t => GetStudentName(t.StudentId)
            );

            DisplayCounseling(_displayedList);
        }

        // gets student name by ID
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

        // clears input fields
        private void ClearFields()
        {
            txtID.Clear();
            cmbStudent.SelectedIndex = -1;
            txtCounselor.Clear();
            dtpSessionDate.Value = DateTime.Now;
            cmbSessionType.SelectedIndex = -1;
            txtConcern.Clear();
            txtNotes.Clear();
            txtRecommendation.Clear();
            cmbStatus.SelectedIndex = -1;
            txtID.Focus();
        }

        // filters counseling records by keyword
        private void lblAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // validate required fields
                if (cmbStudent.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Student.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStudent.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCounselor.Text))
                {
                    MessageBox.Show("Please enter Counselor name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCounselor.Focus();
                    return;
                }

                if (cmbSessionType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Session Type.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSessionType.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtConcern.Text))
                {
                    MessageBox.Show("Please enter Concern.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConcern.Focus();
                    return;
                }

                if (cmbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                // create new counseling record
                var counseling = new Counseling
                {
                    Id = _counselingRecords.Count > 0 ? _counselingRecords.Max(c => c.Id) + 1 : 1,
                    StudentId = (int)cmbStudent.SelectedValue,
                    Counselor = txtCounselor.Text,
                    SessionDate = dtpSessionDate.Value,
                    SessionType = cmbSessionType.Text,
                    Concern = txtConcern.Text,
                    Notes = txtNotes.Text,
                    Recommendation = txtRecommendation.Text,
                    Status = cmbStatus.Text
                };

                _counselingRepo.Add(counseling);
                LoadCounseling();
                ClearFields();

                MessageBox.Show("Counseling session added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding counseling: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // loads selected row into fields
        private void dgvCounseling_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCounseling.SelectedRows.Count > 0)
            {
                var selectedRow = dgvCounseling.SelectedRows[0];
                var counseling = _counselingRepo.GetById(c => c.Id == (int)selectedRow.Cells["Id"].Value);

                if (counseling != null)
                {
                    txtID.Text = counseling.Id.ToString();
                    cmbStudent.SelectedValue = counseling.StudentId;
                    txtCounselor.Text = counseling.Counselor;
                    dtpSessionDate.Value = counseling.SessionDate;
                    cmbSessionType.Text = counseling.SessionType;
                    txtConcern.Text = counseling.Concern;
                    txtNotes.Text = counseling.Notes;
                    txtRecommendation.Text = counseling.Recommendation;
                    cmbStatus.Text = counseling.Status;
                }
            }
        }

        // updates counseling record
        private void lblUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a counseling record to update.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var counseling = _counselingRepo.GetById(c => c.Id == id);

                if (counseling == null)
                {
                    MessageBox.Show("Counseling record not found.", "Error",
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

                if (string.IsNullOrWhiteSpace(txtCounselor.Text))
                {
                    MessageBox.Show("Please enter Counselor name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCounselor.Focus();
                    return;
                }

                if (cmbSessionType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Session Type.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSessionType.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtConcern.Text))
                {
                    MessageBox.Show("Please enter Concern.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConcern.Focus();
                    return;
                }

                if (cmbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                // update counseling record
                counseling.StudentId = (int)cmbStudent.SelectedValue;
                counseling.Counselor = txtCounselor.Text;
                counseling.SessionDate = dtpSessionDate.Value;
                counseling.SessionType = cmbSessionType.Text;
                counseling.Concern = txtConcern.Text;
                counseling.Notes = txtNotes.Text;
                counseling.Recommendation = txtRecommendation.Text;
                counseling.Status = cmbStatus.Text;

                _counselingRepo.Update(c => c.Id == id, counseling);
                LoadCounseling();
                ClearFields();

                MessageBox.Show("Counseling record updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating counseling: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // cancels counseling session (soft delete)
        private void lblDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a counseling record to delete.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var counseling = _counselingRepo.GetById(c => c.Id == id);

                if (counseling == null)
                {
                    MessageBox.Show("Counseling record not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Cancel this counseling session?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // soft delete - set status to cancelled
                    counseling.Status = "Cancelled";
                    _counselingRepo.Update(c => c.Id == id, counseling);

                    LoadCounseling();
                    ClearFields();

                    MessageBox.Show("Counseling session cancelled.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cancelling counseling: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // clears fields
        private void lblClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // refreshes data and resets filters
        private void pbRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbSortColumn.SelectedIndex = 0;
            cmbSortOrder.SelectedIndex = 0;
            LoadCounseling();
            LoadStudents();
            ClearFields();
        }

        // triggers search
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchCounseling();
        }

        // filters counseling records by keyword
        private void SearchCounseling()
        {
            try
            {
                string keyword = txtSearch.Text.ToLower();

                var filtered = _counselingRecords.Where(c =>
                    GetStudentName(c.StudentId).ToLower().Contains(keyword) ||
                    c.Counselor.ToLower().Contains(keyword) ||
                    c.SessionType.ToLower().Contains(keyword) ||
                    c.Status.ToLower().Contains(keyword) ||
                    c.Concern.ToLower().Contains(keyword)
                ).ToList();

                _displayedList = filtered;

                // re-apply sort after search
                string sortColumn = cmbSortColumn.Text;
                string sortOrder = cmbSortOrder.Text;

                _displayedList = SortHelper.SortList(
                    _displayedList,
                    sortColumn,
                    sortOrder,
                    dgvCounseling,
                    t => GetStudentName(t.StudentId)
                );

                DisplayCounseling(_displayedList);
            }
            catch (Exception)
            {
                // ignore
            }
        }

        // triggers sort when sort column changes
        private void cmbSortColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySort();
        }

        // triggers sort when sort order changes
        private void cmbSortOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySort();
        }
    }
}
