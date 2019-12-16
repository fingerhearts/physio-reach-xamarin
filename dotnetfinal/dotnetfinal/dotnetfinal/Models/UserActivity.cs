using System;
using SQLite;

namespace dotnetfinal.Models
{
    public class UserActivity
    {
        public int ActivityID { get; set; }
        public decimal MaxXMotion { get; set; }
        public decimal MaxYMotion { get; set; }
        public decimal MaxZMotion { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Date { get; set; }
    }
}
