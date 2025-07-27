//namespace CarRentalApp.UserControls
//{
//    partial class ggg
//    {
//        private System.ComponentModel.IContainer components = null;

//        private System.Windows.Forms.Label lblUsername;
//        private System.Windows.Forms.TextBox txtUsername;
//        private System.Windows.Forms.Label lblPassword;
//        private System.Windows.Forms.TextBox txtPassword;
//        private System.Windows.Forms.Label lblFirstName;
//        private System.Windows.Forms.TextBox txtFirstName;
//        private System.Windows.Forms.Label lblLastName;
//        private System.Windows.Forms.TextBox txtLastName;
//        private System.Windows.Forms.Label lblRole;
//        private System.Windows.Forms.ComboBox cmbRole;

//        private System.Windows.Forms.Button btnSubmit;
//        private System.Windows.Forms.Button btnCancel;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//                components.Dispose();
//            base.Dispose(disposing);
//        }

//        #region Component Designer generated code

//        private void InitializeComponent()
//        {
//            components = new System.ComponentModel.Container();

//            lblUsername = new System.Windows.Forms.Label();
//            txtUsername = new System.Windows.Forms.TextBox();

//            lblPassword = new System.Windows.Forms.Label();
//            txtPassword = new System.Windows.Forms.TextBox();

//            lblFirstName = new System.Windows.Forms.Label();
//            txtFirstName = new System.Windows.Forms.TextBox();

//            lblLastName = new System.Windows.Forms.Label();
//            txtLastName = new System.Windows.Forms.TextBox();

//            lblRole = new System.Windows.Forms.Label();
//            cmbRole = new System.Windows.Forms.ComboBox();

//            btnSubmit = new System.Windows.Forms.Button();
//            btnCancel = new System.Windows.Forms.Button();

//            SuspendLayout();

//            // Set dark background for the whole control
//            BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
//            ForeColor = System.Drawing.Color.White;

//            // 
//            // lblUsername
//            // 
//            lblUsername.AutoSize = true;
//            lblUsername.Location = new System.Drawing.Point(25, 20);
//            lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
//            lblUsername.Name = "lblUsername";
//            lblUsername.Size = new System.Drawing.Size(75, 19);
//            lblUsername.Text = "Username:";
//            // 
//            // txtUsername
//            // 
//            txtUsername.Location = new System.Drawing.Point(120, 18);
//            txtUsername.Name = "txtUsername";
//            txtUsername.Size = new System.Drawing.Size(220, 25);
//            txtUsername.BackColor = Color.FromArgb(45, 45, 48);
//            txtUsername.ForeColor = Color.White;
//            txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//            txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);

//            // 
//            // lblPassword
//            // 
//            lblPassword.AutoSize = true;
//            lblPassword.Location = new System.Drawing.Point(25, 60);
//            lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
//            lblPassword.Name = "lblPassword";
//            lblPassword.Size = new System.Drawing.Size(69, 19);
//            lblPassword.Text = "Password:";
//            // 
//            // txtPassword
//            // 
//            txtPassword.Location = new System.Drawing.Point(120, 58);
//            txtPassword.Name = "txtPassword";
//            txtPassword.Size = new System.Drawing.Size(220, 25);
//            txtPassword.BackColor = Color.FromArgb(45, 45, 48);
//            txtPassword.ForeColor = Color.White;
//            txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//            txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
//            txtPassword.UseSystemPasswordChar = true;

//            // 
//            // lblFirstName
//            // 
//            lblFirstName.AutoSize = true;
//            lblFirstName.Location = new System.Drawing.Point(25, 100);
//            lblFirstName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
//            lblFirstName.Name = "lblFirstName";
//            lblFirstName.Size = new System.Drawing.Size(78, 19);
//            lblFirstName.Text = "First Name:";
//            // 
//            // txtFirstName
//            // 
//            txtFirstName.Location = new System.Drawing.Point(120, 98);
//            txtFirstName.Name = "txtFirstName";
//            txtFirstName.Size = new System.Drawing.Size(220, 25);
//            txtFirstName.BackColor = Color.FromArgb(45, 45, 48);
//            txtFirstName.ForeColor = Color.White;
//            txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//            txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10F);

//            // 
//            // lblLastName
//            // 
//            lblLastName.AutoSize = true;
//            lblLastName.Location = new System.Drawing.Point(25, 140);
//            lblLastName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
//            lblLastName.Name = "lblLastName";
//            lblLastName.Size = new System.Drawing.Size(79, 19);
//            lblLastName.Text = "Last Name:";
//            // 
//            // txtLastName
//            // 
//            txtLastName.Location = new System.Drawing.Point(120, 138);
//            txtLastName.Name = "txtLastName";
//            txtLastName.Size = new System.Drawing.Size(220, 25);
//            txtLastName.BackColor = Color.FromArgb(45, 45, 48);
//            txtLastName.ForeColor = Color.White;
//            txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//            txtLastName.Font = new System.Drawing.Font("Segoe UI", 10F);

//            // 
//            // lblRole
//            // 
//            lblRole.AutoSize = true;
//            lblRole.Location = new System.Drawing.Point(25, 180);
//            lblRole.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
//            lblRole.Name = "lblRole";
//            lblRole.Size = new System.Drawing.Size(37, 19);
//            lblRole.Text = "Role:";
//            // 
//            // cmbRole
//            // 
//            cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            cmbRole.FormattingEnabled = true;
//            cmbRole.Items.AddRange(new object[] { "Admin", "User" });
//            cmbRole.Location = new System.Drawing.Point(120, 177);
//            cmbRole.Name = "cmbRole";
//            cmbRole.Size = new System.Drawing.Size(220, 25);
//            cmbRole.BackColor = Color.FromArgb(45, 45, 48);
//            cmbRole.ForeColor = Color.White;
//            cmbRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            cmbRole.Font = new System.Drawing.Font("Segoe UI", 10F);

//            // 
//            // btnSubmit
//            // 
//            btnSubmit.Location = new System.Drawing.Point(120, 220);
//            btnSubmit.Name = "btnSubmit";
//            btnSubmit.Size = new System.Drawing.Size(100, 30);
//            btnSubmit.Text = "Submit";
//            btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            btnSubmit.ForeColor = Color.White;
//            btnSubmit.BackColor = Color.FromArgb(0, 122, 204);
//            btnSubmit.FlatAppearance.BorderSize = 0;
//            btnSubmit.Font = new System.Drawing.Font("Segoe UI", 10F);
//            btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;

//            // 
//            // btnCancel
//            // 
//            btnCancel.Location = new System.Drawing.Point(240, 220);
//            btnCancel.Name = "btnCancel";
//            btnCancel.Size = new System.Drawing.Size(100, 30);
//            btnCancel.Text = "Cancel";
//            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            btnCancel.ForeColor = Color.White;
//            btnCancel.BackColor = Color.FromArgb(80, 80, 80);
//            btnCancel.FlatAppearance.BorderSize = 0;
//            btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
//            btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;

//            // Add controls
//            Controls.Add(lblUsername);
//            Controls.Add(txtUsername);
//            Controls.Add(lblPassword);
//            Controls.Add(txtPassword);
//            Controls.Add(lblFirstName);
//            Controls.Add(txtFirstName);
//            Controls.Add(lblLastName);
//            Controls.Add(txtLastName);
//            Controls.Add(lblRole);
//            Controls.Add(cmbRole);
//            Controls.Add(btnSubmit);
//            Controls.Add(btnCancel);

//            // Control size
//            Name = "AddNewUser";
//            Size = new System.Drawing.Size(370, 270);

//            ResumeLayout(false);
//            PerformLayout();
//        }

//        #endregion
//    }
//}
