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
    public partial class CarsControl : UserControl
    {
        public CarsControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            LayoutPanelCar = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(330, 31);
            label1.Name = "label1";
            label1.Size = new Size(543, 50);
            label1.TabIndex = 0;
            label1.Text = "What car are you feeling today?";
            // 
            // LayoutPanelCar
            // 
            LayoutPanelCar.Location = new Point(52, 135);
            LayoutPanelCar.Name = "LayoutPanelCar";
            LayoutPanelCar.Size = new Size(1127, 535);
            LayoutPanelCar.TabIndex = 1;
            // 
            // CarsControl
            // 
            BackColor = Color.FromArgb(30, 30, 30);
            Controls.Add(LayoutPanelCar);
            Controls.Add(label1);
            Name = "CarsControl";
            Size = new Size(1227, 705);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
