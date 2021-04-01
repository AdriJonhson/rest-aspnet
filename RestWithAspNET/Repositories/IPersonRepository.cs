using System.Collections.Generic;
using RestWithAspNET.Models;

namespace RestWithAspNET.Repositories
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
        Person FindById(long id);
        List<Person> FindAll();
        bool Exists(long id);
    }
}