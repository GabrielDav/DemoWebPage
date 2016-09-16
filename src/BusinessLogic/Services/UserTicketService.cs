using System;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.DTO;
using BusinessLogic.Validators;
using DataAccess;
using DataAccess.Entities;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.Services
{
    public class UserTicketService : IUserTicketService
    {
        private readonly IEmailValidator _emailValidator;

        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<UserTicketService> _logger;

         public UserTicketService(IUnitOfWork unitOfWork, IEmailValidator emailValidator, ILogger<UserTicketService> logger)
         {
             if (unitOfWork == null)
                 throw new ArgumentNullException(nameof(unitOfWork));
             _unitOfWork = unitOfWork;

             if (emailValidator == null)
                 throw new ArgumentNullException(nameof(emailValidator));
             _emailValidator = emailValidator;

             if (logger == null)
                 throw new ArgumentNullException(nameof(logger));
             _logger = logger;
         }

        public async Task<ServiceResponse> RegisterUserTicketAsync(UserTicket model)
        {
            try
            {
                _logger.LogInformation($"Saving user ticket for user: {model.UserEmail}");
                if (!_emailValidator.IsValid(model.UserEmail))
                {
                    _logger.LogWarning($"User tried to save ticked using invalid email [{model.UserEmail}]");
                    return new ServiceResponse(Result.BadRequest,
                        $"User email [{model.UserEmail}] is not valid");
                }

                var ticket = new UserTicketEntity
                {
                    Date = DateTime.UtcNow,
                    Name = model.UserName,
                    Email = model.UserEmail,
                    Message = model.Message
                };
                _unitOfWork.UserTicketRepository.Add(ticket);
                await _unitOfWork.SaveAsync();

                return new ServiceResponse(Result.Success);
            }
            catch (Exception exception)
            {
                _logger.LogError((int)Result.InternalError, exception, $"Failed to register user ticket for user {model.UserEmail}:{exception.Message}");
                return new ServiceResponse(Result.InternalError);
            }
        }

        public async Task<ServiceResponse<UserTicket[]>> GetAllTicketsAsync()
        {
            try
            {
                var tickets = await _unitOfWork.UserTicketRepository.GetAllUserTickets();
                var models = tickets.Select(t => new UserTicket
                {
                    Message = t.Message,
                    UserEmail = t.Email,
                    UserName = t.Name,
                    Time = t.Date
                }).ToArray();
                return new ServiceResponse<UserTicket[]>(models);
            }
            catch (Exception exception)
            {
                _logger.LogError((int)Result.InternalError, exception, $"Failed to get user tickets: {exception.Message}");
                return new ServiceResponse<UserTicket[]>(Result.InternalError);
            }
        }
    }
}
