using System;
using System.Collections.Generic;
using System.Linq;
using RestWithAspNET.Models;
using RestWithAspNET.Models.Context;
using RestWithAspNET.Services.Implemetations;

namespace RestWithAspNET.Services
{
    public class PersonService : IPersonService
    {
        private MySQLContext _context;
        
        public PersonService(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return person;
        }

        public Person Update(Person person)
        {
            if (!CheckExists(person.Id)) return null;

            try
            {
                var result = FindById(person.Id);

                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return person;
        }

        public void Delete(long id)
        {
            try
            {
                var result = FindById(id);

                _context.Peoples.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Person FindById(long id)
        {
            return _context.Peoples.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<Person> FindAll()
        {
            return _context.Peoples.ToList();
        }

        private bool CheckExists(long id)
        {
            return _context.Peoples.Any(p => p.Id.Equals(id));
        }
    }
}