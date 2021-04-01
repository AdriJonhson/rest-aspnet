using System.Collections.Generic;
using RestWithAspNET.Models;

namespace RestWithAspNET.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
        Person FindById(long id);
        List<Person> FindAll();
    }
}