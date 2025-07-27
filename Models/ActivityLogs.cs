using System;

namespace CarRentalApp.Models
{
    public class ActivityLog
    {
        public int Id { get; set; }                // Primary key
        public int UserId { get; set; }            // User who performed the activity
        public string Username { get; set; }      // Username of the user who performed the activity
        public string Activity { get; set; }       // Description of the activity
        public DateTime Timestamp { get; set; }    // When it happened

        public ActivityLog()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
