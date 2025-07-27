using CarRentalApp.Models;
using CarRentalApp.Services;
using System;
using System.IO;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    public partial class AddNewCar : Form
    {
        private readonly CarService _carService;
        private readonly Car _carToEdit;
        private readonly bool _isEditMode;

        // Constructor for adding a new car
        public AddNewCar(CarService carService)
        {
            InitializeComponent();
            _carService = carService ?? throw new ArgumentNullException(nameof(carService));

            btnSave.Click += BtnSave_Click;
            btnBrowseImage.Click += btnBrowseImage_Click;

            btnCancel.DialogResult = DialogResult.Cancel;

            _isEditMode = false;
        }

        // Constructor for editing an existing car
        public AddNewCar(CarService carService, Car carToEdit) : this(carService)
        {
            _carToEdit = carToEdit ?? throw new ArgumentNullException(nameof(carToEdit));
            _isEditMode = true;
            PopulateFieldsForEdit();
        }

        private void PopulateFieldsForEdit()
        {
            txtPlateNumber.Text = _carToEdit.PlateNumber;
            txtBrand.Text = _carToEdit.Brand;
            txtModel.Text = _carToEdit.Model;
            txtYear.Text = _carToEdit.Year.ToString();
            txtColor.Text = _carToEdit.Color;
            txtPrice.Text = _carToEdit.RentalPricePerDay.ToString();
            txtImageName.Text = _carToEdit.ImageName;

            string imagePath = Path.Combine(Application.StartupPath, "Assets", _carToEdit.ImageName);
            if (File.Exists(imagePath))
            {
                pictureBoxPreview.ImageLocation = imagePath;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isEditMode)
                {
                    // Update existing car
                    _carToEdit.PlateNumber = txtPlateNumber.Text.Trim();
                    _carToEdit.Brand = txtBrand.Text.Trim();
                    _carToEdit.Model = txtModel.Text.Trim();
                    _carToEdit.Year = int.Parse(txtYear.Text);
                    _carToEdit.Color = txtColor.Text.Trim();
                    _carToEdit.RentalPricePerDay = decimal.Parse(txtPrice.Text);
                    _carToEdit.ImageName = txtImageName.Text.Trim();

                    bool updated = _carService.UpdateCar(_carToEdit); // Implement this in CarService

                    if (updated)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the car.", "Error");
                    }
                }
                else
                {
                    // Add new car
                    var car = new Car
                    {
                        PlateNumber = txtPlateNumber.Text.Trim(),
                        Brand = txtBrand.Text.Trim(),
                        Model = txtModel.Text.Trim(),
                        Year = int.Parse(txtYear.Text),
                        Color = txtColor.Text.Trim(),
                        RentalPricePerDay = decimal.Parse(txtPrice.Text),
                        Status = "Available",
                        ImageName = txtImageName.Text.Trim()
                    };

                    if (string.IsNullOrEmpty(car.PlateNumber))
                    {
                        MessageBox.Show("Plate Number is required.", "Validation Error");
                        return;
                    }

                    bool added = _carService.AddCar(car);

                    if (added)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Failed to add the car.", "Error");
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid Year and Price.", "Validation Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string sourceFilePath = openFileDialog.FileName;
            string fileName = Path.GetFileName(sourceFilePath);
            string destFolder = Path.Combine(Application.StartupPath, "Assets");

            if (!Directory.Exists(destFolder))
            {
                try
                {
                    Directory.CreateDirectory(destFolder);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to create Assets folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string destFilePath = Path.Combine(destFolder, fileName);

            try
            {
                File.Copy(sourceFilePath, destFilePath, true);

                if (pictureBoxPreview.Image != null)
                {
                    pictureBoxPreview.Image.Dispose();
                    pictureBoxPreview.Image = null;
                }

                txtImageName.Text = fileName;
                pictureBoxPreview.ImageLocation = destFilePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to copy image file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblBrand_Click(object sender, EventArgs e)
        {

        }
    }
}
