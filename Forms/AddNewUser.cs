using CarRentalApp.Services;
using CarRentalApp.Models;
using CarRentalApp.Forms;
using System;
using System.Drawing;
using System.Linq;

namespace CarRentalApp.Forms
{
    public partial class AddNewUser : Form
    {
        private readonly UserService _userService;
        private readonly bool _isEditMode;
        private readonly User _editingUser;
        private readonly User _currentUser;
        private MainForm _mainForm;

        public AddNewUser(UserService userService)
        {
            InitializeComponent();
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _isEditMode = false;
            _currentUser = AppCtx.CurrentUser;
        }

        public AddNewUser(UserService userService, User userToEdit, MainForm mainForm) : this(userService)
        {
            _isEditMode = true;
            _editingUser = userToEdit;
            _mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));

            txtUsername.Text = _editingUser.Username;
            txtFullName.Text = $"{_editingUser.FirstName} {_editingUser.LastName}".Trim();
            cmbRole.SelectedItem = _editingUser.UserRole.ToString();

            lblPassword.Text = "Balance ($):";
            txtPassword.Text = "0";
            txtPassword.PasswordChar = '\0';
            txtPassword.Enabled = true;
            txtPassword.Visible = true;

            btnAdd.Text = "Update";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string fullName = txtFullName.Text.Trim();
                string roleText = cmbRole.SelectedItem?.ToString() ?? "User";
                string passwordOrBalance = txtPassword.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(passwordOrBalance))
                {
                    MessageBox.Show("Please fill all required fields.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (username.Length < 4)
                {
                    MessageBox.Show("Username must be at least 4 characters long.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var fullNameParts = fullName.Split(' ');
                if (fullNameParts.Length < 2 || string.IsNullOrWhiteSpace(fullNameParts[0]) || string.IsNullOrWhiteSpace(fullNameParts[1]))
                {
                    MessageBox.Show("Full name must include first and last names separated by a space.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string firstName = fullNameParts[0];
                string lastName = string.Join(" ", fullNameParts.Skip(1));

                if (!Enum.TryParse<User.Role>(roleText, out var role))
                    role = User.Role.User;

                if (_isEditMode)
                {
                    MessageBox.Show($"CurrentUser ID: {_currentUser.Id}\nEditingUser ID: {_editingUser.Id}", "Debug IDs");

                    // ✅ Prevent admin from editing other admins
                    if (_currentUser.UserRole == User.Role.Admin &&
                        _editingUser.UserRole == User.Role.Admin &&
                        _currentUser.Id != _editingUser.Id)
                    {
                        MessageBox.Show("You cannot edit other admins' accounts.", "Access Denied",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!decimal.TryParse(passwordOrBalance, out var delta))
                    {
                        MessageBox.Show("Invalid balance format.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var newBalance = _editingUser.Balance + delta;
                    if (newBalance < 0)
                        newBalance = 0;

                    _editingUser.Username = username;
                    _editingUser.FirstName = firstName;
                    _editingUser.LastName = lastName;
                    _editingUser.UserRole = role;
                    _editingUser.Balance = newBalance;

                    _userService.UpdateUser(_currentUser, _editingUser);

                    // ✅ Refetch if editing yourself
                    if (_currentUser.Id == _editingUser.Id)
                    {
                        var refreshed = _userService.GetUserById(_currentUser.Id);
                        if (refreshed != null)
                        {
                            AppCtx.CurrentUser = refreshed;
                            _mainForm.RefreshUserBalance();
                        }
                    }

                    MessageBox.Show("User updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    string password = passwordOrBalance;

                    if (password.Length < 8)
                    {
                        MessageBox.Show("Password must be at least 8 characters long.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var newUser = new User
                    {
                        Username = username,
                        FirstName = firstName,
                        LastName = lastName,
                        PasswordHash = password,
                        UserRole = role,
                        Balance = 0,
                        DateCreated = DateTime.UtcNow
                    };

                    _userService.AddUser(_currentUser, newUser);

                    MessageBox.Show("User added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving user:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
