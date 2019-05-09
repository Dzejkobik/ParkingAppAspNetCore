using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ParkingApp.Core.Domain;
using ParkingApp.Infrastructure.Database;

namespace ParkingApp.Infrastructure.Repositories
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ParkingLotRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<ParkingLot> GetAllParkingLots()
        {
            return _applicationDbContext.ParkingLots;
        }
    }
}
