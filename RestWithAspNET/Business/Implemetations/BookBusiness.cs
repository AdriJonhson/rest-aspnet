using System.Collections.Generic;
using RestWithAspNET.Models;
using RestWithAspNET.Repositories;

namespace RestWithAspNET.Business.Implemetations
{
    public class BookBusiness : IBookBusiness
    {
        private readonly IBookRepository _bookRepository;
        
        public BookBusiness(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book Create(Book book)
        {
            return _bookRepository.Create(book);
        }

        public Book Update(Book book)
        {
            return _bookRepository.Update(book);
        }

        public void Delete(long id)
        {
            _bookRepository.Delete(id);
        }

        public Book FindById(long id)
        {
            return _bookRepository.FindById(id);
        }

        public List<Book> FindAll()
        {
            return _bookRepository.FindAll();
        }
    }
}