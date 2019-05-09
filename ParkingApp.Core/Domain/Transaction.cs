using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingApp.Core.Domain
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TakenParkingSpotAt { get; set; }
        public DateTime LeftParkingSpotAt { get; set; }
        public decimal CostOfTransaction { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
