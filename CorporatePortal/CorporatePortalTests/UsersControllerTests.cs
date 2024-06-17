using Microsoft.EntityFrameworkCore;
using API.Controllers;
using API.Models;
using API.Data;
using Microsoft.AspNetCore.Mvc;


namespace CorporatePortalTests
{
    [TestClass]
    public class AuthorizeUserTests
    {
        private CorporatePortalContext _context;
        private UsersController _controller;

        [TestInitialize]
        public void Initialize()
        {
            var connectionString = "metadata=res://*/Data.database.csdl|res://*/Data.database.ssdl|res://*/Data.database.msl;provider=System.Data.SqlClient;provider connection string=\"data source=DESKTOP-M1UIT3L;initial catalog=corporate_portal;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework\"";
        var options = new DbContextOptionsBuilder<CorporatePortalContext>()
            .UseSqlServer(connectionString)
            .Options;


            _context = new CorporatePortalContext(options);
            _controller = new UsersController(_context);
        }

        [TestMethod]
        public async Task AuthorizeUser_ValidCredentials_ReturnsUser()
        {
            // Arrange
            var loginDto = new LoginDto { Username = "user", Password = "123" };

            // Act
            var result = await _controller.AuthorizeUser(loginDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var user = (User)((OkObjectResult)result.Result).Value;
            Assert.AreEqual("Иван", user.FirstName);
            Assert.AreEqual("ivanov@example.com", user.Email);
        }

        [TestMethod]
        public async Task AuthorizeUser_InvalidUsername_ReturnsUnauthorized()
        {
            // Arrange
            var loginDto = new LoginDto { Username = "invalidUser", Password = "anyPassword" };

            // Act
            var result = await _controller.AuthorizeUser(loginDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(UnauthorizedObjectResult));
            Assert.AreEqual("Invalid username or password.", ((UnauthorizedObjectResult)result.Result).Value);
        }

        [TestMethod]
        public async Task AuthorizeUser_InvalidPassword_ReturnsUnauthorized()
        {
            // Arrange
            var loginDto = new LoginDto { Username = "user", Password = "invalidPassword" };

            // Act
            var result = await _controller.AuthorizeUser(loginDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(UnauthorizedObjectResult));
            Assert.AreEqual("Invalid username or password.", ((UnauthorizedObjectResult)result.Result).Value);
        }
    }
}