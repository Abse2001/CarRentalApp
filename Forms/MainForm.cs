using CarRentalApp.DAL;
using CarRentalApp.Forms;
using CarRentalApp.Models;
using CarRentalApp.Services;
using CarRentalApp.UserControls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class MainForm : Form
    {
        private ContextMenuStrip profileMenu;
        private readonly UserService _userService;
        private readonly CarService _carService;
        private readonly User _currentUser;
        private readonly ActivityServices _activityServices;

        public MainForm(User user, UserManagment userRepo)
        {
            InitializeComponent();

            _currentUser = user ?? throw new ArgumentNullException(nameof(user));

            _userService = new UserService(new UserManagment());
            _carService = new CarService(new CarManagment());
            _activityServices = new ActivityServices();

            UpdateProfileButton();
            UpdateBalanceButton();
            InitializeProfileMenu(user);

            btnInbox.Visible = _currentUser.UserRole == User.Role.Admin;

            BtnHome_Click(null, EventArgs.Empty);
        }


        private void BtnInbox_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            var inboxControl = new MessageInboxControl();
            inboxControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(inboxControl);
        }

        private void UpdateBalanceButton()
        {
            decimal balance = AppCtx.CurrentUser.Balance;
            string display;

            if (balance >= 1000)
            {
                display = $"Balance: ${(balance / 1000):0.##}K";
            }
            else
            {
                display = $"Balance: ${balance:F2}";
            }

            btnBalance.Text = display;
        }

        private void UpdateProfileButton()
        {
            btnProfile.Text = _currentUser.Username;
        }

        private void InitializeProfileMenu(User user)
        {
            profileMenu = new ContextMenuStrip();

            if (_currentUser.UserRole == User.Role.Admin)
            {
                // Users Management
                var usersMgmtItem = new ToolStripMenuItem("Users Management");
                usersMgmtItem.Click += (s, e) =>
                {
                    panelMain.Controls.Clear();
                    // <-- Pass 'this' instead of 'mainForm'
                    var usersManagementControl = new UsersManagment(this, _currentUser, _userService);
                    usersManagementControl.Dock = DockStyle.Fill;
                    panelMain.Controls.Add(usersManagementControl);
                };
                profileMenu.Items.Add(usersMgmtItem);

                // Car Management
                var carManagementItem = new ToolStripMenuItem("Car Management");
                carManagementItem.Click += (s, e) =>
                {
                    panelMain.Controls.Clear();
                    var carManagementControl = new CarsManagment(_carService, _currentUser);
                    carManagementControl.Dock = DockStyle.Fill;
                    panelMain.Controls.Add(carManagementControl);
                };
                profileMenu.Items.Add(carManagementItem);

                // Activity Logs (Admin only)
                var activityLogsItem = new ToolStripMenuItem("Activity Logs");
                activityLogsItem.Click += (s, e) =>
                {
                    panelMain.Controls.Clear();
                    var logActivityControl = new LogActivityControl(_currentUser, _activityServices);
                    logActivityControl.Dock = DockStyle.Fill;
                    panelMain.Controls.Add(logActivityControl);
                };
                profileMenu.Items.Add(activityLogsItem);
            }
            var contactUs = new ToolStripMenuItem("Contact Us");
            contactUs.Click += (s, e) =>
            {
                panelMain.Controls.Clear();
                var contactControl = new ContactUsControl(_currentUser);
                contactControl.Dock = DockStyle.Fill;
                panelMain.Controls.Add(contactControl);
            };
            profileMenu.Items.Add(contactUs);

            btnProfile.Click += (s, e) =>
            {
                profileMenu.Show(btnProfile, new Point(0, btnProfile.Height));
            };
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            Hide();
            using (var loginForm = new LoginForm())
            {
                loginForm.ShowDialog();
            }
            Close();
        }

        private void BtnHome_Click(object? sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            var homeControl = new HomeControl(_carService, _currentUser.Username);
            homeControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(homeControl);
        }

        private void Btn_Cars_Click(object? sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            var carsControl = new CarsControl(_carService, _currentUser, RefreshUserBalance);
            carsControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(carsControl);
        }

        private void btnBooking_Click(object? sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            var carBookings = new CarBookings();
            carBookings.Dock = DockStyle.Fill;
            panelMain.Controls.Add(carBookings);
        }

        public void RefreshUserBalance()
        {
            var updatedUser = _userService.GetUserById(_currentUser.Id);
            if (updatedUser != null)
            {
                _currentUser.Balance = updatedUser.Balance;
                UpdateBalanceButton();
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            var aboutControl = new AboutControl();
            aboutControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(aboutControl);
        }

        private void btnCustomerList_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            var customersListControl = new CustomersList();
            customersListControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(customersListControl);
        }
    }
}
