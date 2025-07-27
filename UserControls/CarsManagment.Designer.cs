using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class CarsManagment : UserControl
    {
        private Label headerLabel;
        private DataGridView dgvCars;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private FlowLayoutPanel buttonsPanel;

        public CarsManagment()
        {
            InitializeComponent();
            ApplyTheme();
            LoadDummyCarData(); // Replace with real data load in production
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            headerLabel = new Label();
            dgvCars = new DataGridView();
            buttonsPanel = new FlowLayoutPanel();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCars).BeginInit();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.Dock = DockStyle.Top;
            headerLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            headerLabel.ForeColor = Color.White;
            headerLabel.Location = new Point(0, 0);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(970, 50);
            headerLabel.TabIndex = 2;
            headerLabel.Text = "Car Management";
            headerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvCars
            // 
            dgvCars.AllowUserToAddRows = false;
            dgvCars.AllowUserToDeleteRows = false;
            dgvCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCars.BackgroundColor = Color.FromArgb(35, 35, 35);
            dgvCars.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCars.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 45);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCars.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCars.Dock = DockStyle.Fill;
            dgvCars.Location = new Point(0, 50);
            dgvCars.MultiSelect = false;
            dgvCars.Name = "dgvCars";
            dgvCars.ReadOnly = true;
            dgvCars.RowHeadersVisible = false;
            dgvCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCars.Size = new Size(970, 481);
            dgvCars.TabIndex = 0;
            // 
            // buttonsPanel
            // 
            buttonsPanel.BackColor = Color.FromArgb(40, 40, 40);
            buttonsPanel.Controls.Add(btnDelete);
            buttonsPanel.Controls.Add(btnEdit);
            buttonsPanel.Controls.Add(btnAdd);
            buttonsPanel.Dock = DockStyle.Bottom;
            buttonsPanel.FlowDirection = FlowDirection.RightToLeft;
            buttonsPanel.Location = new Point(0, 531);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Padding = new Padding(10);
            buttonsPanel.Size = new Size(970, 50);
            buttonsPanel.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(200, 50, 50);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(847, 13);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 30);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Delete Car";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(90, 90, 90);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(741, 13);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 30);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit Car";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(50, 50, 50);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(635, 13);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 30);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add Car";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // CarsManagment
            // 
            Controls.Add(dgvCars);
            Controls.Add(buttonsPanel);
            Controls.Add(headerLabel);
            Name = "CarsManagment";
            Size = new Size(970, 581);
            ((System.ComponentModel.ISupportInitialize)dgvCars).EndInit();
            buttonsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void ApplyTheme()
        {
            BackColor = Color.FromArgb(30, 30, 30);
        }

        private void LoadDummyCarData()
        {
            dgvCars.Columns.Clear();
            dgvCars.Columns.Add("CarId", "ID");
            dgvCars.Columns.Add("PlateNumber", "Plate Number");
            dgvCars.Columns.Add("Brand", "Brand");
            dgvCars.Columns.Add("Model", "Model");
            dgvCars.Columns.Add("Year", "Year");
            dgvCars.Columns.Add("Color", "Color");
            dgvCars.Columns.Add("RentalPricePerDay", "Price/Day");
            dgvCars.Columns.Add("Status", "Status");

            dgvCars.Rows.Add(1, "ABC123", "Toyota", "Corolla", 2020, "White", 35.00m.ToString("C"), "Available");
            dgvCars.Rows.Add(2, "XYZ789", "Honda", "Civic", 2019, "Black", 40.00m.ToString("C"), "Rented");
            dgvCars.Rows.Add(3, "LMN456", "Ford", "Focus", 2021, "Blue", 38.00m.ToString("C"), "Out of Service");
        }
    }
}
