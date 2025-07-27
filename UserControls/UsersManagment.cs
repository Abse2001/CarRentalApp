using CarRentalApp.Forms;
using CarRentalApp.Models;
using CarRentalApp.Services;
using System;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class UsersManagment : UserControl
    {
        private readonly UserService _userService;
        private readonly User _currentUser;
        private MainForm _mainForm;

        public UsersManagment(MainForm mainForm,User currentUser, UserService userService)
        {
            InitializeComponent();
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _currentUser = currentUser;
            _mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));
            InitializeDataGridView();
            LoadUsers();
        }

        private void InitializeDataGridView()
        {
            dgvUsers.Columns.Clear();

            dgvUsers.Columns.Add("UserId", "ID");
            dgvUsers.Columns.Add("Username", "Username");
            dgvUsers.Columns.Add("FullName", "Full Name");
            dgvUsers.Columns.Add("Email", "Email"); // Placeholder
            dgvUsers.Columns.Add("Balance", "Balance ($)");
            dgvUsers.Columns.Add("UserRole", "Role");
            dgvUsers.Columns.Add("Status", "Status");

            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.ReadOnly = true;
        }

        private void LoadUsers()
        {
            dgvUsers.Rows.Clear();

            var users = _userService.GetAllUsers();

            foreach (var user in users)
            {
                dgvUsers.Rows.Add(
                    user.Id,
                    user.Username,
                    $"{user.FirstName} {user.LastName}".Trim(),
                    "", // Email placeholder
                    user.Balance.ToString("F2"),
                    user.UserRole.ToString(),
                    user.IsLocked ? "Locked" : "Active"
                );
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var addUserForm = new AddNewUser(_userService);
            addUserForm.StartPosition = FormStartPosition.CenterScreen;
            if (addUserForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit.", "Edit User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserId"].Value);
            var user = _userService.GetUserById(userId);

            if (user == null)
            {
                MessageBox.Show("Selected user not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            var editForm = new AddNewUser(_userService, user, _mainForm);
            editForm.StartPosition = FormStartPosition.CenterScreen;
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserId"].Value);
            User userToBeDeleted = _userService.GetUserById(userId);

            var confirm = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool success = _userService.DeleteUser(_currentUser,userToBeDeleted);
                if (success)
                    LoadUsers();
                else
                    MessageBox.Show("Failed to delete the user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
