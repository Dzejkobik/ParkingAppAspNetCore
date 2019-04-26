using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ParkingApp.Infrastructure.DTO;
using ParkingApp.Infrastructure.ServicesResults;

namespace ParkingApp.Infrastructure.Services
{
    public interface IUserService
    {
        Task<ServiceResult> CreateUserAsync(UserDto userDto);
    }
}
