using System.Collections.Generic;
using RestWithAspNET.Data.Converter.Implementations;
using RestWithAspNET.Data.VO;
using RestWithAspNET.Models;
using RestWithAspNET.Repositories;
using RestWithAspNET.Repositories.Generic;
using RestWithAspNET.Repositories.Implemetations;

namespace RestWithAspNET.Business.Implemetations
{
    public class BookBusiness : IBookBusiness
    {
        private readonly IBookRepository _repository;

        private readonly BookConverter _bookConverter;
        
        public BookBusiness(IBookRepository repository)
        {
            _repository = repository;
            _bookConverter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            Book result = _repository.Create(_bookConverter.Parse(book));
            
            return _bookConverter.Parse(result);
        }

        public BookVO Update(BookVO book)
        {
            Book result = _repository.Update(_bookConverter.Parse(book));

            return _bookConverter.Parse(result);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public BookVO FindById(long id)
        {
            return _bookConverter.Parse(_repository.FindById(id));
        }

        public List<BookVO> FindAll()
        {
            return _bookConverter.Parse(_repository.FindAll());
        }
    }
}