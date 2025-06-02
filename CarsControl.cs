using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class CarsControl : UserControl
    {
        public CarsControl()
        {
            InitializeComponent();
            Load += CarsControl_Load;
        }

        private void CarsControl_Load(object sender, EventArgs e)
        {
            var cars = new List<CarInfo>
               {
                   new CarInfo("Toyota", "Corolla", 50, "AAA-111", "Available"),
                   new CarInfo("BMW", "X5", 150, "BBB-222", "Rented"),
                   new CarInfo("Honda", "Accord", 60, "CCC-333", "Available"),
                   new CarInfo("Ford", "Focus", 40, "DDD-444", "OutOfService"),
                   new CarInfo("Audi", "A4", 120, "EEE-555", "Rented"),
                   new CarInfo("Chevrolet", "Malibu", 55, "FFF-666", "Available"),
                   new CarInfo("Nissan", "Altima", 45, "GGG-777", "OutOfService"),
               };

            var sortedCars = cars.OrderBy(c => GetStatusOrder(c.Status)).ToList();

            foreach (var car in sortedCars)
            {
                LayoutPanelCar.Controls.Add(CreateCarCard(car));
            }
        }

        private int GetStatusOrder(string status)
        {
            return status switch
            {
                "Available" => 0,
                "Rented" => 1,
                "OutOfService" => 2,
                _ => 3
            };
        }

        private Panel CreateCarCard(CarInfo car)
        {
            var card = new Panel
            {
                BackColor = Color.FromArgb(45, 45, 45),
                Width = 500,
                Height = 120,
                Margin = new Padding(10),
                Location = new Point(50, 0),
                BorderStyle = BorderStyle.FixedSingle
            };

            string imagePath = Path.Combine(Application.StartupPath, "Logo.png");
            Image carImage;
            try
            {
                carImage = Image.FromFile(imagePath);
            }
            catch
            {
                carImage = null;
            }

            var pic = new PictureBox
            {
                Image = carImage,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(80, 80),
                Location = new Point(10, 20)
            };

            var title = new Label
            {
                Text = $"{car.Make} {car.Model} - {car.LicensePlate}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(100, 10),
                AutoSize = true
            };

            var info = new Label
            {
                Text = $"${car.PaymentPerDay}/day\nStatus: {car.Status}",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.WhiteSmoke,
                Location = new Point(100, 40),
                AutoSize = true
            };

            card.Controls.Add(pic);
            card.Controls.Add(title);
            card.Controls.Add(info);

            switch (car.Status)
            {
                case "Available":
                    card.BackColor = Color.FromArgb(45, 85, 45);
                    break;
                case "Rented":
                    card.BackColor = Color.FromArgb(85, 85, 45);
                    break;
                case "OutOfService":
                    card.BackColor = Color.FromArgb(85, 45, 45);
                    break;
            }

            return card;
        }

        private class CarInfo
        {
            public string Make, Model, LicensePlate, Status;
            public decimal PaymentPerDay;

            public CarInfo(string make, string model, decimal pay, string plate, string status)
            {
                Make = make;
                Model = model;
                LicensePlate = plate;
                Status = status;
                PaymentPerDay = pay;
            }
        }

        private void CarsControl_Load_1(object sender, EventArgs e)
        {

        }
    }
}
