namespace CarRentalApp.UserControls
{
    partial class ContactUsControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;



        private void InitializeComponent()
        {
            panelContent = new Panel();
            btnSend = new Button();
            txtMessage = new TextBox();
            lblInfo = new Label();
            lblHeader = new Label();
            panelContent.SuspendLayout();
            SuspendLayout();

            // panelContent
            panelContent.BackColor = Color.FromArgb(30, 30, 30);
            panelContent.Controls.Add(btnSend);
            panelContent.Controls.Add(txtMessage);
            panelContent.Controls.Add(lblInfo);
            panelContent.Controls.Add(lblHeader);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(600, 420);
            panelContent.TabIndex = 0;
            panelContent.Resize += PanelContent_Resize;

            // lblHeader
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(600, 50);
            lblHeader.TabIndex = 3;
            lblHeader.Text = "Contact Us";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;

            // lblInfo
            lblInfo.Anchor = AnchorStyles.Top;
            lblInfo.Font = new Font("Segoe UI", 10F);
            lblInfo.ForeColor = Color.LightGray;
            lblInfo.Location = new Point(50, 60);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(500, 40);
            lblInfo.TabIndex = 2;
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            lblInfo.Text = "Have questions or suggestions? Send us a message below.";

            // txtMessage
            txtMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMessage.Font = new Font("Segoe UI", 11F);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.PlaceholderText = "Write your message...";
            txtMessage.MinimumSize = new Size(300, 150);
            txtMessage.MaximumSize = new Size(800, 400);
            txtMessage.Size = new Size(500, 220); // default size
            txtMessage.Location = new Point(50, 110); // temporary, will be updated in Resize event
            txtMessage.TabIndex = 1;


            // btnSend
            btnSend.Anchor = AnchorStyles.Top;
            btnSend.BackColor = Color.Teal;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.Size = new Size(500, 40);
            btnSend.Location = new Point(50, 340); // placed right under txtMessage
            btnSend.TabIndex = 0;
            btnSend.Text = "Send Message";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;

            // ContactUsControl
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelContent);
            Name = "ContactUsControl";
            Size = new Size(600, 420);
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            ResumeLayout(false);
        }

    }
}
