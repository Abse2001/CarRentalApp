namespace CarRentalApp.UserControls
{
    partial class AboutControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblDeveloper;
        private System.Windows.Forms.Label lblDescription;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            panelContent = new Panel();
            lblTitle = new Label();
            lblVersion = new Label();
            lblDeveloper = new Label();
            lblDescription = new Label();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.BackColor = Color.FromArgb(30, 30, 30);
            panelContent.Controls.Add(lblDescription);
            panelContent.Controls.Add(lblDeveloper);
            panelContent.Controls.Add(lblVersion);
            panelContent.Controls.Add(lblTitle);
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(800, 500);
            panelContent.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 60;
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Loading...";
            // 
            // lblVersion
            // 
            lblVersion.Font = new Font("Segoe UI", 12F);
            lblVersion.ForeColor = Color.Silver;
            lblVersion.TextAlign = ContentAlignment.MiddleCenter;
            lblVersion.Dock = DockStyle.Top;
            lblVersion.Height = 30;
            lblVersion.Name = "lblVersion";
            // 
            // lblDeveloper
            // 
            lblDeveloper.Font = new Font("Segoe UI", 12F);
            lblDeveloper.ForeColor = Color.Silver;
            lblDeveloper.Text = "Developed by Abse Dev LLC";
            lblDeveloper.TextAlign = ContentAlignment.MiddleCenter;
            lblDeveloper.Dock = DockStyle.Top;
            lblDeveloper.Height = 30;
            lblDeveloper.Name = "lblDeveloper";
            // 
            // lblDescription
            // 
            lblDescription.Font = new Font("Segoe UI", 11F);
            lblDescription.ForeColor = Color.Gainsboro;
            lblDescription.Dock = DockStyle.Top;
            lblDescription.AutoSize = false;
            lblDescription.Height = 250;
            lblDescription.TextAlign = ContentAlignment.TopCenter;
            lblDescription.Padding = new Padding(20);
            lblDescription.Name = "lblDescription";
            // 
            // AboutControl
            // 
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelContent);
            Name = "AboutControl";
            Size = new Size(800, 500);
            panelContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
