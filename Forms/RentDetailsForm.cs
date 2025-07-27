using CarRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    public partial class RentDetailsForm : Form
    {
        public RentDetailsForm(Car car, Customer customer, List<CarRental> rentals)
        {
            InitializeComponent();
            this.Text = $"Rent Details - {car.PlateNumber}";

            // Setup UI here (labels, grids, etc) or in designer

            var carInfoLabel = new Label
            {
                Text = $"Car: {car.Brand} {car.Model} ({car.Year})\n" +
                       $"Plate: {car.PlateNumber}\n" +
                       $"Color: {car.Color}\n" +
                       $"Status: {car.Status}\n" +
                       $"Price Per Day: ${car.RentalPricePerDay}",
                AutoSize = true,
                Top = 10,
                Left = 10
            };

            var customerInfoLabel = new Label
            {
                Text = $"Customer: {customer.FirstName + " " + customer.LastName}\n" +
                       $"Phone: {customer.Phone}\n" +
                       $"Email: {customer.Email}",
                AutoSize = true,
                Top = carInfoLabel.Bottom + 15,
                Left = 10
            };

            var rentalListLabel = new Label
            {
                Text = "Rental Records:",
                AutoSize = true,
                Top = customerInfoLabel.Bottom + 15,
                Left = 10
            };

            var rentalsListBox = new ListBox
            {
                Top = rentalListLabel.Bottom + 5,
                Left = 10,
                Width = 400,
                Height = 150
            };

            foreach (var rental in rentals)
            {
                var rentedAtStr = rental.RentedAt.ToString("yyyy-MM-dd");
                var dueDateStr = rental.DueDate.ToString("yyyy-MM-dd");
                var returnedStr = rental.ReturnedAt.HasValue ? rental.ReturnedAt.Value.ToString("yyyy-MM-dd") : "Not Returned";

                rentalsListBox.Items.Add($"Rented At: {rentedAtStr}, Due: {dueDateStr}, Returned: {returnedStr}");
            }

            this.Controls.Add(carInfoLabel);
            this.Controls.Add(customerInfoLabel);
            this.Controls.Add(rentalListLabel);
            this.Controls.Add(rentalsListBox);

            this.ClientSize = new System.Drawing.Size(450, rentalsListBox.Bottom + 20);
        }
    }
}
