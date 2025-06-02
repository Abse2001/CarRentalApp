namespace CarRentalApp
{
    partial class CarsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel LayoutPanelCar;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Method required for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            LayoutPanelCar = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(330, 31);
            label1.Name = "label1";
            label1.Size = new Size(543, 50);
            label1.TabIndex = 0;
            label1.Text = "What car are you feeling today?";
            // 
            // LayoutPanelCar
            // 
            LayoutPanelCar.AutoScroll = true;
            LayoutPanelCar.Location = new Point(99, 300);
            LayoutPanelCar.Name = "LayoutPanelCar";
            LayoutPanelCar.Size = new Size(1127, 535);
            LayoutPanelCar.TabIndex = 1;
            // 
            // CarsControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(30, 30, 30);
            Controls.Add(LayoutPanelCar);
            Controls.Add(label1);
            Name = "CarsControl";
            Size = new Size(1334, 961);
            Load += CarsControl_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
