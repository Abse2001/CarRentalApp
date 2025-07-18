using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            BtnHome_Click(null, EventArgs.Empty);
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            Hide();
            using (var loginForm = new LoginForm())
            {
                loginForm.ShowDialog();
            }
            Close();
        }

        private void BtnHome_Click(object? sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            HomeControl homeControl = new HomeControl();
            homeControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(homeControl);
        }

        private void Btn_Cars_Click(object? sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            CarsControl carsControl = new CarsControl();
            carsControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(carsControl);
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            CarBookings carBookings = new CarBookings();
            carBookings.Dock = DockStyle.Fill;
            panelMain.Controls.Add(carBookings);
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}