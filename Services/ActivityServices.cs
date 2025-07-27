using CarRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarRentalApp.Services
{
    public class ActivityServices
    {
        private readonly string _connectionString;

        public ActivityServices()
        {
            _connectionString = "Server=abse;Database=Spedy;Trusted_Connection=True;TrustServerCertificate=true;";
        }

        public void LogActivity(int userId, string username, string activity)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO ActivityLogs (UserId, Username, Activity)
                                     VALUES (@UserId, @Username, @Activity)";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@Username", username ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Activity", activity);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Activity logging failed: {ex.Message}");
            }
        }

        public List<ActivityLog> GetAllLogs()
        {
            var logs = new List<ActivityLog>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"SELECT Id, UserId, Username, Activity, Timestamp FROM ActivityLogs ORDER BY Timestamp DESC";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var log = new ActivityLog
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                    Username = reader.GetString(reader.GetOrdinal("Username")),
                                    Activity = reader.GetString(reader.GetOrdinal("Activity")),
                                    Timestamp = reader.GetDateTime(reader.GetOrdinal("Timestamp"))
                                };
                                logs.Add(log);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to fetch activity logs: {ex.Message}");
            }

            return logs;
        }
    }
}
