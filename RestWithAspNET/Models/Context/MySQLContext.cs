using Microsoft.EntityFrameworkCore;

namespace RestWithAspNET.Models.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() {}

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        { }

        public DbSet<Person> Peoples { get; set; }
        
        public DbSet<Book> Books { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<Category> Categories { get; set; }
    }
}