namespace CarRentalApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnCars;
        private System.Windows.Forms.Button btnAbout; 
        private System.Windows.Forms.Button btnInbox; 
        private System.Windows.Forms.Button btnBalance;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelNavbar;
        private System.Windows.Forms.TableLayoutPanel navbarLayout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelNavbar = new Panel();
            navbarLayout = new TableLayoutPanel();
            btnHome = new Button();
            btnCars = new Button();
            btnAbout = new Button();
            btnInbox = new Button();
            btnProfile = new Button();
            btnBalance = new Button();
            btnLogout = new Button();
            panelMain = new Panel();
            btnCustomerList = new Button();
            panelNavbar.SuspendLayout();
            navbarLayout.SuspendLayout();
            SuspendLayout();
            // 
            // panelNavbar
            // 
            panelNavbar.BackColor = Color.FromArgb(40, 40, 40);
            panelNavbar.Controls.Add(navbarLayout);
            panelNavbar.Dock = DockStyle.Top;
            panelNavbar.Location = new Point(0, 0);
            panelNavbar.Name = "panelNavbar";
            panelNavbar.Size = new Size(1126, 60);
            panelNavbar.TabIndex = 1;
            // 
            // navbarLayout
            // 
            navbarLayout.ColumnCount = 8;
            navbarLayout.ColumnStyles.Add(new ColumnStyle());
            navbarLayout.ColumnStyles.Add(new ColumnStyle());
            navbarLayout.ColumnStyles.Add(new ColumnStyle());
            navbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            navbarLayout.ColumnStyles.Add(new ColumnStyle());
            navbarLayout.ColumnStyles.Add(new ColumnStyle());
            navbarLayout.ColumnStyles.Add(new ColumnStyle());
            navbarLayout.ColumnStyles.Add(new ColumnStyle());
            navbarLayout.Controls.Add(btnCustomerList, 3, 0);
            navbarLayout.Controls.Add(btnHome, 0, 0);
            navbarLayout.Controls.Add(btnCars, 1, 0);
            navbarLayout.Controls.Add(btnAbout, 2, 0);
            navbarLayout.Controls.Add(btnInbox, 4, 0);
            navbarLayout.Controls.Add(btnProfile, 5, 0);
            navbarLayout.Controls.Add(btnBalance, 6, 0);
            navbarLayout.Controls.Add(btnLogout, 7, 0);
            navbarLayout.Dock = DockStyle.Fill;
            navbarLayout.Location = new Point(0, 0);
            navbarLayout.Name = "navbarLayout";
            navbarLayout.RowCount = 1;
            navbarLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            navbarLayout.Size = new Size(1126, 60);
            navbarLayout.TabIndex = 0;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(50, 50, 50);
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(10, 10);
            btnHome.Margin = new Padding(10);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(100, 40);
            btnHome.TabIndex = 1;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += BtnHome_Click;
            // 
            // btnCars
            // 
            btnCars.BackColor = Color.FromArgb(50, 50, 50);
            btnCars.FlatAppearance.BorderSize = 0;
            btnCars.FlatStyle = FlatStyle.Flat;
            btnCars.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCars.ForeColor = Color.White;
            btnCars.Location = new Point(130, 10);
            btnCars.Margin = new Padding(10);
            btnCars.Name = "btnCars";
            btnCars.Size = new Size(100, 40);
            btnCars.TabIndex = 2;
            btnCars.Text = "Car Models";
            btnCars.UseVisualStyleBackColor = false;
            btnCars.Click += Btn_Cars_Click;
            // 
            // btnAbout
            // 
            btnAbout.BackColor = Color.FromArgb(50, 50, 50);
            btnAbout.FlatAppearance.BorderSize = 0;
            btnAbout.FlatStyle = FlatStyle.Flat;
            btnAbout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAbout.ForeColor = Color.White;
            btnAbout.Location = new Point(250, 10);
            btnAbout.Margin = new Padding(10);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(100, 40);
            btnAbout.TabIndex = 3;
            btnAbout.Text = "About";
            btnAbout.UseVisualStyleBackColor = false;
            btnAbout.Click += btnAbout_Click;
            // 
            // btnInbox
            // 
            btnInbox.BackColor = Color.Teal;
            btnInbox.FlatAppearance.BorderSize = 0;
            btnInbox.FlatStyle = FlatStyle.Flat;
            btnInbox.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnInbox.ForeColor = Color.White;
            btnInbox.Location = new Point(636, 10);
            btnInbox.Margin = new Padding(10);
            btnInbox.Name = "btnInbox";
            btnInbox.Size = new Size(80, 40);
            btnInbox.TabIndex = 4;
            btnInbox.Text = "Inbox";
            btnInbox.UseVisualStyleBackColor = false;
            btnInbox.Click += BtnInbox_Click;
            // 
            // btnProfile
            // 
            btnProfile.BackColor = Color.FromArgb(50, 50, 50);
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProfile.ForeColor = Color.White;
            btnProfile.Location = new Point(736, 10);
            btnProfile.Margin = new Padding(10);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(100, 40);
            btnProfile.TabIndex = 5;
            btnProfile.Text = "Profile";
            btnProfile.UseVisualStyleBackColor = false;
            // 
            // btnBalance
            // 
            btnBalance.BackColor = Color.FromArgb(50, 50, 50);
            btnBalance.FlatAppearance.BorderSize = 0;
            btnBalance.FlatStyle = FlatStyle.Flat;
            btnBalance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBalance.ForeColor = Color.White;
            btnBalance.Location = new Point(856, 10);
            btnBalance.Margin = new Padding(10);
            btnBalance.Name = "btnBalance";
            btnBalance.Size = new Size(140, 40);
            btnBalance.TabIndex = 6;
            btnBalance.TabStop = false;
            btnBalance.Text = "Balance: $0.00";
            btnBalance.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(50, 50, 50);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1016, 10);
            btnLogout.Margin = new Padding(10);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 40);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(35, 35, 35);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 60);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1126, 572);
            panelMain.TabIndex = 0;
            // 
            // btnCustomerList
            // 
            btnCustomerList.BackColor = Color.FromArgb(50, 50, 50);
            btnCustomerList.FlatAppearance.BorderSize = 0;
            btnCustomerList.FlatStyle = FlatStyle.Flat;
            btnCustomerList.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCustomerList.ForeColor = Color.White;
            btnCustomerList.Location = new Point(370, 10);
            btnCustomerList.Margin = new Padding(10);
            btnCustomerList.Name = "btnCustomerList";
            btnCustomerList.Size = new Size(120, 40);
            btnCustomerList.TabIndex = 8;
            btnCustomerList.Text = "Customer List";
            btnCustomerList.UseVisualStyleBackColor = false;
            btnCustomerList.Click += btnCustomerList_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1126, 632);
            Controls.Add(panelMain);
            Controls.Add(panelNavbar);
            MinimumSize = new Size(800, 500);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Car Rental App";
            WindowState = FormWindowState.Maximized;
            panelNavbar.ResumeLayout(false);
            navbarLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnCustomerList;
    }
}
