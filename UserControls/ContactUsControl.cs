using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentalApp.Models;

namespace CarRentalApp.UserControls
{
    public partial class ContactUsControl : UserControl
    {
        private readonly User _user;

        public ContactUsControl(User user)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user));
            InitializeComponent();
            lblInfo.Text = $"Your message will be sent using your username: {_user.Username}";
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            var message = txtMessage.Text.Trim();

            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Please enter a message.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnSend.Enabled = false; // disable to prevent multiple clicks

            var jsonData = JsonSerializer.Serialize(new
            {
                user_id = _user.Id,
                username = _user.Username,
                message = message
            });

            try
            {
                using var client = new HttpClient
                {
                    Timeout = TimeSpan.FromSeconds(10)
                };

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://dev2.alashiq.com/send.php?systemId=90909823873", content);
                response.EnsureSuccessStatusCode();

                MessageBox.Show("Message sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send message.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSend.Enabled = true; // re-enable
            }
        }
        private void PanelContent_Resize(object sender, EventArgs e)
        {
            int panelWidth = panelContent.ClientSize.Width;

            int maxWidth = txtMessage.MaximumSize.Width;
            int desiredWidth = Math.Min(panelWidth - 40, maxWidth); // leave 20px margin on each side
            int x = (panelWidth - desiredWidth) / 2;

            txtMessage.Width = desiredWidth;
            txtMessage.Location = new Point(x, 110);


            int panelHeight = panelContent.ClientSize.Height;
            int availableHeight = panelHeight - txtMessage.Top - 110;
            int desiredHeight = Math.Min(availableHeight, txtMessage.MaximumSize.Height);
            txtMessage.Height = desiredHeight;

            // btnSend directly below
            btnSend.Width = desiredWidth;
            btnSend.Location = new Point(x, txtMessage.Bottom + 10);
        }



    }
}
