using System;
using System.Collections.Generic;
using System.Text;
using ParkingApp.Core.Domain;
using ParkingApp.Infrastructure.DTO;

namespace ParkingApp.Infrastructure.Mappers
{
    public static class ParkingLotMapper
    {
        public static ParkingLotDto Map(ParkingLot parkingLot)
        {
            var parkingLotDto = new ParkingLotDto()
            {
                FreeParkingSpots = parkingLot.FreeParkingSpots,
                Location = parkingLot.Location,
                Name = parkingLot.Name,
                NumberOfParkingSpots = parkingLot.NumberOfParkingSpots,
                PriceForHour = parkingLot.PriceForHour,
                TakenParkingSpots = parkingLot.TakenParkingSpots
            };
            return parkingLotDto;
        }
    }
}
