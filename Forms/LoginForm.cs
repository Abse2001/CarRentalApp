    using CarRentalApp.DAL;
    using CarRentalApp.Forms;
    using CarRentalApp.Models;
    using CarRentalApp.Services;
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    namespace CarRentalApp
    {
        public partial class LoginForm : Form
        {
            private bool dragging = false;
            private Point dragCursorPoint;
            private Point dragFormPoint;
            private readonly UserService _userService;
            private readonly ActivityServices _activityService;

            public LoginForm()
            {
                InitializeComponent();
                this.FormBorderStyle = FormBorderStyle.None;

                // Initialize UserService with UserRepository
                _userService = new UserService(new UserManagment());
                _activityService = new ActivityServices();

                AttachDragHandlers(this);
                txtUsername.KeyDown += TxtUsername_KeyDown;
                txtPassword.KeyDown += TxtPassword_KeyDown;
            }

            private void AttachDragHandlers(Control control)
            {
                control.MouseDown += LoginForm_MouseDown;
                control.MouseMove += LoginForm_MouseMove;
                control.MouseUp += LoginForm_MouseUp;

                foreach (Control child in control.Controls)
                {
                    AttachDragHandlers(child);
                }
            }

            private void LoginForm_Load(object sender, EventArgs e)
            {
                PictureBox logoBox = new PictureBox();
                string logoPath = Path.Combine(Application.StartupPath, @"..\..\..\Assets\Logo.png");

                if (File.Exists(logoPath))
                {
                    logoBox.Image = Image.FromFile(logoPath);
                    logoBox.SizeMode = PictureBoxSizeMode.Zoom;
                    logoBox.Size = new Size(150, 150); // Bigger logo size
                    logoBox.Location = new Point(
                        leftPanel.Width / 2 - logoBox.Width / 2,
                        leftPanel.Height / 2 - logoBox.Height / 2
                    );
                    logoBox.Anchor = AnchorStyles.None;
                    leftPanel.Controls.Add(logoBox);
                }
            }

            private void TxtUsername_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPassword.Focus();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }

            private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnLogin.PerformClick();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Username is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Password is required.");
                return;
            }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                User user = _userService.Login(username, password);

                if (user == null)
                {
                    errorProvider1.SetError(txtPassword, "Invalid username or password.");
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                this.Hide();
                AppCtx.CurrentUser = user;
                using (var mainForm = new MainForm(user, new UserManagment()))
                {
                    mainForm.ShowDialog();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToLower();

                if (msg.Contains("locked"))
                {
                    // Account is locked — show in error provider
                    errorProvider1.SetError(txtPassword, ex.Message);
                }
                else
                {
                    // Other errors
                    MessageBox.Show("Login failed: " + ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider1.SetError(txtPassword, ex.Message);
                }

                txtPassword.Clear();
                txtPassword.Focus();
            }
        }






        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }

            private void LoginForm_MouseMove(object sender, MouseEventArgs e)
            {
                if (dragging)
                {
                    Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                    this.Location = Point.Add(dragFormPoint, new Size(diff));
                }
            }

            private void LoginForm_MouseUp(object sender, MouseEventArgs e)
            {
                dragging = false;
            }

            private void leftPanel_Paint(object sender, PaintEventArgs e) { }
            private void logoBox_Click(object sender, EventArgs e) { }
            private void rightPanel_Paint(object sender, PaintEventArgs e) { }

            private void btnExit_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            // Override ProcessCmdKey to prevent beep on Enter key globally
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                if (keyData == Keys.Enter)
                {
                    btnLogin.PerformClick();
                    return true; // Indicate key handled, prevent beep
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
    }
