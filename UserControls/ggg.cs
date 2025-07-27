//using CarRentalApp.Helpers;
//using CarRentalApp.Models;
//using CarRentalApp.Services; // Assuming you have UserService here
//using System;
//using System.Windows.Forms;

//namespace CarRentalApp.UserControls
//{
//    public partial class ggg : UserControl
//    {
//        private readonly UserService _userService;

//        public ggg(UserService userService)
//        {
//            InitializeComponent();
//            _userService = userService;

//            btnSubmit.Click += BtnSubmit_Click;
//            btnCancel.Click += BtnCancel_Click;
//        }

//        private void BtnSubmit_Click(object? sender, EventArgs e)
//        {
//            try
//            {
//                // Basic validation
//                if (string.IsNullOrWhiteSpace(txtUsername.Text))
//                {
//                    MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                if (string.IsNullOrWhiteSpace(txtPassword.Text))
//                {
//                    MessageBox.Show("Password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                if (string.IsNullOrWhiteSpace(txtFirstName.Text))
//                {
//                    MessageBox.Show("First name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                if (string.IsNullOrWhiteSpace(txtLastName.Text))
//                {
//                    MessageBox.Show("Last name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                if (cmbRole.SelectedIndex < 0)
//                {
//                    MessageBox.Show("Please select a role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                // Create new User object
//                var newUser = new User
//                {
//                    Username = txtUsername.Text.Trim(),
//                    PasswordHash = PasswordHelper.HashPassword(txtPassword.Text), // Assuming PasswordHelper available
//                    FirstName = txtFirstName.Text.Trim(),
//                    LastName = txtLastName.Text.Trim(),
//                    UserRole = (User.Role)cmbRole.SelectedIndex,
//                    Balance = 0,
//                    DateCreated = DateTime.UtcNow,
//                    IsLocked = false
//                };

//                // Add user - assuming adminId = 1 for example
//                _userService.AddUser(newUser, adminId: 1);

//                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                ClearForm();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Failed to add user. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void BtnCancel_Click(object? sender, EventArgs e)
//        {
//            ClearForm();
//        }

//        private void ClearForm()
//        {
//            txtUsername.Clear();
//            txtPassword.Clear();
//            txtFirstName.Clear();
//            txtLastName.Clear();
//            cmbRole.SelectedIndex = -1;
//        }
//    }
//}
