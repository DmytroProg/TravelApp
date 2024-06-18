using System.Reflection;
using TravelApp.Domain.Interfaces;
using TravelApp.Domain.Models;

namespace TravelApp.Tests
{
    public class UserServiceTests
    {
        private const string _assemblyName = "TravelApp.Domain";
        private const string _serviceName = "Services.UserService";
        private const string _defaultIconPath = "Icons/icon.png";
        private const string _defaultEmail = "john@gmail.com";
        private const string _strongPassword = "Fr45Gh&!shYU";

        private User CreateUser(string name = "John",
                                string emailOrPhoneNumber = _defaultEmail,
                                string icon = _defaultIconPath,
                                string password = _strongPassword)
        {
            return new User()
            {
                Name = name,
                EmailOrPhoneNumber = emailOrPhoneNumber,
                IconPath = icon,
                Password = password
            };
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("      ")]
        public void UserService_RegisterWithEmptyName_ThrowsException(string name)
        {
            User user = CreateUser(name: name);
            IUserService userService = (IUserService)TestHelper.GetCustomType(_assemblyName, _serviceName);

            var exceptionHandler = () => userService.Register(user);

            Assert.Throws<ArgumentNullException>(exceptionHandler);
        }

        [Theory]
        [InlineData("763")]
        [InlineData(".")]
        [InlineData("!@3")]
        public void UserService_RegisterWithIncorrectName_ThrowsException(string name)
        {
            User user = CreateUser(name: name);
            IUserService userService = (IUserService)TestHelper.GetCustomType(_assemblyName, _serviceName);

            var exceptionHandler = () => userService.Register(user);

            Assert.Throws<ArgumentException>(exceptionHandler);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("     ")]
        [InlineData("12345678")]
        [InlineData("qwerty")]
        [InlineData("pass5")]
        [InlineData("pass6dhdhjw5")]
        // Password must be greater than 7 and contain at least one upper letter and one digit 
        public void UserService_RegisterWithIncorrectPassword_ThrowsException(string password)
        {
            User user = CreateUser(password: password);
            IUserService userService = (IUserService)TestHelper.GetCustomType(_assemblyName, _serviceName);

            var exceptionHandler = () => userService.Register(user);

            Assert.Throws<ArgumentException>(exceptionHandler);
        }

        [Theory]
        [InlineData("Thgf5Tgh")]
        [InlineData("qweRty56")]
        [InlineData("qt5684T47")]
        public void UserService_RegisterWithCorrectPassword_NotThrowsException(string password)
        {
            User user = CreateUser(password: password);
            IUserService userService = (IUserService)TestHelper.GetCustomType(_assemblyName, _serviceName);

            var exceptionHandler = Record.Exception(() => userService.Register(user));

            Assert.Null(exceptionHandler);
        }
    }
}