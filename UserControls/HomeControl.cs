using CarRentalApp.Components;
using CarRentalApp.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class HomeControl : UserControl
    {
        private readonly CarService _carService;
        private Label welcomeLabel;
        private Label titleLabel;
        private BufferedPanel mainContainer;
        private BufferedPanel headerPanel;
        private FlowLayoutPanel cardsFlowPanel;

        private readonly string _username;
        private readonly Color _primaryColor = Color.FromArgb(40, 40, 45);
        private readonly Color _secondaryColor = Color.FromArgb(60, 60, 65);
        private readonly Color _accentColor = Color.FromArgb(0, 122, 204);
        private Dictionary<string, Image> _imageCache = new();

        private bool _uiInitialized = false;

        private const int CardMargin = 20; // Total left+right margin for each card
        private const int MaxCardsPerRow = 3;
        private const int MinCardsPerRow = 2;
        private const int CardHeight = 430;
        private const int MinCardWidth = 280;

        public HomeControl(CarService carService, string username)
        {
            _carService = carService ?? throw new ArgumentNullException(nameof(carService));
            _username = username ?? "User";

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint, true);
            this.UpdateStyles();

            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.BackColor = _primaryColor;
            this.VisibleChanged += HomeControl_VisibleChanged;

            InitializeUI();
            _uiInitialized = true;
            LoadCarData();
        }

        private void InitializeUI()
        {
            SuspendLayout();

            mainContainer = new BufferedPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20, 0, 20, 20),
                BackColor = _primaryColor
            };

            headerPanel = new BufferedPanel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = _primaryColor,
                Padding = new Padding(20, 20, 20, 10)
            };

            var headerLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.Transparent
            };
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            welcomeLabel = new Label
            {
                Text = $"Welcome back, {_username}",
                Font = new Font("Segoe UI Semibold", 12),
                ForeColor = Color.WhiteSmoke,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                AutoSize = true,
                Margin = new Padding(0, 0, 20, 0)
            };

            titleLabel = new Label
            {
                Text = "Your rented cars",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill
            };

            headerLayout.Controls.Add(welcomeLabel, 0, 0);
            headerLayout.Controls.Add(titleLabel, 1, 0);
            headerPanel.Controls.Add(headerLayout);

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

            mainContainer.Controls.Add(cardsFlowPanel);
            mainContainer.Controls.Add(headerPanel);
            Controls.Add(mainContainer);

            ResumeLayout(true);
        }

        private void EnableDoubleBuffering(Control control)
        {
            typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(control, true, null);
        }

        private void HomeControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && _uiInitialized)
            {
                LoadCarData();
            }
        }

        private void LoadCarData()
        {
            SuspendLayout();
            cardsFlowPanel.SuspendLayout();

            var cars = _carService.GetAllCars();
            var rentedCars = cars.Where(c => c.Status?.ToLower() is "rented" or "rented out").ToList();

            titleLabel.Text = $"Your rented cars: {rentedCars.Count}";

            var carInfos = rentedCars.Select(car => new CarInfo(
                car.Brand,
                car.Model,
                car.RentalPricePerDay,
                car.PlateNumber,
                car.ImageName ?? "Logo.png",
                car.Status ?? "Unknown",
                car.Year
            )).ToList();

            PreloadImages(carInfos);

            cardsFlowPanel.Controls.Clear();

            foreach (var car in carInfos)
            {
                var card = CreateCarCard(car);
                card.Margin = new Padding(CardMargin / 2);
                card.Height = CardHeight;
                card.Dock = DockStyle.None;
                cardsFlowPanel.Controls.Add(card);
            }

            AdjustCardSizes();

            cardsFlowPanel.ResumeLayout(false);
            ResumeLayout(true);
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

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustCardSizes();
        }

        private BufferedPanel CreateCarCard(CarInfo car)
        {
            var card = new BufferedPanel
            {
                BackColor = _secondaryColor,
                Width = 330,  // initial width, will be resized dynamically
                Height = CardHeight,
                Margin = new Padding(CardMargin / 2),
                BorderStyle = BorderStyle.None,
                Padding = new Padding(0, 0, 0, 10)
            };

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 5,
                Padding = new Padding(15),
                BackColor = Color.Transparent
            };

            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 80));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 2));
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

            layout.Controls.Add(pic, 0, 0);
            layout.Controls.Add(separator, 0, 1);
            layout.Controls.Add(nameLabel, 0, 2);
            layout.Controls.Add(yearPriceLabel, 0, 3);
            layout.Controls.Add(statusLabel, 0, 4);

            card.Controls.Add(layout);
            return card;
        }

        private class CarInfo
        {
            public string Make { get; }
            public string Model { get; }
            public string LicensePlate { get; }
            public string ImageName { get; }
            public decimal PaymentPerDay { get; }
            public string Status { get; }
            public int Year { get; }

            public CarInfo(string make, string model, decimal pay, string plate, string imageName, string status, int year)
            {
                Make = make;
                Model = model;
                LicensePlate = plate;
                ImageName = imageName;
                PaymentPerDay = pay;
                Status = status;
                Year = year;
            }
        }
    }
}
