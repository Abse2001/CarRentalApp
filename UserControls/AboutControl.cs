using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp.UserControls
{
    public partial class AboutControl : UserControl
    {
        public AboutControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill; 
            LoadAboutDataAsync();
        }

        private async void LoadAboutDataAsync()
        {
            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("http://dev2.alashiq.com/about.php");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var aboutResponse = JsonSerializer.Deserialize<AboutApiResponse>(json);

                if (aboutResponse?.success == true && aboutResponse.data != null)
                {
                    lblTitle.Text = aboutResponse.data.title;
                    lblVersion.Text = $"Version {aboutResponse.data.system_version}";
                    lblDescription.Text = aboutResponse.data.description;
                }
                else
                {
                    lblTitle.Text = "Failed to load About Info";
                    lblDescription.Text = aboutResponse?.message ?? "No message provided.";
                }
            }
            catch (Exception ex)
            {
                lblTitle.Text = "Error loading About Info";
                lblDescription.Text = ex.Message;
            }
        }

    }

    public class AboutApiResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public AboutData data { get; set; }
    }

    public class AboutData
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string system_version { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
