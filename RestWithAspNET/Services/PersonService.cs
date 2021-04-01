using System.Collections.Generic;
using RestWithAspNET.Models;
using RestWithAspNET.Services.Implemetations;

namespace RestWithAspNET.Services
{
    public class PersonService : IPersonService
    {
        public Person Create(Person person)
        {
            return person;
        }

        public Person Update(Person person)
        {
            return person;
        }

        public void Delete(long id)
        { }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Maria",
                LastName = "Silva",
                Address = "FortalCity - Brazil",
                Gender = "Female"
            };
        }

        public List<Person> FindAll()
        {
            List<Person> peoples = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                peoples.Add(MockPerson(i));
            }

            return peoples;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = i,
                FirstName = "Person FirstName " + i,
                LastName = "Person LastName " + i,
                Address = "Person Address " + i,
                Gender = "Person Gender " + i
            };
        }
    }
}