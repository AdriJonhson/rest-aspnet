using System.Collections.Generic;
using System.Linq;
using RestWithAspNET.Data.Converter.Contract;
using RestWithAspNET.Data.VO;
using RestWithAspNET.Models;

namespace RestWithAspNET.Data.Converter.Implementations
{
    public class BookConverter : IParse<BookVO, Book>, IParse<Book, BookVO>
    {
        private readonly CategoryConverter _categoryConverter;

        public BookConverter()
        {
            _categoryConverter = new CategoryConverter();
        }

        public Book Parse(BookVO input)
        {
            if (input == null) return null;
            
            return new Book
            {
                Id = input.Id,
                Title = input.Title,
                Author = input.Author,
                LaunchDate = input.LaunchDate,
                Price = input.Price
            };
        }

        public List<Book> Parse(List<BookVO> input)
        {
            return input == null ? new List<Book>() : input.Select(item => Parse(item)).ToList();
        }

        public BookVO Parse(Book input)
        {
            if (input == null) return null;
            
            return new BookVO
            {
                Id = input.Id,
                Title = input.Title,
                Author = input.Author,
                LaunchDate = input.LaunchDate,
                Price = input.Price,
                Category = _categoryConverter.Parse(input.Category)
            };
        }

        public List<BookVO> Parse(List<Book> input)
        {
            return input == null ? new List<BookVO>() : input.Select(item => Parse(item)).ToList();
        }
    }
}