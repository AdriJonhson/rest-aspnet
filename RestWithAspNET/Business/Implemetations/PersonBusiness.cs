using System.Collections.Generic;
using RestWithAspNET.Data.Converter.Implementations;
using RestWithAspNET.Data.VO;
using RestWithAspNET.Models;
using RestWithAspNET.Repositories;
using RestWithAspNET.Repositories.Generic;

namespace RestWithAspNET.Business.Implemetations
{
    public class PersonBusiness : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        private readonly PersonConverter _personConverter;
        
        public PersonBusiness(IPersonRepository repository)
        {
            _repository = repository;
            _personConverter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            Person result = _repository.Create(_personConverter.Parse(person));

            return _personConverter.Parse(result);
        }

        public PersonVO Update(PersonVO person)
        {
            Person result = _repository.Update(_personConverter.Parse(person));

            return _personConverter.Parse(result);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public PersonVO FindById(long id)
        {
            return _personConverter.Parse(_repository.FindById(id));
        }

        public List<PersonVO> FindAll()
        {
            return _personConverter.Parse(_repository.FindAll());
        }

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _personConverter.Parse(_repository.FindByName(firstName, lastName));
        }

        public PersonVO Disable(long id)
        {
            return _personConverter.Parse(_repository.Disable(id));
        }
    }
}