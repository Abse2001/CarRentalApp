using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp.UserControls
{
    public partial class MessageInboxControl : UserControl
    {
        public MessageInboxControl()
        {
            InitializeComponent();

            messageList.Dock = DockStyle.Fill;
            messageList.AutoScroll = true;

            messageList.Resize += (s, e) => AdjustCardWidthsAndPositions();
            this.Load += (s, e) => AdjustCardWidthsAndPositions();

            _ = LoadMessagesAsync();
        }

        // Nested classes for JSON deserialization
        private class ApiResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public DataContainer Data { get; set; }
        }

        private class DataContainer
        {
            public List<UserMessage> Messages { get; set; }
            public int Total_Count { get; set; }
        }

        private class UserMessage
        {
            public int Id { get; set; }
            public int User_Id { get; set; }
            public string Username { get; set; }
            public string Message { get; set; }
            public bool Is_Read { get; set; }
            public string System_Id { get; set; }
            public string Created_At { get; set; }
        }

        private async Task LoadMessagesAsync()
        {
            const string url = "http://dev2.alashiq.com/message.php?systemId=90909823873";

            try
            {
                using var client = new HttpClient();
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                messageList.Controls.Clear();

                if (apiResponse?.Data?.Messages != null)
                {
                    for (int i = 0; i < apiResponse.Data.Messages.Count; i++)
                    {
                        var msg = apiResponse.Data.Messages[i];
                        AddMessageCard(msg.Username, msg.Created_At, msg.Message);

                   
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load messages:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddMessageCard(string username, string timestampStr, string message)
        {
            if (!DateTime.TryParse(timestampStr, out DateTime timestamp))
                timestamp = DateTime.Now;


            timestamp = timestamp.AddHours(9);

            var card = new Panel
            {
                BackColor = Color.FromArgb(50, 50, 50),
                Margin = new Padding(10),
                Padding = new Padding(20),
                AutoSize = false,           // Important: disable AutoSize for manual sizing
                MinimumSize = new Size(800, 80),
                MaximumSize = new Size(1000, 0),
                Anchor = AnchorStyles.Top,
            };

            var lblUser = new Label
            {
                Text = $"{username} - {timestamp:g}",
                ForeColor = Color.Teal,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Height = 20,
                AutoEllipsis = true,
                Dock = DockStyle.Top,
            };

            var lblMsg = new Label
            {
                Text = message,
                ForeColor = Color.WhiteSmoke,
                Font = new Font("Segoe UI", 10F),
                AutoSize = true,
                MaximumSize = new Size(card.MaximumSize.Width - 20, 0),
                Dock = DockStyle.None,
                Location = new Point(card.Padding.Left, lblUser.Bottom + 5),
            };

            card.Controls.Add(lblUser);
            card.Controls.Add(lblMsg);

            messageList.Controls.Add(card);

            AdjustCardWidthsAndPositions();
        }

        private void AdjustCardWidthsAndPositions()
        {
            int minCardWidth = 800;
            int maxCardWidth = 1000;
            int containerWidth = messageList.ClientSize.Width;
            int cardSpacing = 15;

            int targetWidth = (int)(containerWidth * 0.8);
            targetWidth = Math.Max(minCardWidth, Math.Min(targetWidth, maxCardWidth));

            int yOffset = 0;

            foreach (Control ctrl in messageList.Controls)
            {
                if (ctrl is Panel card && card.Controls.Count >= 2)
                {
                    var lblUser = card.Controls.OfType<Label>().FirstOrDefault(l => l.Dock == DockStyle.Top);
                    var lblMsg = card.Controls.OfType<Label>().FirstOrDefault(l => l.Dock == DockStyle.None);

                    if (lblUser != null && lblMsg != null)
                    {
                        card.Width = targetWidth;
                        card.Left = (containerWidth - card.Width) / 2;

                        lblUser.Width = targetWidth - card.Padding.Left - card.Padding.Right;

                        // Set proper wrapping width
                        lblMsg.MaximumSize = new Size(targetWidth - card.Padding.Left - card.Padding.Right, 0);
                        lblMsg.Width = targetWidth - card.Padding.Left - card.Padding.Right;
                        lblMsg.Location = new Point(card.Padding.Left, lblUser.Bottom + 5);

                        // Measure expected height of message text
                        using (Graphics g = lblMsg.CreateGraphics())
                        {
                            SizeF textSize = g.MeasureString(lblMsg.Text, lblMsg.Font, lblMsg.MaximumSize.Width);
                            lblMsg.Height = (int)Math.Ceiling(textSize.Height);
                        }

                        // Set final height of the card
                        card.Height = lblUser.Height + 5 + lblMsg.Height + card.Padding.Top + card.Padding.Bottom;
                        card.Top = yOffset;
                        yOffset += card.Height + cardSpacing;
                    }
                }
            }
        }


    }
}
