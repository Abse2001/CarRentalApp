using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarRentalApp.Components
{
    public static class CarCardFactory
    {
        public class CarInfo
        {
            public string Make, Model, LicensePlate, ImageName, Status;
            public decimal PaymentPerDay;
            public int Year;

            public CarInfo(string make, string model, decimal pay, string plate, string imageName, string status, int year)
            {
                Make = make;
                Model = model;
                LicensePlate = plate;
                ImageName = imageName ?? "Logo.png";
                PaymentPerDay = pay;
                Status = status;
                Year = year;
            }
        }

        // onActionClicked handles Rent or Return depending on status
        public static Panel CreateCarCard(CarInfo car, Action<CarInfo> onActionClicked)
        {
            var card = new Panel
            {
                BackColor = Color.FromArgb(60, 60, 60),
                Width = 250,
                Height = 300,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.None,
            };

            card.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                var bounds = card.ClientRectangle;
                bounds.Inflate(-1, -1);
                using var brush = new SolidBrush(card.BackColor);
                using var pen = new Pen(Color.FromArgb(80, 80, 80), 1);
                using var shadowBrush = new SolidBrush(Color.FromArgb(40, 0, 0, 0));
                g.FillRectangle(shadowBrush, bounds.X + 4, bounds.Y + 4, bounds.Width, bounds.Height);
                g.FillRectangle(brush, bounds);
                g.DrawRectangle(pen, bounds);
            };

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 6,
                Padding = new Padding(8),
                BackColor = Color.Transparent
            };

            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 60));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 2));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            var imagePath = Path.Combine(Application.StartupPath, "Assets", car.ImageName);
            if (!File.Exists(imagePath))
                imagePath = Path.Combine(Application.StartupPath, "Assets", "Logo.png");

            var pic = new PictureBox
            {
                Image = File.Exists(imagePath) ? LoadImageSafe(imagePath) : null,
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill
            };

            var separator = new Panel
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Height = 2,
                Margin = new Padding(0, 5, 0, 15)
            };

            var nameLabel = new Label
            {
                Text = $"{car.Make} {car.Model}",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 0),
            };

            var yearPriceLabel = new Label
            {
                Text = $"{car.Year} • ${car.PaymentPerDay}/day",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.LightGray,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };

            Color statusColor = car.Status?.ToLowerInvariant() switch
            {
                "available" => Color.LightGreen,
                "rented" or "rented out" => Color.Gold,
                "out of service" => Color.IndianRed,
                _ => Color.Gray,
            };

            var statusLabel = new Label
            {
                Text = car.Status,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = statusColor,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };

            var actionButton = new Button
            {
                Text = car.Status?.ToLowerInvariant().Contains("rented") == true ? "Return Now" : "Rent Now",
                Dock = DockStyle.Top,
                Height = 30,
                Margin = new Padding(0, 10, 0, 0),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(80, 80, 80),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
            };
            actionButton.FlatAppearance.BorderSize = 0;

            // Hook action button to invoke callback
            actionButton.Click += (sender, e) => onActionClicked?.Invoke(car);

            layout.Controls.Add(pic, 0, 0);
            layout.Controls.Add(separator, 0, 1);
            layout.Controls.Add(nameLabel, 0, 2);
            layout.Controls.Add(yearPriceLabel, 0, 3);
            layout.Controls.Add(statusLabel, 0, 4);
            layout.Controls.Add(actionButton, 0, 5);

            card.Controls.Add(layout);
            return card;
        }

        private static Image LoadImageSafe(string path)
        {
            using var tempImg = Image.FromFile(path);
            return new Bitmap(tempImg);
        }
    }
}
