using System;
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

        public LoginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

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
            string logoPath = Path.Combine(Application.StartupPath, "Logo.png");

            if (File.Exists(logoPath))
            {
                logoBox.Image = Image.FromFile(logoPath);
                logoBox.SizeMode = PictureBoxSizeMode.Zoom;
                logoBox.Size = new Size(120, 120);
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

            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
            this.Close();
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sign up functionality not implemented.");
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

        private void rightPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
