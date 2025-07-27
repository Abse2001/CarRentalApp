namespace CarRentalApp.UserControls
{
    partial class MessageInboxControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.FlowLayoutPanel messageList;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelContent = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.messageList = new System.Windows.Forms.FlowLayoutPanel();

            this.panelContent.SuspendLayout();
            this.SuspendLayout();

            // panelContent
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.panelContent.Controls.Add(this.messageList);
            this.panelContent.Controls.Add(this.lblHeader);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(600, 420);
            this.panelContent.TabIndex = 0;

            // lblHeader
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(600, 50);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Inbox";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // messageList
            this.messageList.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.messageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.messageList.Location = new System.Drawing.Point(0, 50);
            this.messageList.Name = "messageList";
            this.messageList.Padding = new System.Windows.Forms.Padding(10);
            this.messageList.Size = new System.Drawing.Size(600, 370);
            this.messageList.TabIndex = 1;
            this.messageList.WrapContents = false;
            this.messageList.AutoScroll = true;

            // MessageInboxControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContent);
            this.Name = "MessageInboxControl";
            this.Size = new System.Drawing.Size(600, 420);

            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
