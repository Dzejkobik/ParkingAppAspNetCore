using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingApp.Core.Domain
{
    public class ParkingSpot
    {
        public int Id { get; set; }
        public int ParkingSpotNumber { get; set; }
        public bool IsTaken { get; set; }
        public DateTime TakenAt { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public ParkingLot ParkingLot { get; set; }
    }
}
