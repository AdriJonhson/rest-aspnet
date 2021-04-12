using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestWithAspNET.Models;
using RestWithAspNET.Models.Context;

namespace RestWithAspNET.Repositories.Implemetations
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(MySQLContext context) : base(context)
        {
        }


        public List<Book> FindAll()
        {
            return _context.Books.Include(b => b.Category).ToList();
        }
    }
}