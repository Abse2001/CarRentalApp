using CarRentalApp.Properties;

namespace CarRentalApp
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel leftPanel = null!;
        private Panel rightPanel = null!;
        private TextBox txtUsername = null!;
        private TextBox txtPassword = null!;
        private Label lblLoginTitle = null!;
        private Label lblUsername = null!;
        private Label lblPassword = null!;
        private Button btnLogin = null!;
        private Button btnSignUp = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            leftPanel = new Panel();
            rightPanel = new Panel();
            lblLoginTitle = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnSignUp = new Button();
            leftPanel.SuspendLayout();
            rightPanel.SuspendLayout();
            SuspendLayout();
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.FromArgb(45, 45, 48);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(200, 280);
            leftPanel.TabIndex = 1;
            // 
            // rightPanel
            // 
            rightPanel.BackColor = Color.White;
            rightPanel.Controls.Add(lblLoginTitle);
            rightPanel.Controls.Add(lblUsername);
            rightPanel.Controls.Add(txtUsername);
            rightPanel.Controls.Add(lblPassword);
            rightPanel.Controls.Add(txtPassword);
            rightPanel.Controls.Add(btnLogin);
            rightPanel.Controls.Add(btnSignUp);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(200, 0);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(300, 280);
            rightPanel.TabIndex = 0;
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.AutoSize = true;
            lblLoginTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblLoginTitle.Location = new Point(40, 20);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.Size = new Size(213, 25);
            lblLoginTitle.TabIndex = 0;
            lblLoginTitle.Text = "Welcome to Car Rental";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(40, 70);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(60, 15);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(40, 90);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(220, 23);
            txtUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(40, 130);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(40, 150);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(220, 23);
            txtPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 120, 215);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(40, 190);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(100, 35);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.Location = new Point(159, 190);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(100, 35);
            btnSignUp.TabIndex = 6;
            btnSignUp.Text = "Sign Up";
            btnSignUp.Click += BtnSignUp_Click;
            // 
            // LoginForm
            // 
            ClientSize = new Size(500, 280);
            Controls.Add(rightPanel);
            Controls.Add(leftPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginForm_Load;
            leftPanel.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            rightPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}
