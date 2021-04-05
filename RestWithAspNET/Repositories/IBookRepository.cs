using System.Collections.Generic;
using RestWithAspNET.Models;

namespace RestWithAspNET.Repositories
{
    public interface IBookRepository
    {
        Book Create(Book book);
        Book Update(Book book);
        void Delete(long id);
        Book FindById(long id);
        List<Book> FindAll();
        bool Exists(long id);
    }
}