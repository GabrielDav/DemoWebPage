using System;
using System.Threading.Tasks;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        private IUserTicketRepository _userTicketRepository;

        public UnitOfWork(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public IUserTicketRepository UserTicketRepository
            => _userTicketRepository ?? (_userTicketRepository = new UserTicketRepository(_context));

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
