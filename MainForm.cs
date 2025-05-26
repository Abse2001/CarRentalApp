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
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            // Show LoginForm as a dialog, then close MainForm after login form closes
            Hide();
            using (var loginForm = new LoginForm())
            {
                loginForm.ShowDialog();
            }
            Close();
        }

        private void BtnHome_Click(object? sender, EventArgs e)
        {
            // Load HomeControl into the main panel
            panelMain.Controls.Clear();
            HomeControl homeControl = new HomeControl();
            homeControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(homeControl);
        }

        private void Btn_Cars_Click(object? sender, EventArgs e)
        {
            // Load CarsControl into the main panel
            panelMain.Controls.Clear();
            CarsControl carsControl = new CarsControl();
            carsControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(carsControl);
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
