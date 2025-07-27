namespace CarRentalApp.Forms
{
    partial class AddNewCar
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblPlateNumber;
        private System.Windows.Forms.TextBox txtPlateNumber;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.TextBox txtImageName;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblPlateNumber = new Label();
            txtPlateNumber = new TextBox();
            lblBrand = new Label();
            txtBrand = new TextBox();
            lblModel = new Label();
            txtModel = new TextBox();
            lblYear = new Label();
            txtYear = new TextBox();
            lblColor = new Label();
            txtColor = new TextBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            lblImage = new Label();
            txtImageName = new TextBox();
            btnBrowseImage = new Button();
            pictureBoxPreview = new PictureBox();
            btnSave = new Button();
            btnCancel = new Button();
            openFileDialog = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).BeginInit();
            SuspendLayout();
            // 
            // lblPlateNumber
            // 
            lblPlateNumber.BackColor = Color.FromArgb(30, 30, 30);
            lblPlateNumber.ForeColor = Color.WhiteSmoke;
            lblPlateNumber.Location = new Point(10, 20);
            lblPlateNumber.Name = "lblPlateNumber";
            lblPlateNumber.Size = new Size(100, 23);
            lblPlateNumber.TabIndex = 0;
            lblPlateNumber.Text = "Plate Number:";
            // 
            // txtPlateNumber
            // 
            txtPlateNumber.BackColor = Color.FromArgb(30, 30, 30);
            txtPlateNumber.BorderStyle = BorderStyle.FixedSingle;
            txtPlateNumber.ForeColor = Color.WhiteSmoke;
            txtPlateNumber.Location = new Point(129, 17);
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.Size = new Size(200, 23);
            txtPlateNumber.TabIndex = 1;
            // 
            // lblBrand
            // 
            lblBrand.BackColor = Color.FromArgb(30, 30, 30);
            lblBrand.ForeColor = Color.WhiteSmoke;
            lblBrand.Location = new Point(30, 60);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(93, 23);
            lblBrand.TabIndex = 2;
            lblBrand.Text = "Brand:";
            lblBrand.Click += lblBrand_Click;
            // 
            // txtBrand
            // 
            txtBrand.BackColor = Color.FromArgb(30, 30, 30);
            txtBrand.BorderStyle = BorderStyle.FixedSingle;
            txtBrand.ForeColor = Color.WhiteSmoke;
            txtBrand.Location = new Point(129, 57);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(200, 23);
            txtBrand.TabIndex = 3;
            // 
            // lblModel
            // 
            lblModel.BackColor = Color.FromArgb(30, 30, 30);
            lblModel.ForeColor = Color.WhiteSmoke;
            lblModel.Location = new Point(30, 100);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(93, 23);
            lblModel.TabIndex = 4;
            lblModel.Text = "Model:";
            // 
            // txtModel
            // 
            txtModel.BackColor = Color.FromArgb(30, 30, 30);
            txtModel.BorderStyle = BorderStyle.FixedSingle;
            txtModel.ForeColor = Color.WhiteSmoke;
            txtModel.Location = new Point(129, 97);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(200, 23);
            txtModel.TabIndex = 5;
            // 
            // lblYear
            // 
            lblYear.BackColor = Color.FromArgb(30, 30, 30);
            lblYear.ForeColor = Color.WhiteSmoke;
            lblYear.Location = new Point(30, 139);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(93, 23);
            lblYear.TabIndex = 6;
            lblYear.Text = "Year:";
            // 
            // txtYear
            // 
            txtYear.BackColor = Color.FromArgb(30, 30, 30);
            txtYear.BorderStyle = BorderStyle.FixedSingle;
            txtYear.ForeColor = Color.WhiteSmoke;
            txtYear.Location = new Point(129, 137);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(200, 23);
            txtYear.TabIndex = 7;
            // 
            // lblColor
            // 
            lblColor.BackColor = Color.FromArgb(30, 30, 30);
            lblColor.ForeColor = Color.WhiteSmoke;
            lblColor.Location = new Point(30, 180);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(93, 23);
            lblColor.TabIndex = 8;
            lblColor.Text = "Color:";
            // 
            // txtColor
            // 
            txtColor.BackColor = Color.FromArgb(30, 30, 30);
            txtColor.BorderStyle = BorderStyle.FixedSingle;
            txtColor.ForeColor = Color.WhiteSmoke;
            txtColor.Location = new Point(129, 177);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(200, 23);
            txtColor.TabIndex = 9;
            // 
            // lblPrice
            // 
            lblPrice.BackColor = Color.FromArgb(30, 30, 30);
            lblPrice.ForeColor = Color.WhiteSmoke;
            lblPrice.Location = new Point(30, 220);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(93, 23);
            lblPrice.TabIndex = 10;
            lblPrice.Text = "Price/Day:";
            // 
            // txtPrice
            // 
            txtPrice.BackColor = Color.FromArgb(30, 30, 30);
            txtPrice.BorderStyle = BorderStyle.FixedSingle;
            txtPrice.ForeColor = Color.WhiteSmoke;
            txtPrice.Location = new Point(129, 217);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(200, 23);
            txtPrice.TabIndex = 11;
            // 
            // lblImage
            // 
            lblImage.BackColor = Color.FromArgb(30, 30, 30);
            lblImage.ForeColor = Color.WhiteSmoke;
            lblImage.Location = new Point(30, 260);
            lblImage.Name = "lblImage";
            lblImage.Size = new Size(93, 23);
            lblImage.TabIndex = 12;
            lblImage.Text = "Image:";
            // 
            // txtImageName
            // 
            txtImageName.BackColor = Color.FromArgb(45, 45, 45);
            txtImageName.BorderStyle = BorderStyle.FixedSingle;
            txtImageName.ForeColor = Color.WhiteSmoke;
            txtImageName.Location = new Point(129, 260);
            txtImageName.Name = "txtImageName";
            txtImageName.ReadOnly = true;
            txtImageName.Size = new Size(150, 23);
            txtImageName.TabIndex = 13;
            // 
            // btnBrowseImage
            // 
            btnBrowseImage.BackColor = Color.FromArgb(50, 50, 50);
            btnBrowseImage.FlatAppearance.BorderColor = Color.DimGray;
            btnBrowseImage.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            btnBrowseImage.FlatStyle = FlatStyle.Flat;
            btnBrowseImage.ForeColor = Color.WhiteSmoke;
            btnBrowseImage.Location = new Point(289, 260);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.Size = new Size(40, 25);
            btnBrowseImage.TabIndex = 14;
            btnBrowseImage.Text = "...";
            btnBrowseImage.UseVisualStyleBackColor = false;
            // 
            // pictureBoxPreview
            // 
            pictureBoxPreview.BackColor = Color.FromArgb(40, 40, 40);
            pictureBoxPreview.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxPreview.Location = new Point(338, 17);
            pictureBoxPreview.Name = "pictureBoxPreview";
            pictureBoxPreview.Size = new Size(360, 226);
            pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPreview.TabIndex = 15;
            pictureBoxPreview.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(50, 50, 50);
            btnSave.FlatAppearance.BorderColor = Color.DimGray;
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.WhiteSmoke;
            btnSave.Location = new Point(129, 330);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(182, 69);
            btnSave.TabIndex = 16;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(50, 50, 50);
            btnCancel.FlatAppearance.BorderColor = Color.DimGray;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.WhiteSmoke;
            btnCancel.Location = new Point(421, 330);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(182, 69);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // AddNewCar
            // 
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(710, 412);
            Controls.Add(lblPlateNumber);
            Controls.Add(txtPlateNumber);
            Controls.Add(lblBrand);
            Controls.Add(txtBrand);
            Controls.Add(lblModel);
            Controls.Add(txtModel);
            Controls.Add(lblYear);
            Controls.Add(txtYear);
            Controls.Add(lblColor);
            Controls.Add(txtColor);
            Controls.Add(lblPrice);
            Controls.Add(txtPrice);
            Controls.Add(lblImage);
            Controls.Add(txtImageName);
            Controls.Add(btnBrowseImage);
            Controls.Add(pictureBoxPreview);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "AddNewCar";
            Text = "Add New Car";
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
