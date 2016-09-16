using System.Threading.Tasks;
using DataAccess.Repositories;

namespace DataAccess
{
    /// <summary>
    /// Normally I would avoid the UoW/Repository pattern, but since it is the 'standard' way and an explanation is out of scope for this test - I will use it
    /// </summary>
    public interface IUnitOfWork
    {
        IUserTicketRepository UserTicketRepository { get; }

        Task<int> SaveAsync();
    }
}
