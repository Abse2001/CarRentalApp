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
        private Button btnExit = null!;  // <-- new exit button

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            leftPanel = new Panel();
            rightPanel = new Panel();
            lblLoginTitle = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            errorProvider1 = new ErrorProvider(components);
            rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.FromArgb(45, 45, 48);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(250, 350);
            leftPanel.TabIndex = 1;
            leftPanel.Paint += leftPanel_Paint;
            // 
            // rightPanel
            // 
            rightPanel.BackColor = Color.FromArgb(45, 45, 48);
            rightPanel.Controls.Add(lblLoginTitle);
            rightPanel.Controls.Add(lblUsername);
            rightPanel.Controls.Add(txtUsername);
            rightPanel.Controls.Add(lblPassword);
            rightPanel.Controls.Add(txtPassword);
            rightPanel.Controls.Add(btnLogin);
            rightPanel.Controls.Add(btnExit);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(250, 0);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(350, 350);
            rightPanel.TabIndex = 0;
            rightPanel.Paint += rightPanel_Paint;
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.AutoSize = true;
            lblLoginTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblLoginTitle.ForeColor = Color.Snow;
            lblLoginTitle.Location = new Point(40, 20);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.Size = new Size(274, 32);
            lblLoginTitle.TabIndex = 0;
            lblLoginTitle.Text = "Welcome to Car Rental";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.ForeColor = SystemColors.Control;
            lblUsername.Location = new Point(40, 75);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(60, 15);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(40, 100);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(270, 29);
            txtUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = SystemColors.Control;
            lblPassword.Location = new Point(40, 145);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(40, 170);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(270, 29);
            txtPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 120, 215);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(40, 220);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(130, 40);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(232, 17, 35);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(180, 220);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(130, 40);
            btnExit.TabIndex = 6;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // LoginForm
            // 
            ClientSize = new Size(600, 350);
            Controls.Add(rightPanel);
            Controls.Add(leftPanel);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginForm_Load;
            rightPanel.ResumeLayout(false);
            rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        private ErrorProvider errorProvider1;
    }
}
