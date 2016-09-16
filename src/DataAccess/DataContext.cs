using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    /// <summary>
    /// This could be a UoW. However I will not use the UoW/Repository pattern here, but explanation why is out of this test scope
    /// </summary>
    public class DataContext : DbContext
    {
        private readonly string _dbName;

        public DbSet<UserTicketEntity> UserTickets { get; set; }
        
        public DataContext(string dbName)
        {
            _dbName = dbName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=" + _dbName);
        }

    }
}
