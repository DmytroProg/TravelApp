using TravelApp.Domain.Interfaces;
using TravelApp.Domain.Models;
using TravelApp.Storage.Interfaces;
using TravelApp.Tests.Comparers;
using TravelApp.Tests.Fakes;

namespace TravelApp.Tests
{
    public class UserServiceTests
    {
        private const string _usersPath = "users.testing.xml";
        private const string _domainAssemblyName = "TravelApp.Domain";
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

        private IUserService CreateUserService()
        {
            IFileManager fileManager = new FakeFileManager(_usersPath);
            IUserService userService = (IUserService)TestHelper.GetCustomType(_domainAssemblyName, _serviceName, fileManager);
            return userService;
        }

        [Fact]
        public void UserService_RegisterWithSameName_ThrowsException()
        {
            User user1 = CreateUser(name: "John");
            User user2 = CreateUser(name: "John");
            IUserService userService = CreateUserService();

            var exceptionHandler = () =>
            {
                userService.Register(user1);
                userService.Register(user2);
            };

            Assert.Throws<ArgumentException>(exceptionHandler);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("      ")]
        [InlineData("763")]
        [InlineData(".")]
        [InlineData("!@3")]
        public void UserService_RegisterWithIncorrectName_ThrowsException(string name)
        {
            User user = CreateUser(name: name);
            IUserService userService = CreateUserService();

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
            IUserService userService = CreateUserService();

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
            IUserService userService = CreateUserService();

            var exceptionHandler = Record.Exception(() => userService.Register(user));

            Assert.Null(exceptionHandler);
        }

        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(null)]
        [InlineData("john")]
        [InlineData("john@")]
        [InlineData("@gmail.com")]
        [InlineData("@gmail")]
        [InlineData("john@gmail")]
        [InlineData("john@gmail.")]
        [InlineData("@gmail.com")]
        [InlineData("@.com")]
        [InlineData("john@.com")]
        public void UserService_RegisterWithIncorrectEmail_ThrowsException(string email)
        {
            User user = CreateUser(emailOrPhoneNumber: email);
            IUserService userService = CreateUserService();

            var exceptionHandler = () => userService.Register(user);

            Assert.Throws<ArgumentException>(exceptionHandler);
        }

        [Theory]
        [InlineData("john@gmail.com")]
        [InlineData("john@ukr.net")]
        public void UserService_RegisterWithCorrectEmail_NotThrowsException(string email)
        {
            User user = CreateUser(emailOrPhoneNumber: email);
            IUserService userService = CreateUserService();

            var exceptionHandler = Record.Exception(() => userService.Register(user));

            Assert.Null(exceptionHandler);
        }

        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(null)]
        [InlineData("0")]
        [InlineData("zero")]
        [InlineData("096454")]
        [InlineData("736478637463786478364")]
        public void UserService_RegisterWithIncorrectPhone_ThrowsException(string phone)
        {
            User user = CreateUser(emailOrPhoneNumber: phone);
            IUserService userService = CreateUserService();

            var exceptionHandler = () => userService.Register(user);

            Assert.Throws<ArgumentException>(exceptionHandler);
        }

        [Theory]
        [InlineData("0965463456")]
        [InlineData("6755474595")]
        public void UserService_RegisterWithCorrectPhone_NotThrowsException(string phone)
        {
            User user = CreateUser(emailOrPhoneNumber: phone);
            IUserService userService = CreateUserService();

            var exceptionHandler = Record.Exception(() => userService.Register(user));

            Assert.Null(exceptionHandler);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("NotExistingUser")]
        public void UserService_LoginWithIncorrectName_ReturnNull(string name)
        {
            IUserService userService = CreateUserService();

            var actual = userService.Login(name, _strongPassword);

            Assert.Null(actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("1234TY4Hbbn")]
        public void UserService_LoginWithIncorrectPassword_ReturnNull(string password)
        {
            User user = CreateUser();
            IUserService userService = CreateUserService();

            userService.Register(user);
            var actual = userService.Login("John", password);

            Assert.Null(actual);
        }

        [Fact]
        public void UserService_LoginWithCorrectData_ReturnUser()
        {
            User user = CreateUser();
            IUserService userService = CreateUserService();

            userService.Register(user);
            var actual = userService.Login("John", _strongPassword);

            Assert.Equal(user, actual, new UserComparer());
        }

        [Fact]
        public void UserService_GetUserInfoWithNoUser_ReturnNull()
        {
            IUserService userService = CreateUserService();

            var actual = userService.GetInfo("NotExistingUser");

            Assert.Null(actual);
        }

        [Fact]
        public void UserService_GetUserInfoWithCorrectName_ReturnUser()
        {
            User user = CreateUser();
            IUserService userService = CreateUserService();

            userService.Register(user);
            var actual = userService.GetInfo("John");

            Assert.Equal(actual, user, new UserComparer());
        }

        [Fact]
        public void UserService_ChangeUserInfoWithCorrectName_ReturnUser()
        {
            User user = CreateUser();
            string expected = "john111@gmail.com";
            User newUser = CreateUser(emailOrPhoneNumber: expected);
            IUserService userService = CreateUserService();

            userService.Register(user);
            var actual = userService.ChangeInfo("John", newUser);

            Assert.Equal(actual.EmailOrPhoneNumber, expected);
        }

        [Fact]
        public void UserService_ChangeUserInfoWithIncorrectName_ReturnNull()
        {
            IUserService userService = CreateUserService();

            var actual = userService.GetInfo("John");

            Assert.Null(actual);
        }

        [Fact]
        public void UserService_ChangeUserInfoWithOthersName_ThrowException()
        {
            User user = CreateUser();
            User newUser = CreateUser();
            IUserService userService = CreateUserService();

            var exceptionHandler = () =>
            {
                userService.Register(user);
                var actual = userService.ChangeInfo("John", newUser);
            };

            Assert.Throws<ArgumentException>(exceptionHandler);
        }

        [Fact]
        public void UserService_UserExists_ReturnTrue()
        {
            User user = CreateUser();
            IUserService userService = CreateUserService();

            userService.Register(user);

            Assert.True(userService.UserExists(user.Name));
        }

        [Fact]
        public void UserService_UserExists_ReturnFalse()
        {
            IUserService userService = CreateUserService();

            Assert.False(userService.UserExists("NotExistingUser"));
        }

        [Fact]
        public void UserService_GetRecentOrders_ReturnEmptyCollection()
        {
            User user = CreateUser();
            int expected = 0;
            IUserService userService = CreateUserService();

            userService.Register(user);
            var orders = userService.GetRecentOrders(user.Name);
            
            Assert.Equal(expected, orders.Count);
        }

        [Fact]
        public void UserService_GetRecentOrdersWithIncorrectName_ThrowException()
        {
            IUserService userService = CreateUserService();

            var exceptionHandler = () => userService.GetRecentOrders("NotExistingUser");

            Assert.Throws<ArgumentException>(exceptionHandler);
        }
    }
}