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
    public partial class AttendanceManagementForm : Form
    {
        // repositories for data
        private readonly AttendanceRepository _attendanceRepo;
        private readonly EmployeeRepository _employeeRepo;
        private List<Attendance> _attendanceRecords;
        public AttendanceManagementForm()
        {
            InitializeComponent();
            _attendanceRepo = new AttendanceRepository();
            _employeeRepo = new EmployeeRepository();

            LoadAttendance();
            LoadEmployeeDropdown();
        }

        // loads all attendance records
        private void LoadAttendance()
        {
            try
            {
                _attendanceRecords = _attendanceRepo.GetAll();

                dgvAttendance.DataSource = null;

                dgvAttendance.DataSource = _attendanceRecords.Select(a => new
                {
                    a.Id,
                    Employee = GetEmployeeName(a.EmployeeId),
                    a.Date,
                    a.TimeIn,
                    a.TimeOut,
                    a.Status,
                    a.Remarks
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading attendance: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // helper - gets employee name
        private string GetEmployeeName(int employeeId)
        {
            var employee = _employeeRepo.GetById(emp => emp.Id == employeeId);
            return employee != null ? $"{employee.FirstName} {employee.LastName}" : "N/A";
        }

        // loads employees for dropdown
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

        // clears fields
        private void ClearFields()
        {
            txtID.Clear();
            cmbEmployee.SelectedIndex = -1;
            dtpDate.Value = DateTime.Now;
            dtpTimeIn.Value = DateTime.Now;
            dtpTimeOut.Value = DateTime.Now;
            cmbStatus.SelectedIndex = -1;
            txtRemarks.Clear();
            txtID.Focus();
        }

        // add button
        private void lblAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // validation
                if (cmbEmployee.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an Employee.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbEmployee.Focus();
                    return;
                }

                if (cmbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                // check if attendance already exists for this employee on this date
                int employeeId = (int)cmbEmployee.SelectedValue;
                DateTime selectedDate = dtpDate.Value.Date;

                var existing = _attendanceRepo.GetById(a =>
                    a.EmployeeId == employeeId && a.Date.Date == selectedDate);

                if (existing != null)
                {
                    MessageBox.Show("Attendance already recorded for this employee on this date.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // combine date and time
                DateTime timeIn = dtpDate.Value.Date + dtpTimeIn.Value.TimeOfDay;
                DateTime timeOut = dtpDate.Value.Date + dtpTimeOut.Value.TimeOfDay;

                // create new attendance record
                var attendance = new Attendance
                {
                    Id = _attendanceRecords.Count > 0 ? _attendanceRecords.Max(a => a.Id) + 1 : 1,
                    EmployeeId = employeeId,
                    Date = dtpDate.Value,
                    TimeIn = timeIn,
                    TimeOut = timeOut,
                    Status = cmbStatus.Text,
                    Remarks = txtRemarks.Text
                };

                _attendanceRepo.Add(attendance);
                LoadAttendance();
                ClearFields();

                MessageBox.Show("Attendance recorded successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding attendance: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // load selected record
        private void dgvAttendance_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAttendance.SelectedRows.Count > 0)
            {
                var selectedRow = dgvAttendance.SelectedRows[0];
                var attendance = _attendanceRepo.GetById(a => a.Id == (int)selectedRow.Cells["Id"].Value);

                if (attendance != null)
                {
                    txtID.Text = attendance.Id.ToString();
                    cmbEmployee.SelectedValue = attendance.EmployeeId;
                    dtpDate.Value = attendance.Date;
                    dtpTimeIn.Value = attendance.TimeIn;
                    dtpTimeOut.Value = attendance.TimeOut;
                    cmbStatus.Text = attendance.Status;
                    txtRemarks.Text = attendance.Remarks;
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
                    MessageBox.Show("Please select an attendance record to update.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var attendance = _attendanceRepo.GetById(a => a.Id == id);

                if (attendance == null)
                {
                    MessageBox.Show("Attendance record not found.", "Error",
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

                if (cmbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                // combine date and time
                DateTime timeIn = dtpDate.Value.Date + dtpTimeIn.Value.TimeOfDay;
                DateTime timeOut = dtpDate.Value.Date + dtpTimeOut.Value.TimeOfDay;

                // update attendance object
                attendance.EmployeeId = (int)cmbEmployee.SelectedValue;
                attendance.Date = dtpDate.Value;
                attendance.TimeIn = timeIn;
                attendance.TimeOut = timeOut;
                attendance.Status = cmbStatus.Text;
                attendance.Remarks = txtRemarks.Text;

                _attendanceRepo.Update(a => a.Id == id, attendance);
                LoadAttendance();
                ClearFields();

                MessageBox.Show("Attendance updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating attendance: {ex.Message}", "Error",
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
                    MessageBox.Show("Please select an attendance record to delete.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var attendance = _attendanceRepo.GetById(a => a.Id == id);

                if (attendance == null)
                {
                    MessageBox.Show("Attendance record not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to delete this attendance record?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _attendanceRepo.Delete(attendance);
                    LoadAttendance();
                    ClearFields();

                    MessageBox.Show("Attendance record deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting attendance: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            LoadAttendance();
            LoadEmployeeDropdown();
            ClearFields();
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        //serach
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchAttendance();
        }

        private void SearchAttendance()
        {
            try
            {
                string keyword = txtSearch.Text.ToLower();

                var filtered = _attendanceRecords.Where(a =>
                    GetEmployeeName(a.EmployeeId).ToLower().Contains(keyword) ||
                    a.Status.ToLower().Contains(keyword) ||
                    a.Date.ToString("MM/dd/yyyy").Contains(keyword)
                ).ToList();

                dgvAttendance.DataSource = null;
                dgvAttendance.DataSource = filtered.Select(a => new
                {
                    a.Id,
                    Employee = GetEmployeeName(a.EmployeeId),
                    a.Date,
                    a.TimeIn,
                    a.TimeOut,
                    a.Status,
                    a.Remarks
                }).ToList();
            }
            catch (Exception)
            {
                // ignore
            }
        }
    }
}
