using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface IUserTicketRepository : IRepository<UserTicketEntity>
    {
        Task<UserTicketEntity[]> GetAllUserTickets();
    }
}
