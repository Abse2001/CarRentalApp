using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CarRentalApp.Properties;

namespace CarRentalApp
{
    public partial class HomeControl : UserControl
    {
        public HomeControl()
        {
            InitializeComponent();
            this.Load += HomeControl_Load;
        }

        private void HomeControl_Load(object sender, EventArgs e)
        {
            var rentedCars = new List<CarInfo>
    {
        new CarInfo("Toyota", "Camry", 55, "XYZ-123", "2025-05-20", "2025-05-25"),
        new CarInfo("BMW", "320i", 120, "ABC-456", "2025-05-22", "2025-05-28"),
        new CarInfo("Honda", "Civic", 45, "LMN-789", "2025-05-21", "2025-05-26"),
    };

            int row = 0, col = 0;
            foreach (var car in rentedCars)
            {
                if (col == cardGrid.ColumnCount)
                {
                    cardGrid.RowCount++;
                    cardGrid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    col = 0;
                    row++;
                }

                cardGrid.Controls.Add(CreateCarCard(car), col, row);
                col++;
            }
        }

        private Panel CreateCarCard(CarInfo car)
        {
            var card = new Panel
            {
                BackColor = Color.FromArgb(45, 45, 45),
                Width = 500,
                Height = 120,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            string imagePath = Path.Combine(Application.StartupPath, "Resources", "Logo.png");

            var pic = new PictureBox
            {
                Image = Image.FromFile(Path.Combine(Application.StartupPath, "Logo.png")), 
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
                Text = $"${car.PaymentPerDay}/day\n{car.StartDate} → {car.EndDate}",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.WhiteSmoke,
                Location = new Point(100, 40),
                AutoSize = true
            };

            card.Controls.Add(pic);
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

        private void button1_Click(object sender, EventArgs e) { }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void flowPanel_Paint(object sender, PaintEventArgs e) { }

        private void HomeControl_Load_1(object sender, EventArgs e)
        {

        }
    }
}
