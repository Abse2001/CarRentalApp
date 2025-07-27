using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class CarBookings : UserControl
    {
        public CarBookings()
        {
            InitializeComponent();
            Load += CarBookings_Load;
        }

        private void CarBookings_Load(object sender, EventArgs e)
        {
            var bookings = new List<(string CarName, string Plate, DateTime Start, DateTime End, string Customer, string Phone)>
            {
                ("Toyota Corolla", "AAA-111", DateTime.Today, DateTime.Today.AddDays(3), "Ahmed Ali", "055-1234567"),
                ("BMW X5", "BBB-222", DateTime.Today.AddDays(1), DateTime.Today.AddDays(4), "Fatima Noor", "050-9876543"),
                ("Honda Accord", "CCC-333", DateTime.Today.AddDays(-2), DateTime.Today.AddDays(1), "John Smith", "058-1122334"),
                ("Audi A4", "DDD-444", DateTime.Today, DateTime.Today.AddDays(2), "Mona Saleh", "054-7766554"),
            };

            foreach (var b in bookings)
            {
                bookingsPanel.Controls.Add(CreateBookingCard(b));
            }
        }

        private Panel CreateBookingCard((string CarName, string Plate, DateTime Start, DateTime End, string Customer, string Phone) b)
        {
            var card = new Panel
            {
                Width = 500,
                Height = 120,
                Margin = new Padding(10),
                Padding = new Padding(15),
                BackColor = Color.FromArgb(45, 45, 55),
                BorderStyle = BorderStyle.FixedSingle
            };

            var title = new Label
            {
                Text = $"{b.CarName} - {b.Plate}",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 10),
                AutoSize = true
            };

            var customer = new Label
            {
                Text = $"Customer: {b.Customer}\nPhone: {b.Phone}",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.WhiteSmoke,
                Location = new Point(10, 40),
                AutoSize = true
            };

            var dates = new Label
            {
                Text = $"From: {b.Start:dd MMM yyyy}  To: {b.End:dd MMM yyyy}",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.LightGray,
                Location = new Point(10, 80),
                AutoSize = true
            };

            card.Controls.Add(title);
            card.Controls.Add(customer);
            card.Controls.Add(dates);

            return card;
        }
    }
}
