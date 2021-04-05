using System.Collections.Generic;
using RestWithAspNET.Models;

namespace RestWithAspNET.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);
        Book Update(Book book);
        void Delete(long id);
        Book FindById(long id);
        List<Book> FindAll();
    }
}