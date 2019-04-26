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

namespace ParkingApp.Tests
{
    public class UserServiceTests
    {
        private UserService _userService;
        [SetUp]
        public void SetUp()
        {
            var mockUserStore = new Mock<IUserStore<User>>();
            var user = new User();
            var mockUserManager = new Mock<UserManager<User>>(mockUserStore.Object
            ,null,null,null,null,null,null,null,null);
            var identityResult = IdentityResult.Success;
            mockUserManager.Setup(x => x.CreateAsync(user)).ReturnsAsync(identityResult);
            _userService = new UserService(mockUserManager.Object);
        }

        [Test]
        public async Task Create_User_With_Given_Null_Should_Fail()
        {
            //arrange
            UserDto userDto = null;
            var expectedValue = false;

            //act
            var result = await _userService.CreateUserAsync(userDto);

            //assert
            Assert.That(result.IsSuccessful,Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public async Task Create_User_With_Empty_Or_Null_Email_Should_Fail(string email)
        {
            UserDto userDto = new UserDto
            {
                Email = email,
                Password = "pass",
                UserName = "userName"
            };
            var expectedValue = false;

            var result = await _userService.CreateUserAsync(userDto);

            Assert.That(result.IsSuccessful, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public async Task Create_User_With_Empty_Or_Null_UserName_Should_Fail(string userName)
        {
            UserDto userDto = new UserDto
            {
                Email = "email",
                Password = "pass",
                UserName = userName
            };
            var expectedValue = false;

            var result = await _userService.CreateUserAsync(userDto);

            Assert.That(result.IsSuccessful, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public async Task Create_User_With_Empty_Or_Null_Password_Should_Fail(string password)
        {
            UserDto userDto = new UserDto
            {
                Email = "email",
                Password = password,
                UserName = "userName"
            };
            var expectedValue = false;

            var result = await _userService.CreateUserAsync(userDto);

            Assert.That(result.IsSuccessful, Is.EqualTo(expectedValue));
        }
    }
}
