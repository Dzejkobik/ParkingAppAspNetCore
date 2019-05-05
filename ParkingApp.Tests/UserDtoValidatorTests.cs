using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using ParkingApp.Core.Domain;
using ParkingApp.Infrastructure.DTO;
using ParkingApp.Infrastructure.Services;
using ParkingApp.Infrastructure.Validators;

namespace ParkingApp.Tests
{
    public class UserDtoValidatorTests
    {
        private UserDtoValidator _userDtoValidator;
        [SetUp]
        public void SetUp()
        {
            _userDtoValidator = new UserDtoValidator();
        }

        [Test]
        public void Validate_User_Dto_With_Given_Null_Should_Fail()
        {
            //arrange
            UserDto userDto = null;
            var expectedValue = false;

            //act
            var result = _userDtoValidator.ValidateUserDto(userDto);

            //assert
            Assert.That(result.IsSuccessful,Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Validate_User_Dto_With_Empty_Or_Null_Email_Should_Fail(string email)
        {
            UserDto userDto = new UserDto
            {
                Email = email,
                Password = "pass",
                UserName = "userName"
            };
            var expectedValue = false;

            var result = _userDtoValidator.ValidateUserDto(userDto);

            Assert.That(result.IsSuccessful, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Validate_User_Dto_With_Empty_Or_Null_UserName_Should_Fail(string userName)
        {
            UserDto userDto = new UserDto
            {
                Email = "email",
                Password = "pass",
                UserName = userName
            };
            var expectedValue = false;

            var result = _userDtoValidator.ValidateUserDto(userDto);

            Assert.That(result.IsSuccessful, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Validate_User_Dto_With_Empty_Or_Null_Password_Should_Fail(string password)
        {
            UserDto userDto = new UserDto
            {
                Email = "email",
                Password = password,
                UserName = "userName"
            };
            var expectedValue = false;

            var result = _userDtoValidator.ValidateUserDto(userDto);

            Assert.That(result.IsSuccessful, Is.EqualTo(expectedValue));
        }
    }
}
