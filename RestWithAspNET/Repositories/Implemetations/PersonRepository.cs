using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using RestWithAspNET.Models;
using RestWithAspNET.Models.Context;

namespace RestWithAspNET.Repositories.Implemetations
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(MySQLContext context) : base(context)
        {
        }

        public Person Disable(long id)
        {
            if (!Exists(id)) return null;

            var user = FindById(id);

            if (user != null)
            {
                user.Enabled = false;
                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return user;
        }

        public List<Person> FindByName(string firstName, string lastName)
        {
            List<Person> persons = new List<Person>();
            
            
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                persons =  _context.Peoples
                    .Where(p => p.FirstName.Contains(firstName) && p.LastName.Contains(lastName))
                    .ToList();    
            }
            else if (!string.IsNullOrWhiteSpace(firstName)) {
                persons =  _context.Peoples
                    .Where(p => p.FirstName.Contains(firstName))
                    .ToList();    
            }
            else if (!string.IsNullOrWhiteSpace(lastName))
            {
                persons =  _context.Peoples
                    .Where(p => p.LastName.Contains(lastName))
                    .ToList();    
            }

            return persons;
        }

        public List<Person> FindAllNew()
        {
            IEnumerable<Person> peoples;
            using (var connection = new MySqlConnection("Server=db;Database=rest_with_asp_net;Uid=root;Pwd=docker;SslMode=none"))
            {
                peoples = connection.Query<Person>(@"SELECT * FROM peoples");
            }

            return peoples.ToList();
        }
    }
}