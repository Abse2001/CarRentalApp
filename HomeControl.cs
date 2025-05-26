using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class HomeControl : UserControl
    {
        public HomeControl()
        {
            InitializeComponent();
        }

        private void HomeControl_Load(object sender, EventArgs e)
        {

            var rentedCars = new List<CarInfo>
            {
                new CarInfo("Toyota", "Camry", 55, "XYZ-123", "2025-05-20", "2025-05-25"),
                new CarInfo("BMW", "320i", 120, "ABC-456", "2025-05-22", "2025-05-28")
            };

            foreach (var car in rentedCars)
            {
                flowPanel.Controls.Add(CreateCarCard(car));
            }
        }

        private Panel CreateCarCard(CarInfo car)
        {
            var card = new Panel
            {
                BackColor = Color.FromArgb(45, 45, 45),
                Width = 720,
                Height = 100,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            var title = new Label
            {
                Text = $"{car.Make} {car.Model} - {car.LicensePlate}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 10),
                AutoSize = true
            };

            var info = new Label
            {
                Text = $"Price: ${car.PaymentPerDay}/day\nFrom: {car.StartDate} → {car.EndDate}",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.WhiteSmoke,
                Location = new Point(10, 40),
                AutoSize = true
            };

            card.Controls.Add(title);
            card.Controls.Add(info);
            return card;
        }

        private class CarInfo
        {
            public string Make, Model, LicensePlate, StartDate, EndDate;
            public decimal PaymentPerDay;

            public CarInfo(string make, string model, decimal pay, string plate, string start, string end)
            {
                Make = make;
                Model = model;
                LicensePlate = plate;
                StartDate = start;
                EndDate = end;
                PaymentPerDay = pay;
            }
        }

        private void flowPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
