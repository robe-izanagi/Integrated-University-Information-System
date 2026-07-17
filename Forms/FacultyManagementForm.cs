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
    public partial class FacultyManagementForm : Form
    {
        // repositories for reading and saving data
        private readonly FacultyRepository _facultyRepo;
        private readonly EmployeeRepository _employeeRepo;
        private List<Faculty> _facultyList;
        private List<Faculty> _displayedList;

        // sortable columns for this form
        private readonly string[] _sortColumns = new string[]
        {
            "ID",
            "Employee",
            "FacultyType",
            "Specialization",
            "SubjectsTaught",
            "YearsTeaching",
            "IsActive"
        };

        public FacultyManagementForm()
        {
            InitializeComponent();
            // set up repositories
            _facultyRepo = new FacultyRepository();
            _employeeRepo = new EmployeeRepository();

            // load sort dropdowns
            SortHelper.LoadSortColumns(cmbSortColumn, _sortColumns);
            SortHelper.LoadSortOrders(cmbSortOrder);

            // load faculty and employee dropdown
            LoadFaculty();
            LoadEmployeeDropdown();
        }


        // loads all faculty records from json
        private void LoadFaculty()
        {
            try
            {
                _facultyList = _facultyRepo.GetAll();
                _displayedList = _facultyList;
                DisplayFaculty(_displayedList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading faculty: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayFaculty(List<Faculty> list)
        {
            dgvFaculty.DataSource = null;
            dgvFaculty.DataSource = list.Select(f => new
            {
                f.Id,
                Employee = GetEmployeeName(f.EmployeeId),
                f.FacultyType,
                f.Specialization,
                f.SubjectsTaught,
                f.YearsTeaching,
                f.IsActive
            }).ToList();

            UpdateSummary();
        }

        // updates summary box with count per faculty type
        private void UpdateSummary()
        {
            var list = _displayedList ?? _facultyList ?? new List<Faculty>();

            int fullTimeCount = list.Count(f => f.FacultyType == "Full Time");
            int partTimeCount = list.Count(f => f.FacultyType == "Part Time");
            int guestCount = list.Count(f => f.FacultyType == "Guest Lecturer");
            int totalCount = list.Count;

            lblFullTimeSummary.Text = fullTimeCount.ToString("N0");
            lblPartTimeSummary.Text = partTimeCount.ToString("N0");
            lblGuestSummary.Text = guestCount.ToString("N0");
            lblTotalFacultySummary.Text = totalCount.ToString("N0");
        }

        // applies sorting on current list
        private void ApplySort()
        {
            if (_facultyList == null) return;

            string sortColumn = cmbSortColumn.Text;
            string sortOrder = cmbSortOrder.Text;

            _displayedList = SortHelper.SortList(
                _facultyList,
                sortColumn,
                sortOrder,
                dgvFaculty,
                t => GetEmployeeName(t.EmployeeId)
            );

            DisplayFaculty(_displayedList);
        }

        // helper method to get employee full name by ID
        private string GetEmployeeName(int employeeId)
        {
            var employee = _employeeRepo.GetById(emp => emp.Id == employeeId);
            return employee != null ? $"{employee.FirstName} {employee.LastName}" : "N/A";
        }

        // loads employee list into the combobox dropdown
        private void LoadEmployeeDropdown()
        {
            try
            {
                var employees = _employeeRepo.GetAll().Where(emp => emp.IsActive).ToList();

                cmbEmployee.DataSource = employees;
                cmbEmployee.DisplayMember = "FullName";
                cmbEmployee.ValueMember = "Id";
                cmbEmployee.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // clears all fields
        private void ClearFields()
        {
            txtID.Clear();
            cmbEmployee.SelectedIndex = -1;
            cmbFacultyType.SelectedIndex = -1;
            txtSpecialization.Clear();
            txtSubjectsTaught.Clear();
            numYearsTeaching.Value = 0;
            txtID.Focus();
        }

        // add button - creates a new faculty record
        private void lblAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // validate fields
                if (cmbEmployee.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an Employee.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbEmployee.Focus();
                    return;
                }

                if (cmbFacultyType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Faculty Type.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbFacultyType.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSpecialization.Text))
                {
                    MessageBox.Show("Please enter Specialization.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSpecialization.Focus();
                    return;
                }

                // check if employee is already a faculty member
                int employeeId = (int)cmbEmployee.SelectedValue;
                var existing = _facultyRepo.GetById(f => f.EmployeeId == employeeId);

                if (existing != null)
                {
                    MessageBox.Show("This employee is already a faculty member.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // create new faculty record
                var faculty = new Faculty
                {
                    Id = _facultyList.Count > 0 ? _facultyList.Max(f => f.Id) + 1 : 1,
                    EmployeeId = employeeId,
                    FacultyType = cmbFacultyType.Text,
                    Specialization = txtSpecialization.Text,
                    SubjectsTaught = txtSubjectsTaught.Text,
                    YearsTeaching = (int)numYearsTeaching.Value
                };

                _facultyRepo.Add(faculty);
                LoadFaculty();
                ClearFields();

                MessageBox.Show("Faculty record added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding faculty: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // when row is selected, load faculty details
        private void dgvFaculty_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFaculty.SelectedRows.Count > 0)
            {
                var selectedRow = dgvFaculty.SelectedRows[0];
                var faculty = _facultyRepo.GetById(f => f.Id == (int)selectedRow.Cells["Id"].Value);

                if (faculty != null)
                {
                    txtID.Text = faculty.Id.ToString();
                    cmbEmployee.SelectedValue = faculty.EmployeeId;
                    cmbFacultyType.Text = faculty.FacultyType;
                    txtSpecialization.Text = faculty.Specialization;
                    txtSubjectsTaught.Text = faculty.SubjectsTaught;
                    numYearsTeaching.Value = faculty.YearsTeaching;
                }
            }
        }

        // update button - saves changes
        private void lblUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a faculty record to update.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var faculty = _facultyRepo.GetById(f => f.Id == id);

                if (faculty == null)
                {
                    MessageBox.Show("Faculty record not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbEmployee.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an Employee.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbEmployee.Focus();
                    return;
                }

                if (cmbFacultyType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Faculty Type.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbFacultyType.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSpecialization.Text))
                {
                    MessageBox.Show("Please enter Specialization.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSpecialization.Focus();
                    return;
                }

                // update faculty object
                faculty.EmployeeId = (int)cmbEmployee.SelectedValue;
                faculty.FacultyType = cmbFacultyType.Text;
                faculty.Specialization = txtSpecialization.Text;
                faculty.SubjectsTaught = txtSubjectsTaught.Text;
                faculty.YearsTeaching = (int)numYearsTeaching.Value;

                _facultyRepo.Update(f => f.Id == id, faculty);
                LoadFaculty();
                ClearFields();

                MessageBox.Show("Faculty record updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating faculty: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // delete button - marks faculty as inactive
        private void lblDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a faculty record to delete.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var faculty = _facultyRepo.GetById(f => f.Id == id);

                if (faculty == null)
                {
                    MessageBox.Show("Faculty record not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to mark this faculty as inactive?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // soft delete - set to inactive
                    faculty.IsActive = false;
                    _facultyRepo.Update(f => f.Id == id, faculty);

                    LoadFaculty();
                    ClearFields();

                    MessageBox.Show("Faculty marked as inactive.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting faculty: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbSortColumn.SelectedIndex = 0;
            cmbSortOrder.SelectedIndex = 0;
            LoadFaculty();
            LoadEmployeeDropdown();
            ClearFields();
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchFaculty();
        }

        // search function
        private void SearchFaculty()
        {
            try
            {
                string keyword = txtSearch.Text.ToLower();

                var filtered = _facultyList.Where(f =>
                    GetEmployeeName(f.EmployeeId).ToLower().Contains(keyword) ||
                    f.FacultyType.ToLower().Contains(keyword) ||
                    f.Specialization.ToLower().Contains(keyword)
                ).ToList();

                _displayedList = filtered;

                // re-apply sort after search
                string sortColumn = cmbSortColumn.Text;
                string sortOrder = cmbSortOrder.Text;

                _displayedList = SortHelper.SortList(
                    _displayedList,
                    sortColumn,
                    sortOrder,
                    dgvFaculty,
                    t => GetEmployeeName(t.EmployeeId)
                );

                DisplayFaculty(_displayedList);
            }
            catch (Exception)
            {
                // ignore search errors
            }
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
