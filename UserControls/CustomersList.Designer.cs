namespace CarRentalApp.UserControls
{
    partial class CustomersList
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbCustomers;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.ListBox lstRentedCars;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbCustomers = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLicense = new System.Windows.Forms.Label();
            this.lblNationality = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lstRentedCars = new System.Windows.Forms.ListBox();

            this.SuspendLayout();

            // 
            // cmbCustomers
            // 
            this.cmbCustomers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomers.Location = new System.Drawing.Point(20, 20);
            this.cmbCustomers.Name = "cmbCustomers";
            this.cmbCustomers.Size = new System.Drawing.Size(400, 25);
            this.cmbCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(20, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 17);
            this.lblName.Text = "Name:";
            this.lblName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.ForeColor = System.Drawing.Color.White;
            this.lblLicense.Location = new System.Drawing.Point(20, 90);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(90, 17);
            this.lblLicense.Text = "Driving License:";
            this.lblLicense.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // 
            // lblNationality
            // 
            this.lblNationality.AutoSize = true;
            this.lblNationality.ForeColor = System.Drawing.Color.White;
            this.lblNationality.Location = new System.Drawing.Point(20, 120);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(74, 17);
            this.lblNationality.Text = "Nationality:";
            this.lblNationality.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(20, 150);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 17);
            this.lblEmail.Text = "Email:";
            this.lblEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.ForeColor = System.Drawing.Color.White;
            this.lblPhone.Location = new System.Drawing.Point(20, 180);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(53, 17);
            this.lblPhone.Text = "Phone:";
            this.lblPhone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.ForeColor = System.Drawing.Color.White;
            this.lblDOB.Location = new System.Drawing.Point(20, 210);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(82, 17);
            this.lblDOB.Text = "Date of Birth:";
            this.lblDOB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // 
            // lstRentedCars
            // 
            this.lstRentedCars.Location = new System.Drawing.Point(20, 250);
            this.lstRentedCars.Name = "lstRentedCars";
            this.lstRentedCars.Size = new System.Drawing.Size(400, 150);
            this.lstRentedCars.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.lstRentedCars.ForeColor = System.Drawing.Color.White;
            this.lstRentedCars.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            // 
            // CustomersList UserControl
            // 
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.Controls.Add(this.cmbCustomers);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.lblNationality);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.lstRentedCars);
            this.Name = "CustomersList";
            this.Size = new System.Drawing.Size(450, 420);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}
