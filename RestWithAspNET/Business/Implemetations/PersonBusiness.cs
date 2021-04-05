using System.Collections.Generic;
using RestWithAspNET.Models;
using RestWithAspNET.Repositories.Generic;

namespace RestWithAspNET.Business.Implemetations
{
    public class PersonBusiness : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;
        
        public PersonBusiness(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }
    }
}