using System;
using System.Collections.Generic;
using System.Text;
using ParkingApp.Core.Domain;

namespace ParkingApp.Infrastructure.DTO
{
    public class ParkingLotDtoGet
    {
        public string Name { get; set; }
        public int NumberOfParkingSpots { get; set; }
        public int TakenParkingSpots { get; set; }
        public int FreeParkingSpots { get; set; }
        public decimal PriceForHour { get; set; }
        public string Location { get; set; }
    }
}
