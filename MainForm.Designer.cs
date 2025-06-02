namespace CarRentalApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnCars;
        private System.Windows.Forms.Button btnBooking;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelMain;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region




        private void InitializeComponent()
        {
            panelSidebar = new Panel();
            btnLogout = new Button();
            btnBooking = new Button();
            btnCars = new Button();
            btnHome = new Button();
            panelMain = new Panel();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(40, 40, 40);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Controls.Add(btnBooking);
            panelSidebar.Controls.Add(btnCars);
            panelSidebar.Controls.Add(btnHome);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(150, 961);
            panelSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(60, 60, 60);
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0, 916);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(150, 45);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;
            // 
            // btnBooking
            // 
            btnBooking.BackColor = Color.FromArgb(50, 50, 50);
            btnBooking.Dock = DockStyle.Top;
            btnBooking.FlatStyle = FlatStyle.Flat;
            btnBooking.ForeColor = Color.White;
            btnBooking.Location = new Point(0, 90);
            btnBooking.Name = "btnBooking";
            btnBooking.Size = new Size(150, 45);
            btnBooking.TabIndex = 3;
            btnBooking.Text = "Booking";
            btnBooking.UseVisualStyleBackColor = false;
            btnBooking.Click += btnBooking_Click;
            // 
            // btnCars
            // 
            btnCars.BackColor = Color.FromArgb(50, 50, 50);
            btnCars.Dock = DockStyle.Top;
            btnCars.FlatStyle = FlatStyle.Flat;
            btnCars.ForeColor = Color.White;
            btnCars.Location = new Point(0, 45);
            btnCars.Name = "btnCars";
            btnCars.Size = new Size(150, 45);
            btnCars.TabIndex = 2;
            btnCars.Text = "Car Models";
            btnCars.UseVisualStyleBackColor = false;
            btnCars.Click += Btn_Cars_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(50, 50, 50);
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(0, 0);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(150, 45);
            btnHome.TabIndex = 1;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += BtnHome_Click;
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(150, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1334, 961);
            panelMain.TabIndex = 1;
            panelMain.Paint += panelMain_Paint;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1484, 961);
            Controls.Add(panelMain);
            Controls.Add(panelSidebar);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CarRentPro";
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
