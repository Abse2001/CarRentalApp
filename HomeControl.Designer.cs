using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp
{
    partial class HomeControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblWelcome;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
        private Label label1;
        private Button btnProfile;
        private TextBox textBox1;
        private Label label2;
        private Label label3;

        private void InitializeComponent()
        {
            label1 = new Label();
            btnProfile = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            cardGrid = new TableLayoutPanel();
            flowPanel = new FlowLayoutPanel();
            flowPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Snow;
            label1.Location = new Point(564, 13);
            label1.Name = "label1";
            label1.Size = new Size(194, 50);
            label1.TabIndex = 0;
            label1.Text = "Welcome ";
            // 
            // btnProfile
            // 
            btnProfile.BackColor = Color.FromArgb(30, 30, 30);
            btnProfile.Cursor = Cursors.Hand;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.ForeColor = Color.White;
            btnProfile.Location = new Point(1194, 82);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(114, 33);
            btnProfile.TabIndex = 1;
            btnProfile.Text = "Profile";
            btnProfile.UseVisualStyleBackColor = false;
            btnProfile.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(30, 30, 30);
            textBox1.Font = new Font("Segoe UI", 14.25F);
            textBox1.Location = new Point(865, 80);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Search for a car";
            textBox1.Size = new Size(252, 33);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(537, 121);
            label2.Name = "label2";
            label2.Size = new Size(231, 25);
            label2.TabIndex = 3;
            label2.Text = "Currently Renting : 2 Cars";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(22, 86);
            label3.Name = "label3";
            label3.Size = new Size(162, 25);
            label3.TabIndex = 4;
            label3.Text = "User: Abdolsalam";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // cardGrid
            // 
            cardGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            cardGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            cardGrid.Location = new Point(3, 3);
            cardGrid.Name = "cardGrid";
            cardGrid.Size = new Size(1133, 460);
            cardGrid.TabIndex = 0;
            // 
            // flowPanel
            // 
            flowPanel.AutoScroll = true;
            flowPanel.BackColor = Color.FromArgb(30, 30, 30);
            flowPanel.Controls.Add(cardGrid);
            flowPanel.Location = new Point(88, 297);
            flowPanel.Name = "flowPanel";
            flowPanel.Size = new Size(1155, 475);
            flowPanel.TabIndex = 1;
            // 
            // HomeControl
            // 
            BackColor = Color.FromArgb(30, 30, 30);
            Controls.Add(flowPanel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(btnProfile);
            Controls.Add(label1);
            Name = "HomeControl";
            Size = new Size(1334, 961);
            Load += HomeControl_Load_1;
            flowPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void AddCarCard(string title, string description)
        {
            var card = new Panel
            {
                Size = new Size(250, 140),
                BackColor = Color.FromArgb(45, 45, 48),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 10),
                AutoSize = true
            };

            var lblDesc = new Label
            {
                Text = description,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.LightGray,
                Location = new Point(10, 40),
                Size = new Size(230, 60)
            };

            var btnRent = new Button
            {
                Text = "View",
                BackColor = Color.FromArgb(70, 70, 70),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(150, 105),
                Size = new Size(80, 25)
            };
            btnRent.FlatAppearance.BorderSize = 0;

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblDesc);
            card.Controls.Add(btnRent);

            flowPanel.Controls.Add(card);
        }

        private TableLayoutPanel cardGrid;
        private FlowLayoutPanel flowPanel;
    }
}
