using CarRentalApp.DAL;
using CarRentalApp.Models;
using CarRentalApp.Services;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CarRentalApp.Forms
{
    public partial class RentNow : Form
    {
        private readonly CarService _carService;
        private readonly Car _selectedCar;
        private readonly int _userId;  // Logged-in user ID
        private readonly UserManagment _userManagment = new UserManagment();

        public RentNow(CarService carService, Car selectedCar, int userId)
        {
            InitializeComponent();
            _carService = carService ?? throw new ArgumentNullException(nameof(carService));
            _selectedCar = selectedCar ?? throw new ArgumentNullException(nameof(selectedCar));
            _userId = userId;

            // Set DOB default to exactly 18 years ago
            dtpDOB.Value = DateTime.Today.AddYears(-18);
            dtpDOB.MaxDate = DateTime.Today.AddYears(-18);
            dtpDOB.MinDate = DateTime.Today.AddYears(-100);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    MessageBox.Show("First name is required.", "Validation Error");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    MessageBox.Show("Last name is required.", "Validation Error");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtDrivingLicense.Text))
                {
                    MessageBox.Show("Driving license is required.", "Validation Error");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtNationality.Text))
                {
                    MessageBox.Show("Nationality is required.", "Validation Error");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Email is required.", "Validation Error");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    MessageBox.Show("Phone number is required.", "Validation Error");
                    return;
                }

                // Phone digits only check
                if (!Regex.IsMatch(txtPhone.Text.Trim(), @"^\d+$"))
                {
                    MessageBox.Show("Phone number must contain digits only.", "Validation Error");
                    return;
                }

                // Email format check (simple)
                if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Please enter a valid email address.", "Validation Error");
                    return;
                }

                // DOB check: must be at least 18
                DateTime dob = dtpDOB.Value.Date;
                int age = DateTime.Today.Year - dob.Year;
                if (dob > DateTime.Today.AddYears(-age)) age--;
                if (age < 18)
                {
                    MessageBox.Show("Customer must be at least 18 years old.", "Validation Error");
                    return;
                }

                string license = txtDrivingLicense.Text.Trim();

                // Get or create customer
                int customerId = GetOrCreateCustomerId(license);
                if (customerId == 0)
                {
                    MessageBox.Show("Failed to find or add customer.");
                    return;
                }

                DateTime rentDate = DateTime.Now;
                DateTime dueDate = dtpDueDate.Value.Date;
                int totalDays = (dueDate - rentDate.Date).Days;
                if (totalDays < 1) totalDays = 1;

                decimal totalCost = totalDays * _selectedCar.RentalPricePerDay;

                var user = _userManagment.GetById(_userId);
                if (user == null)
                {
                    MessageBox.Show("User not found.");
                    return;
                }

                if (user.Balance < totalCost)
                {
                    MessageBox.Show($"Insufficient balance. You need ${totalCost} but have ${user.Balance}.", "Balance Error");
                    return;
                }

                bool deducted = _userManagment.UpdateBalance(_userId, -totalCost);
                if (!deducted)
                {
                    MessageBox.Show("Failed to deduct balance.", "Error");
                    return;
                }

                bool rented = _carService.RentCar(_selectedCar.CarId, customerId, dueDate);

                if (rented)
                {
                    MessageBox.Show($"Car rented successfully for {totalDays} day(s), total cost: ${totalCost}");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Car is not available for rent.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error renting car: {ex.Message}", "Error");
            }
        }

        private int GetOrCreateCustomerId(string license)
        {
            using var conn = new SqlConnection("Server=abse;Database=Spedy;Trusted_Connection=True;TrustServerCertificate=true;");
            conn.Open();

            using var cmdCheck = new SqlCommand(
                "SELECT CustomerId FROM Customers WHERE DrivingLicenseNum = @License", conn);
            cmdCheck.Parameters.AddWithValue("@License", license);

            var result = cmdCheck.ExecuteScalar();
            if (result != null)
            {
                return (int)result;
            }

            using var cmdInsert = new SqlCommand(@"
                INSERT INTO Customers (FirstName, LastName, DrivingLicenseNum, Nationality, Email, Phone, DateOfBirth)
                VALUES (@FirstName, @LastName, @License, @Nationality, @Email, @Phone, @Dob);
                SELECT SCOPE_IDENTITY();", conn);

            cmdInsert.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
            cmdInsert.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
            cmdInsert.Parameters.AddWithValue("@License", license);
            cmdInsert.Parameters.AddWithValue("@Nationality", txtNationality.Text.Trim());
            cmdInsert.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            cmdInsert.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
            cmdInsert.Parameters.AddWithValue("@Dob", dtpDOB.Value);

            object newId = cmdInsert.ExecuteScalar();
            return Convert.ToInt32(newId);
        }
    }
}
