using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingApp.Core.Domain
{
    public class ParkingLot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfParkingSpots { get; set; }
        public int TakenParkingSpots { get; set; }
        public int FreeParkingSpots { get; set; }
        public decimal PriceForHour { get; set; }
        public string Location { get; set; }
        public ICollection<ParkingSpot> ParkingSpots { get; set; }
    }
}
