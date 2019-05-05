using System;
using System.Collections.Generic;
using System.Text;
using ParkingApp.Infrastructure.DTO;
using ParkingApp.Infrastructure.ServicesResults;

namespace ParkingApp.Infrastructure.Validators
{
    public class UserDtoValidator : IUserDtoValidator
    {
        public ServiceResult ValidateUserDto(UserDto userDto)
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

            return serviceResult;
        }
    }
}
