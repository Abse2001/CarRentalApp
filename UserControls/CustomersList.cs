using CarRentalApp.DAL;
using CarRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp.UserControls
{
    public partial class CustomersList : UserControl
    {
        private List<Customer> _customers = new();
        private readonly CarManagment _carManagment = new();
        private string connectionString = "Server=abse;Database=Spedy;Trusted_Connection=True;TrustServerCertificate=true;";

        public CustomersList()
        {
            InitializeComponent();
            SetupUI();
            LoadCustomers();
        }

        private void SetupUI()
        {
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.Font = new Font("Segoe UI", 10);

            cmbCustomers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomers.BackColor = Color.FromArgb(45, 45, 45);
            cmbCustomers.ForeColor = Color.White;
            cmbCustomers.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            cmbCustomers.SelectedIndexChanged -= CmbCustomers_SelectedIndexChanged;
            cmbCustomers.SelectedIndexChanged += CmbCustomers_SelectedIndexChanged;

            foreach (Control ctrl in new Control[] { lblName, lblLicense, lblNationality, lblEmail, lblPhone, lblDOB, lstRentedCars })
            {
                ctrl.ForeColor = Color.White;
                ctrl.Font = new Font("Segoe UI", 10, FontStyle.Regular);

                if (ctrl is ListBox lb)
                {
                    lb.BackColor = Color.FromArgb(45, 45, 45);
                    lb.ForeColor = Color.White;
                }
            }
        }

        private void LoadCustomers()
        {
            _customers.Clear();
            cmbCustomers.Items.Clear();

            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();

                string sql = @"SELECT CustomerId, FirstName, LastName, DrivingLicenseNum, Nationality, Email, Phone, DateOfBirth FROM Customers";

                using var cmd = new SqlCommand(sql, conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var cust = new Customer()
                    {
                        CustomerId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        DrivingLicenseNum = reader.GetString(3),
                        Nationality = reader.GetString(4),
                        Email = reader.GetString(5),
                        Phone = reader.GetString(6),
                        DateOfBirth = reader.GetDateTime(7),
                    };
                    _customers.Add(cust);
                    cmbCustomers.Items.Add($"{cust.FirstName} {cust.LastName} - {cust.DrivingLicenseNum}");
                }

                if (cmbCustomers.Items.Count > 0)
                    cmbCustomers.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbCustomers_SelectedIndexChanged(object? sender, EventArgs e)
        {
            int idx = cmbCustomers.SelectedIndex;
            if (idx < 0 || idx >= _customers.Count)
                return;

            var cust = _customers[idx];

            lblName.Text = $"Name: {cust.FirstName} {cust.LastName}";
            lblLicense.Text = $"Driving License: {cust.DrivingLicenseNum}";
            lblNationality.Text = $"Nationality: {cust.Nationality}";
            lblEmail.Text = $"Email: {cust.Email}";
            lblPhone.Text = $"Phone: {cust.Phone}";
            lblDOB.Text = $"Date of Birth: {cust.DateOfBirth:yyyy-MM-dd}";

            LoadRentedCarsForCustomer(cust.CustomerId);
        }

        private void LoadRentedCarsForCustomer(int customerId)
        {
            lstRentedCars.Items.Clear();

            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();

                string sql = @"
                    SELECT Id, CarId, RentedAt, DueDate, ReturnedAt
                    FROM CarRentals
                    WHERE CustomerId = @CustomerId
                    ORDER BY RentedAt DESC";

                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                using var reader = cmd.ExecuteReader();

                var rentals = new List<CarRental>();
                while (reader.Read())
                {
                    rentals.Add(new CarRental
                    {
                        Id = reader.GetInt32(0),
                        CarId = reader.GetInt32(1),
                        CustomerId = customerId,
                        RentedAt = reader.GetDateTime(2),
                        DueDate = reader.GetDateTime(3),
                        ReturnedAt = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                    });
                }

                if (rentals.Count == 0)
                {
                    lstRentedCars.Items.Add("(No rental history)");
                    return;
                }

                foreach (var rental in rentals)
                {
                    var car = _carManagment.GetById(rental.CarId);
                    if (car != null)
                    {
                        string returnedAtStr = rental.ReturnedAt.HasValue ? rental.ReturnedAt.Value.ToString("yyyy-MM-dd") : "Not Returned";
                        lstRentedCars.Items.Add(
                            $"{car.Brand} {car.Model} ({car.Year}) - Plate: {car.PlateNumber} | " +
                            $"Rented: {rental.RentedAt:yyyy-MM-dd} | Due: {rental.DueDate:yyyy-MM-dd} | Returned: {returnedAtStr}"
                        );
                    }
                    else
                    {
                        lstRentedCars.Items.Add($"Car ID #{rental.CarId} (details not found) | " +
                                               $"Rented: {rental.RentedAt:yyyy-MM-dd} | Due: {rental.DueDate:yyyy-MM-dd}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rental history: {ex.Message}", "Error");
                lstRentedCars.Items.Clear();
                lstRentedCars.Items.Add("Error loading rental history");
            }
        }
    }
}
