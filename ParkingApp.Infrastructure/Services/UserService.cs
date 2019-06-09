using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ParkingApp.Core.Domain;
using ParkingApp.Infrastructure.DTO;
using ParkingApp.Infrastructure.Jwt;
using ParkingApp.Infrastructure.Mappers;
using ParkingApp.Infrastructure.ServicesResults;
using ParkingApp.Infrastructure.Validators;

namespace ParkingApp.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserDtoValidator _userDtoValidator;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenGenerator _tokenGenerator;

        public UserService(UserManager<User> userManager,IUserDtoValidator userDtoValidator,
            SignInManager<User> signInManager,ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _userDtoValidator = userDtoValidator;
            _signInManager = signInManager;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ServiceResult> CreateUserAsync(UserDto userDto)
        {
            var serviceResult = _userDtoValidator.ValidateUserDto(userDto);
            if (!serviceResult.IsSuccessful)
            {
                return serviceResult;
            }
            var user = Mapper.Map(userDto);
            string defaultRole = "Admin";
            user.Role = defaultRole;
            var userManagerResult = await _userManager.CreateAsync(user,userDto.Password);
            if (userManagerResult.Succeeded == false)
            {
                serviceResult.IsSuccessful = false;
                foreach (var message in userManagerResult.Errors)
                {
                    serviceResult.Message += message.Description + "\n";
                }

                return serviceResult;
            }

            await _userManager.AddToRoleAsync(user, user.Role);
            serviceResult.IsSuccessful = userManagerResult.Succeeded;
            return serviceResult;
        }

        public async Task<ServiceResult<string>> SignInAsync(UserDto userDto)
        {
            var validationResult = _userDtoValidator.ValidateUserDto(userDto);
            var serviceResult = new ServiceResult<string>();
            serviceResult.IsSuccessful = validationResult.IsSuccessful;
            serviceResult.Message = validationResult.Message;

            if (!serviceResult.IsSuccessful)
            {
                return serviceResult;
            }
            var signInResult = await _signInManager.PasswordSignInAsync(userDto.UserName,
                userDto.Password, true, false);
            var user = await _userManager.FindByNameAsync(userDto.UserName);
            var role = await _userManager.GetRolesAsync(user);
            if (signInResult.Succeeded)
            {
                var token = _tokenGenerator.GenerateToken(userDto.UserName,role.FirstOrDefault());
                serviceResult.Object = token;
                serviceResult.IsSuccessful = true;
                return serviceResult;
            }
            serviceResult.IsSuccessful = false;
            serviceResult.Message = "Authentication failed";
            return serviceResult;
        }
    }
}
