using System;
using System.Collections.Generic;
using System.Linq;
using RestWithAspNET.Models;
using RestWithAspNET.Models.Context;

namespace RestWithAspNET.Repositories.Implemetations
{
    public class BookRepository : IBookRepository    {
        private readonly MySQLContext _context;
        
        public BookRepository(MySQLContext context)
        {
            _context = context;
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return book;
        }

        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return null;

            try
            {
                var result = FindById(book.Id);

                _context.Entry(result).CurrentValues.SetValues(book);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return book;
        }

        public void Delete(long id)
        {
            try
            {
                var result = FindById(id);

                _context.Books.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Book FindById(long id)
        {
            return _context.Books.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public bool Exists(long id)
        {
            return _context.Books.Any(p => p.Id.Equals(id));
        }
    }
}