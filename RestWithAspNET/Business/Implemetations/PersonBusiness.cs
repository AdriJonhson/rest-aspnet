using System.Collections.Generic;
using RestWithAspNET.Models;
using RestWithAspNET.Repositories;

namespace RestWithAspNET.Business.Implemetations
{
    public class PersonBusiness : IPersonBusiness
    {
        private readonly IPersonRepository _personRepository;
        
        public PersonBusiness(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person Create(Person person)
        {
            return _personRepository.Create(person);
        }

        public Person Update(Person person)
        {
            return _personRepository.Update(person);
        }

        public void Delete(long id)
        {
            _personRepository.Delete(id);
        }

        public Person FindById(long id)
        {
            return _personRepository.FindById(id);
        }

        public List<Person> FindAll()
        {
            return _personRepository.FindAll();
        }
    }
}