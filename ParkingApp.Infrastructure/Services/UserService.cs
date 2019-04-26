using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ParkingApp.Core.Domain;
using ParkingApp.Infrastructure.DTO;
using ParkingApp.Infrastructure.Mappers;
using ParkingApp.Infrastructure.ServicesResults;

namespace ParkingApp.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ServiceResult> CreateUserAsync(UserDto userDto)
        {
            var serviceResult = new ServiceResult();
            if (userDto == null)
            {
                serviceResult.IsSuccessful = false;
                serviceResult.Message = "User cannot be null";
                return serviceResult;
            }
            if (string.IsNullOrEmpty(userDto.Email))
            {
                serviceResult.IsSuccessful = false;
                serviceResult.Message = "Email cannot be null or empty";
                return serviceResult;
            }
            if (string.IsNullOrEmpty(userDto.Password))
            {
                serviceResult.IsSuccessful = false;
                serviceResult.Message = "Password cannot be null or empty";
                return serviceResult;
            }
            if (string.IsNullOrEmpty(userDto.UserName))
            {
                serviceResult.IsSuccessful = false;
                serviceResult.Message = "User name cannot be null or empty";
                return serviceResult;
            }
            var user = UserMapper.MapUserDtoToUser(userDto);
            var result = await _userManager.CreateAsync(user,userDto.Password);
            if (result.Succeeded == false)
            {
                serviceResult.IsSuccessful = false;
                foreach (var message in result.Errors)
                {
                    serviceResult.Message += message.Description + "\n";
                }

                return serviceResult;
            }
            serviceResult.IsSuccessful = result.Succeeded;
            return serviceResult;
        }
    }
}
