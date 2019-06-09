using System;
using System.Collections.Generic;
using System.Text;
using ParkingApp.Infrastructure.DTO;
using ParkingApp.Infrastructure.ServicesResults;

namespace ParkingApp.Infrastructure.Validators
{
    public class ParkingLotDtoValidator : IParkingLotDtoValidator
    {
        public ServiceResult Validate(ParkingLotDtoPost parkingLotDto)
        {
            var result = new ServiceResult();
            if (parkingLotDto == null)
            {
                result.IsSuccessful = false;
                result.Message = "Parking lot cannot be null";
                return result;
            }

            if (parkingLotDto.NumberOfParkingSpots <= 0)
            {
                result.IsSuccessful = false;
                result.Message = "Number of parking spots cannot be less or equal to 0";
                return result;
            }

            if (string.IsNullOrEmpty(parkingLotDto.Location))
            {
                result.IsSuccessful = false;
                result.Message = "Location cannot be null or empty";
                return result;
            }

            if (string.IsNullOrEmpty(parkingLotDto.Name))
            {
                result.IsSuccessful = false;
                result.Message = "Name cannot be null or empty";
                return result;
            }

            if (parkingLotDto.PriceForHour < 0)
            {
                result.IsSuccessful = false;
                result.Message = "Price can't be negative";
                return result;
            }

            result.IsSuccessful = true;
            return result;
        }
    }
}
