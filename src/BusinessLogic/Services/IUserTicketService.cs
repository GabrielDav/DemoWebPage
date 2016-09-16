using System.Threading.Tasks;
using BusinessLogic.DTO;

namespace BusinessLogic.Services
{
    public interface IUserTicketService
    {
        /// <summary>
        /// Registers a new user ticket
        /// </summary>
        /// <param name="model">User ticket model</param>
        /// <returns>True when ticket registation is success</returns>
        Task<ServiceResponse> RegisterUserTicketAsync(UserTicket model);

        /// <summary>
        /// Geturns all tickets
        /// </summary>
        /// <returns>All user tickets registered after></returns>
        Task<ServiceResponse<UserTicket[]>> GetAllTicketsAsync();
    }
}
