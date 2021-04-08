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

        public PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int currentPage)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.Equals("desc")) ? "asc" : "desc";
            var offset = currentPage > 0 ? (currentPage - 1) * pageSize : 0;
            var size = (pageSize < 1) ? 10 : pageSize;

            string query = @"SELECT * FROM peoples p WHERE 1 = 1";

            if (!string.IsNullOrWhiteSpace(name))
            {
                query += $" and p.first_name like '%{name}%' ";
            }

            query += $" order by p.first_name {sort} limit {size} offset {offset}";

            var peoples = _repository.FindAllWithPageSearch(query);
            var totalResults = peoples.Count;

            return new PagedSearchVO<PersonVO>
            {
                CurrentPage = currentPage,
                List = _personConverter.Parse(peoples),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }
    }
}