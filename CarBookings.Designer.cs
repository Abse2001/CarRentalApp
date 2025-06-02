namespace CarRentalApp
{
    partial class CarBookings
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel bookingsPanel;
        private Label titleLabel;
        private Button btnFilter;
        private Button btnExport;
        private Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            bookingsPanel = new FlowLayoutPanel();
            titleLabel = new Label();
            btnFilter = new Button();
            btnExport = new Button();
            btnRefresh = new Button();
            SuspendLayout();
            // 
            // bookingsPanel
            // 
            bookingsPanel.AutoScroll = true;
            bookingsPanel.BackColor = Color.FromArgb(35, 35, 45);
            bookingsPanel.FlowDirection = FlowDirection.TopDown;
            bookingsPanel.Location = new Point(30, 90);
            bookingsPanel.Name = "bookingsPanel";
            bookingsPanel.Size = new Size(1270, 840);
            bookingsPanel.TabIndex = 4;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(30, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(186, 37);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Car Bookings";
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(60, 60, 70);
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 10F);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(1150, 30);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(80, 35);
            btnFilter.TabIndex = 1;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(60, 60, 70);
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 10F);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(1060, 30);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(80, 35);
            btnExport.TabIndex = 2;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(60, 60, 70);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(970, 30);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(80, 35);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // CarBookings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            Controls.Add(titleLabel);
            Controls.Add(btnFilter);
            Controls.Add(btnExport);
            Controls.Add(btnRefresh);
            Controls.Add(bookingsPanel);
            Name = "CarBookings";
            Size = new Size(1334, 961);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
