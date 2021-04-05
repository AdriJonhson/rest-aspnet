using System.Collections.Generic;
using RestWithAspNET.Models;
using RestWithAspNET.Repositories;
using RestWithAspNET.Repositories.Generic;

namespace RestWithAspNET.Business.Implemetations
{
    public class BookBusiness : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        
        public BookBusiness(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }
    }
}