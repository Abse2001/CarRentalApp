using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class LoginForm : Form
    {

        private void TxtUsername_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void TxtPassword_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        public LoginForm()
        {
            InitializeComponent();
            txtUsername.KeyDown += TxtUsername_KeyDown;
            txtPassword.KeyDown += TxtPassword_KeyDown;
        }



        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // TODO: Replace with real login validation logic
            if (true)
            {
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sign up functionality not implemented.");
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void logoBox_Click(object sender, EventArgs e)
        {

        }
    }
}
