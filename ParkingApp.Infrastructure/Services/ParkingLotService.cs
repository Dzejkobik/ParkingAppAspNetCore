using System;
using System.Collections.Generic;
using System.Text;
using ParkingApp.Core.Domain;
using ParkingApp.Infrastructure.DTO;
using ParkingApp.Infrastructure.Mappers;
using ParkingApp.Infrastructure.Repositories;

namespace ParkingApp.Infrastructure.Services
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly IParkingLotRepository _parkingLotRepository;

        public ParkingLotService(IParkingLotRepository parkingLotRepository)
        {
            _parkingLotRepository = parkingLotRepository;
        }

        public List<ParkingLotDto> GetAllParkingLots()
        {
            var list = _parkingLotRepository.GetAllParkingLots();
            var listOfDtos = new List<ParkingLotDto>();
            foreach (var parkingLot in list)
            {
                var parkingLotDto = ParkingLotMapper.Map(parkingLot);
                listOfDtos.Add(parkingLotDto);
            }

            return listOfDtos;
        }
    }
}
