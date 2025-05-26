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

        private TableLayoutPanel mainLayout;
        private Label lblStatus;
        private FlowLayoutPanel flowPanel;
        private TextBox txtSearch;

        private void InitializeComponent()
        {
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "BMW 540i", "sadfasdfsadf" }, -1, SystemColors.Window, Color.Empty, null);
            ListViewItem listViewItem2 = new ListViewItem(new string[] { "Nissan Almera" }, -1, SystemColors.Window, Color.Empty, null);
            label1 = new Label();
            btnProfile = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            listView1 = new ListView();
            Model = new ColumnHeader("(none)");
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Snow;
            label1.Location = new Point(513, 23);
            label1.Name = "label1";
            label1.Size = new Size(194, 50);
            label1.TabIndex = 0;
            label1.Text = "Welcome ";
            // 
            // btnProfile
            // 
            btnProfile.BackColor = Color.FromArgb(30, 30, 30);
            btnProfile.BackgroundImageLayout = ImageLayout.None;
            btnProfile.Cursor = Cursors.Hand;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.ForeColor = Color.White;
            btnProfile.Location = new Point(1098, 78);
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
            textBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(793, 78);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Search for a car";
            textBox1.Size = new Size(252, 33);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(488, 155);
            label2.Name = "label2";
            label2.Size = new Size(231, 25);
            label2.TabIndex = 3;
            label2.Text = "Currently Renting : 2 Cars";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(22, 86);
            label3.Name = "label3";
            label3.Size = new Size(162, 25);
            label3.TabIndex = 4;
            label3.Text = "User: Abdolsalam";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // listView1
            // 
            listView1.BackColor = Color.FromArgb(30, 30, 30);
            listView1.Columns.AddRange(new ColumnHeader[] { Model });
            listView1.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2 });
            listView1.Location = new Point(36, 234);
            listView1.Name = "listView1";
            listView1.Size = new Size(1139, 456);
            listView1.TabIndex = 5;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // Model
            // 
            Model.Tag = "rented";
            Model.Text = "Model";
            Model.Width = 200;
            // 
            // HomeControl
            // 
            BackColor = Color.FromArgb(30, 30, 30);
            Controls.Add(listView1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(btnProfile);
            Controls.Add(label1);
            Name = "HomeControl";
            Size = new Size(1243, 749);
            ResumeLayout(false);
            PerformLayout();
        }

        private FlowLayoutPanel topBar;
        private PictureBox picNotification;
        private Label label1;
        private Button btnProfile;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private ListView listView1;
        private ColumnHeader Model;
    }
}
