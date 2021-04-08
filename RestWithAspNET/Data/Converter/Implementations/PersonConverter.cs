using System.Collections.Generic;
using System.Linq;
using RestWithAspNET.Data.Converter.Contract;
using RestWithAspNET.Data.VO;
using RestWithAspNET.Models;

namespace RestWithAspNET.Data.Converter.Implementations
{
    public class PersonConverter : IParse<PersonVO, Person>, IParse<Person, PersonVO>
    {
        public Person Parse(PersonVO input)
        {
            if (input == null) return null;
            
            return new Person
            {
                Id = input.Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Address = input.Address,
                Gender = input.Gender,
                Enabled = input.Enabled
            };
        }

        public List<Person> Parse(List<PersonVO> input)
        {
            return input == null ? new List<Person>() : input.Select(item => Parse(item)).ToList();
        }

        public PersonVO Parse(Person input)
        {
            if (input == null) return null;
            
            return new PersonVO
            {
                Id = input.Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Address = input.Address,
                Gender = input.Gender,
                Enabled = input.Enabled
            };
        }

        public List<PersonVO> Parse(List<Person> input)
        {
            return input == null ? new List<PersonVO>() : input.Select(item => Parse(item)).ToList();
        }
    }
}