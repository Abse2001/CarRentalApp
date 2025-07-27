using CarRentalApp.Forms;
using CarRentalApp.Models;
using CarRentalApp.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class CarsManagment : UserControl
    {
        private readonly CarService _carService;
        private readonly User _currentUser;  // Add this field for user
        private Label lblBalance;            // Label to show balance

        // Add user parameter
        public CarsManagment(CarService carService, User currentUser)
        {
            InitializeComponent();

            _carService = carService ?? throw new ArgumentNullException(nameof(carService));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));

            InitializeBalanceLabel();
            InitializeDataGridView();
            LoadCars();
        }

        private void InitializeBalanceLabel()
        {
            lblBalance = new Label()
            {
                AutoSize = true,
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(10, 10), // Adjust position as needed
                Text = $"Balance: ${_currentUser.Balance:F2}"
            };
            this.Controls.Add(lblBalance);
            // Move dgvCars down so it doesn't overlap label
            dgvCars.Top = lblBalance.Bottom + 10;
            dgvCars.Height -= (lblBalance.Height + 10);
        }

        private void InitializeDataGridView()
        {
            dgvCars.Columns.Clear();
            dgvCars.Columns.Add("CarId", "ID");
            dgvCars.Columns.Add("PlateNumber", "Plate Number");
            dgvCars.Columns.Add("Brand", "Brand");
            dgvCars.Columns.Add("Model", "Model");
            dgvCars.Columns.Add("Year", "Year");
            dgvCars.Columns.Add("Color", "Color");
            dgvCars.Columns.Add("Price", "Price/Day");
            dgvCars.Columns.Add("Status", "Status");

            dgvCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCars.MultiSelect = false;
            dgvCars.AllowUserToAddRows = false;
            dgvCars.ReadOnly = true;
        }

        private void LoadCars()
        {
            dgvCars.Rows.Clear();

            var cars = _carService.GetAllCars().ToList();

            foreach (var car in cars)
            {
                dgvCars.Rows.Add(
                    car.CarId,
                    car.PlateNumber,
                    car.Brand,
                    car.Model,
                    car.Year,
                    car.Color,
                    car.RentalPricePerDay.ToString("C"),
                    car.Status
                );
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddNewCar(_carService);
            addForm.StartPosition = FormStartPosition.CenterScreen;

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadCars();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a car to edit.", "Edit Car", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int carId = Convert.ToInt32(dgvCars.SelectedRows[0].Cells["CarId"].Value);
            var carToEdit = _carService.GetCarById(carId);

            if (carToEdit == null)
            {
                MessageBox.Show("Selected car not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var editForm = new AddNewCar(_carService, carToEdit);
            editForm.StartPosition = FormStartPosition.CenterScreen;

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadCars();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a car to delete.", "Delete Car", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int carId = Convert.ToInt32(dgvCars.SelectedRows[0].Cells["CarId"].Value);
            string plate = dgvCars.SelectedRows[0].Cells["PlateNumber"].Value.ToString();

            var confirm = MessageBox.Show($"Are you sure you want to delete '{plate}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                if (_carService.DeleteCar(carId))
                {
                    LoadCars();
                }
                else
                {
                    MessageBox.Show("Failed to delete the car.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
