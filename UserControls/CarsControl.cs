using CarRentalApp.Components;
using CarRentalApp.Services;
using CarRentalApp.Models;
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
        private readonly CarService _carService;
        private FlowLayoutPanel cardsFlowPanel;

        private readonly Color _primaryColor = Color.FromArgb(40, 40, 45);
        private readonly Color _secondaryColor = Color.FromArgb(60, 60, 65);
        private readonly Color _accentColor = Color.FromArgb(0, 122, 204);
        private Dictionary<string, Image> _imageCache = new();

        private const int CardMargin = 20;
        private const int MaxCardsPerRow = 3;
        private const int MinCardsPerRow = 2;
        private const int CardHeight = 430;
        private const int MinCardWidth = 280;

        private readonly User _currentUser; // Logged-in user info
        private readonly Action _refreshBalanceCallback; // Callback to refresh balance in MainForm

        public CarsControl(CarService carService, User currentUser, Action refreshBalanceCallback = null)
        {
            InitializeComponent();
            _carService = carService;
            _currentUser = currentUser;
            _refreshBalanceCallback = refreshBalanceCallback;

            cardsFlowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.Transparent,
                Padding = new Padding(10),
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
            };
            EnableDoubleBuffering(cardsFlowPanel);
            this.Controls.Add(cardsFlowPanel);

            this.Load += CarsControl_Load;
            this.Resize += (s, e) => AdjustCardSizes();
        }

        private void EnableDoubleBuffering(Control control)
        {
            typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(control, true, null);
        }

        private void CarsControl_Load(object sender, EventArgs e)
        {
            LoadCarData();
        }

        private void LoadCarData()
        {
            SuspendLayout();
            cardsFlowPanel.SuspendLayout();

            cardsFlowPanel.Controls.Clear();

            var cars = _carService.GetAllCars();
            var carInfos = cars.Select(car => new CarInfo(
                car.Brand, car.Model, car.RentalPricePerDay, car.PlateNumber,
                car.ImageName ?? "Logo.png", car.Status ?? "Unknown", car.Year)).ToList();

            PreloadImages(carInfos);

            foreach (var car in carInfos)
            {
                var card = CreateCarCard(car);
                card.Margin = new Padding(CardMargin / 2);
                card.Height = CardHeight;
                card.Dock = DockStyle.None;
                cardsFlowPanel.Controls.Add(card);
            }

            AdjustCardSizes();

            cardsFlowPanel.ResumeLayout();
            ResumeLayout();
            cardsFlowPanel.PerformLayout();
        }

        private void PreloadImages(List<CarInfo> cars)
        {
            foreach (var car in cars)
            {
                var imagePath = Path.Combine(Application.StartupPath, "Assets", car.ImageName);
                if (!File.Exists(imagePath))
                    imagePath = Path.Combine(Application.StartupPath, "Assets", "Logo.png");

                if (!_imageCache.ContainsKey(car.ImageName))
                {
                    try
                    {
                        using var tempImg = Image.FromFile(imagePath);
                        _imageCache[car.ImageName] = new Bitmap(tempImg);
                    }
                    catch
                    {
                        var fallback = Path.Combine(Application.StartupPath, "Assets", "Logo.png");
                        if (File.Exists(fallback))
                        {
                            using var tempImg = Image.FromFile(fallback);
                            _imageCache[car.ImageName] = new Bitmap(tempImg);
                        }
                    }
                }
            }
        }

        private void AdjustCardSizes()
        {
            if (cardsFlowPanel == null || cardsFlowPanel.Controls.Count == 0)
                return;

            int availableWidth = cardsFlowPanel.ClientSize.Width - cardsFlowPanel.Padding.Horizontal;
            if (availableWidth <= 0) return;

            int cardsPerRow = availableWidth < 1000 ? MinCardsPerRow : MaxCardsPerRow;

            int cardWidth = (availableWidth / cardsPerRow) - CardMargin;

            foreach (Control card in cardsFlowPanel.Controls)
            {
                card.Width = cardWidth > MinCardWidth ? cardWidth : MinCardWidth;
                card.Height = CardHeight;
                card.Margin = new Padding(CardMargin / 2);
                card.Dock = DockStyle.None;
            }

            cardsFlowPanel.PerformLayout();
        }

        private BufferedPanel CreateCarCard(CarInfo car)
        {
            var card = new BufferedPanel
            {
                BackColor = _secondaryColor,
                Width = 330,
                Height = CardHeight,
                Margin = new Padding(CardMargin / 2),
                BorderStyle = BorderStyle.None,
                Padding = new Padding(0, 0, 0, 10)
            };

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 6,
                Padding = new Padding(15),
                BackColor = Color.Transparent
            };

            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 70));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 2));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            var pic = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Padding = new Padding(5)
            };

            if (_imageCache.TryGetValue(car.ImageName, out var cachedImage))
                pic.Image = cachedImage;

            var separator = new Panel
            {
                BackColor = Color.FromArgb(80, 80, 80),
                Dock = DockStyle.Fill,
                Height = 1,
                Margin = new Padding(0, 5, 0, 15)
            };

            var nameLabel = new Label
            {
                Text = $"{car.Make} {car.Model}",
                Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 5)
            };

            var yearPriceLabel = new Label
            {
                Text = $"{car.Year} • ${car.PaymentPerDay}/day",
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = Color.LightGray,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 5)
            };

            var statusLabel = new Label
            {
                Text = car.Status?.ToUpper(),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = _accentColor,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };

            var actionButton = new Button
            {
                Text = car.Status?.ToLower() == "available" ? "Rent Now" :
                       (car.Status?.ToLower().Contains("rented") == true ? "Return Now" : "N/A"),
                Dock = DockStyle.Top,
                Height = 30,
                BackColor = _accentColor,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Enabled = car.Status?.ToLower() == "available" || car.Status?.ToLower().Contains("rented") == true,
                Margin = new Padding(30, 10, 30, 0)
            };
            actionButton.FlatAppearance.BorderSize = 0;

            actionButton.Click += (s, e) => OnActionButtonClick(car);

            layout.Controls.Add(pic, 0, 0);
            layout.Controls.Add(separator, 0, 1);
            layout.Controls.Add(nameLabel, 0, 2);
            layout.Controls.Add(yearPriceLabel, 0, 3);
            layout.Controls.Add(statusLabel, 0, 4);
            layout.Controls.Add(actionButton, 0, 5);

            card.Controls.Add(layout);
            return card;
        }

        private void OnActionButtonClick(CarInfo car)
        {
            var selectedCar = _carService.GetAllCars()
                                         .FirstOrDefault(c => c.PlateNumber == car.LicensePlate);

            if (selectedCar == null)
            {
                MessageBox.Show("Car not found.", "Error");
                return;
            }

            string status = selectedCar.Status?.ToLowerInvariant() ?? "";

            if (status.Contains("rented"))
            {
                bool success = _carService.ReturnCar(selectedCar.CarId);
                if (success)
                    MessageBox.Show("Car returned successfully.");
                else
                    MessageBox.Show("Failed to return the car.");
            }
            else if (status == "available")
            {
                using var rentNowForm = new Forms.RentNow(_carService, selectedCar, _currentUser.Id);
                if (rentNowForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Car rented successfully.");
                    _refreshBalanceCallback?.Invoke();
                }
            }
            else
            {
                MessageBox.Show("This car is not available for action.");
            }

            LoadCarData();
        }

       
    }
}
