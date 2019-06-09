using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ParkingApp.Core.Domain;
using ParkingApp.Infrastructure.DTO;
using ParkingApp.Infrastructure.Mappers;
using ParkingApp.Infrastructure.Repositories;
using ParkingApp.Infrastructure.ServicesResults;

namespace ParkingApp.Infrastructure.Services
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly IParkingLotRepository _parkingLotRepository;

        public ParkingLotService(IParkingLotRepository parkingLotRepository)
        {
            _parkingLotRepository = parkingLotRepository;
        }

        public async Task<ServiceResult<List<ParkingLotDtoGet>>> GetAllParkingLotsAsync()
        {
            var result = new ServiceResult<List<ParkingLotDtoGet>>();
            var list = await _parkingLotRepository.GetAllParkingLotsAsync();
            var listOfDtos = new List<ParkingLotDtoGet>();
            foreach (var parkingLot in list)
            {
                var parkingLotDto = Mapper.Map(parkingLot);
                listOfDtos.Add(parkingLotDto);
            }

            result.IsSuccessful = true;
            result.Object = listOfDtos;
            return result;
        }
    }
}
