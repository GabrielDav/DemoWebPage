using System.Threading.Tasks;
using BusinessLogic;
using BusinessLogic.DTO;
using BusinessLogic.Services;
using BusinessLogic.Validators;
using Moq;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.Extensions.Logging;
using Xunit;

namespace BusinesLogic.Tests
{
    public class UserTicketTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IUserTicketRepository> _userTicketRepositoryMock;
        private readonly ILoggerFactory _loggerFactory = new LoggerFactory();
        
        public UserTicketTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _userTicketRepositoryMock = new Mock<IUserTicketRepository>();
            _unitOfWorkMock.Setup(u => u.UserTicketRepository).Returns(_userTicketRepositoryMock.Object);
            
        }

        [Fact]
        public async Task TestRegisterUserTicketInvalidEmail()
        {
            // Assign
            var emailValidatorMock = new Mock<IEmailValidator>();
            emailValidatorMock.Setup(v => v.IsValid(It.IsAny<string>())).Returns(false);
            var model = new UserTicket {UserEmail = "Invalid email"};
            
            // Act
            var response = await 
                new UserTicketService(_unitOfWorkMock.Object, emailValidatorMock.Object,
                    _loggerFactory.CreateLogger<UserTicketService>()).RegisterUserTicketAsync(model);

            // Assert
            Assert.Equal(Result.BadRequest, response.Result);
        }

        [Fact]
        public async Task TestRegisterUserTicketInvalidSuccess()
        {
            // Assign
            var emailValidatorMock = new Mock<IEmailValidator>();
            emailValidatorMock.Setup(v => v.IsValid(It.IsAny<string>())).Returns(true);
            var model = new UserTicket { UserEmail = "email", Message = "Message", UserName = "Name" };

            // Act
            var response = await
                new UserTicketService(_unitOfWorkMock.Object, emailValidatorMock.Object,
                    _loggerFactory.CreateLogger<UserTicketService>()).RegisterUserTicketAsync(model);

            // Assert
            Assert.Equal(Result.Success, response.Result);
            _userTicketRepositoryMock.Verify(r => r.Add(It.Is<UserTicketEntity>(e => e.Email == model.UserEmail && e.Name == model.UserName)));
        }
    }
}
