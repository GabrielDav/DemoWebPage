using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    internal class UserTicketRepository : BaseRepository<UserTicketEntity>, IUserTicketRepository
    {
        public UserTicketRepository(DbContext context) : base(context)
        {
        }

        public Task<UserTicketEntity[]> GetAllUserTickets()
        {
            return _dbSet.ToArrayAsync();
        }
        
    }
}
