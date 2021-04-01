using Microsoft.EntityFrameworkCore;

namespace RestWithAspNET.Models.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() {}

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {
            
        }

        public DbSet<Person> Peoples { get; set; }
    }
}