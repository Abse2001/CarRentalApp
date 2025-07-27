using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp.UserControls
{
    public partial class LogActivityControl : UserControl
    {
        private Label headerLabel;
        private DataGridView dgvActivityLogs;
        private FlowLayoutPanel buttonsPanel;



        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            headerLabel = new Label();
            dgvActivityLogs = new DataGridView();
            buttonsPanel = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dgvActivityLogs).BeginInit();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.Dock = DockStyle.Top;
            headerLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            headerLabel.ForeColor = Color.White;
            headerLabel.Location = new Point(0, 0);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(970, 50);
            headerLabel.TabIndex = 2;
            headerLabel.Text = "Activity Logs";
            headerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvActivityLogs
            // 
            dgvActivityLogs.AllowUserToAddRows = false;
            dgvActivityLogs.AllowUserToDeleteRows = false;
            dgvActivityLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvActivityLogs.BackgroundColor = Color.FromArgb(35, 35, 35);
            dgvActivityLogs.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvActivityLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 45);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvActivityLogs.DefaultCellStyle = dataGridViewCellStyle2;
            dgvActivityLogs.Dock = DockStyle.Fill;
            dgvActivityLogs.Location = new Point(0, 50);
            dgvActivityLogs.MultiSelect = false;
            dgvActivityLogs.Name = "dgvActivityLogs";
            dgvActivityLogs.ReadOnly = true;
            dgvActivityLogs.RowHeadersVisible = false;
            dgvActivityLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvActivityLogs.Size = new Size(970, 481);
            dgvActivityLogs.TabIndex = 0;
            // 
            // buttonsPanel
            // 
            buttonsPanel.BackColor = Color.FromArgb(40, 40, 40);
            buttonsPanel.Dock = DockStyle.Bottom;
            buttonsPanel.FlowDirection = FlowDirection.RightToLeft;
            buttonsPanel.Location = new Point(0, 531);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Padding = new Padding(10);
            buttonsPanel.Size = new Size(970, 50);
            buttonsPanel.TabIndex = 1;
            // 
            // LogActivityControl
            // 
            Controls.Add(dgvActivityLogs);
            Controls.Add(buttonsPanel);
            Controls.Add(headerLabel);
            Name = "LogActivityControl";
            Size = new Size(970, 581);
            ((System.ComponentModel.ISupportInitialize)dgvActivityLogs).EndInit();
            ResumeLayout(false);
        }

        private void ApplyTheme()
        {
            BackColor = Color.FromArgb(30, 30, 30);
        }

        private void LoadDummyData()
        {
            dgvActivityLogs.Columns.Clear();
            dgvActivityLogs.Columns.Add("Id", "ID");
            dgvActivityLogs.Columns.Add("UserId", "User ID");
            dgvActivityLogs.Columns.Add("Username", "Username");
            dgvActivityLogs.Columns.Add("Activity", "Activity");
            dgvActivityLogs.Columns.Add("Timestamp", "Timestamp");

            // Example dummy data
            dgvActivityLogs.Rows.Add(1, 10, "jdoe", "Created a new rental", DateTime.UtcNow.ToString("u"));
            dgvActivityLogs.Rows.Add(2, 15, "asmith", "Deleted a user", DateTime.UtcNow.AddMinutes(-30).ToString("u"));
            dgvActivityLogs.Rows.Add(3, 10, "jdoe", "Updated car details", DateTime.UtcNow.AddHours(-1).ToString("u"));
        }

        // Event handlers for buttons (implement as needed)
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Log clicked");
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edit Log clicked");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete Log clicked");
        }
    }
}
