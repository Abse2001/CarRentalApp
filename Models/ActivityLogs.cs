using System;

namespace CarRentalApp.Models
{
    public class ActivityLog
    {
        public int Id { get; set; }                
        public int UserId { get; set; }            
        public string Username { get; set; }     
        public string Activity { get; set; }     
        public DateTime Timestamp { get; set; }    

        public ActivityLog()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
