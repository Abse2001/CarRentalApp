using CarRentalApp.Models;
using CarRentalApp.Services;
using System;
using System.Windows.Forms;

namespace CarRentalApp.UserControls
{
    public partial class LogActivityControl : UserControl
    {
        private readonly ActivityServices _activityLogService;
        private readonly User _currentUser;

        public LogActivityControl(User currentUser, ActivityServices activityLogService)
        {
            InitializeComponent();

            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            _activityLogService = activityLogService ?? throw new ArgumentNullException(nameof(activityLogService));

            InitializeDataGridView();
            LoadActivityLogs();
        }

        private void InitializeDataGridView()
        {
            dgvActivityLogs.Columns.Clear();

            dgvActivityLogs.Columns.Add("Id", "ID");
            dgvActivityLogs.Columns.Add("UserId", "User ID");
            dgvActivityLogs.Columns.Add("Username", "Username");
            dgvActivityLogs.Columns.Add("Activity", "Activity");
            dgvActivityLogs.Columns.Add("Timestamp", "Timestamp");

            dgvActivityLogs.Columns["Id"].Visible = false; // Hide internal ID column

            dgvActivityLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvActivityLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvActivityLogs.MultiSelect = false;
            dgvActivityLogs.AllowUserToAddRows = false;
            dgvActivityLogs.ReadOnly = true;

            dgvActivityLogs.Columns["Timestamp"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
        }

        private void LoadActivityLogs()
        {
            dgvActivityLogs.Rows.Clear();

            var logs = _activityLogService.GetAllLogs();

            foreach (var log in logs)
            {
                dgvActivityLogs.Rows.Add(
                    log.Id,
                    log.UserId,
                    log.Username,
                    log.Activity,
                    log.Timestamp.ToLocalTime()
                );
            }
        }
    }
}
