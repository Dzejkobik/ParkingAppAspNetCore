using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ParkingApp.Infrastructure.Services;

namespace ParkingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotsController : ControllerBase
    {
        private readonly IParkingLotService _parkingLotService;

        public ParkingLotsController(IParkingLotService parkingLotService)
        {
            _parkingLotService = parkingLotService;
        }
        [HttpGet]
        public ActionResult GetAllParkingLots()
        {
            var list = _parkingLotService.GetAllParkingLots();
            return Ok(list);
        }
    }
}
