namespace CarRentalApp.Forms
{
    partial class RentNow
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblDrivingLicense;
        private System.Windows.Forms.TextBox txtDrivingLicense;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.DateTimePicker dtpDOB;

        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;

        private System.Windows.Forms.Button btnRentNow;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblDrivingLicense = new System.Windows.Forms.Label();
            this.txtDrivingLicense = new System.Windows.Forms.TextBox();
            this.lblNationality = new System.Windows.Forms.Label();
            this.txtNationality = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblDOB = new System.Windows.Forms.Label();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();

            this.lblDueDate = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();

            this.btnRentNow = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // Form dark background
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.ForeColor = System.Drawing.Color.White;

            // Label common style
            void StyleLabel(System.Windows.Forms.Label lbl)
            {
                lbl.ForeColor = System.Drawing.Color.White;
                lbl.BackColor = System.Drawing.Color.Transparent;
                lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            }

            // TextBox common style
            void StyleTextBox(System.Windows.Forms.TextBox txt)
            {
                txt.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
                txt.ForeColor = System.Drawing.Color.White;
                txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                txt.Font = new System.Drawing.Font("Segoe UI", 9F);
            }

            // DateTimePicker common style
            void StyleDateTimePicker(System.Windows.Forms.DateTimePicker dtp)
            {
                dtp.CalendarForeColor = System.Drawing.Color.White;
                dtp.CalendarMonthBackground = System.Drawing.Color.FromArgb(45, 45, 45);
                dtp.CalendarTitleBackColor = System.Drawing.Color.FromArgb(45, 45, 45);
                dtp.CalendarTitleForeColor = System.Drawing.Color.White;
                dtp.CalendarTrailingForeColor = System.Drawing.Color.Gray;
                dtp.Font = new System.Drawing.Font("Segoe UI", 9F);
                dtp.ForeColor = System.Drawing.Color.White;
                dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
                dtp.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            }

            // Button style
            this.btnRentNow.BackColor = System.Drawing.Color.FromArgb(70, 130, 180);
            this.btnRentNow.ForeColor = System.Drawing.Color.White;
            this.btnRentNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRentNow.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // lblFirstName
            this.lblFirstName.Text = "First Name";
            this.lblFirstName.Location = new System.Drawing.Point(30, 30);
            this.lblFirstName.Size = new System.Drawing.Size(100, 20);
            StyleLabel(this.lblFirstName);

            // txtFirstName
            this.txtFirstName.Location = new System.Drawing.Point(150, 30);
            this.txtFirstName.Size = new System.Drawing.Size(200, 23);
            StyleTextBox(this.txtFirstName);

            // lblLastName
            this.lblLastName.Text = "Last Name";
            this.lblLastName.Location = new System.Drawing.Point(30, 70);
            this.lblLastName.Size = new System.Drawing.Size(100, 20);
            StyleLabel(this.lblLastName);

            // txtLastName
            this.txtLastName.Location = new System.Drawing.Point(150, 70);
            this.txtLastName.Size = new System.Drawing.Size(200, 23);
            StyleTextBox(this.txtLastName);

            // lblDrivingLicense
            this.lblDrivingLicense.Text = "License Number";
            this.lblDrivingLicense.Location = new System.Drawing.Point(30, 110);
            this.lblDrivingLicense.Size = new System.Drawing.Size(100, 20);
            StyleLabel(this.lblDrivingLicense);

            // txtDrivingLicense
            this.txtDrivingLicense.Location = new System.Drawing.Point(150, 110);
            this.txtDrivingLicense.Size = new System.Drawing.Size(200, 23);
            StyleTextBox(this.txtDrivingLicense);

            // lblNationality
            this.lblNationality.Text = "Nationality";
            this.lblNationality.Location = new System.Drawing.Point(30, 150);
            this.lblNationality.Size = new System.Drawing.Size(100, 20);
            StyleLabel(this.lblNationality);

            // txtNationality
            this.txtNationality.Location = new System.Drawing.Point(150, 150);
            this.txtNationality.Size = new System.Drawing.Size(200, 23);
            StyleTextBox(this.txtNationality);

            // lblEmail
            this.lblEmail.Text = "Email";
            this.lblEmail.Location = new System.Drawing.Point(30, 190);
            this.lblEmail.Size = new System.Drawing.Size(100, 20);
            StyleLabel(this.lblEmail);

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(150, 190);
            this.txtEmail.Size = new System.Drawing.Size(200, 23);
            StyleTextBox(this.txtEmail);

            // lblPhone
            this.lblPhone.Text = "Phone";
            this.lblPhone.Location = new System.Drawing.Point(30, 230);
            this.lblPhone.Size = new System.Drawing.Size(100, 20);
            StyleLabel(this.lblPhone);

            // txtPhone
            this.txtPhone.Location = new System.Drawing.Point(150, 230);
            this.txtPhone.Size = new System.Drawing.Size(200, 23);
            StyleTextBox(this.txtPhone);

            // lblDOB
            this.lblDOB.Text = "Date of Birth";
            this.lblDOB.Location = new System.Drawing.Point(30, 270);
            this.lblDOB.Size = new System.Drawing.Size(100, 20);
            StyleLabel(this.lblDOB);

            // dtpDOB
            this.dtpDOB.Location = new System.Drawing.Point(150, 270);
            this.dtpDOB.Size = new System.Drawing.Size(200, 23);
            StyleDateTimePicker(this.dtpDOB);

            // lblDueDate
            this.lblDueDate.Text = "Due Date";
            this.lblDueDate.Location = new System.Drawing.Point(30, 350);
            this.lblDueDate.Size = new System.Drawing.Size(100, 20);
            StyleLabel(this.lblDueDate);

            // dtpDueDate
            this.dtpDueDate.Location = new System.Drawing.Point(150, 350);
            this.dtpDueDate.Size = new System.Drawing.Size(200, 23);
            StyleDateTimePicker(this.dtpDueDate);

            // btnRentNow
            this.btnRentNow.Text = "Rent Now";
            this.btnRentNow.Location = new System.Drawing.Point(150, 390);
            this.btnRentNow.Size = new System.Drawing.Size(200, 30);
            this.btnRentNow.Click += new System.EventHandler(this.btnSubmit_Click);

            // RentNow Form
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblDrivingLicense);
            this.Controls.Add(this.txtDrivingLicense);
            this.Controls.Add(this.lblNationality);
            this.Controls.Add(this.txtNationality);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.btnRentNow);
            this.Name = "RentNow";
            this.Text = "Rent Now";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
