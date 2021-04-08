using RestWithAspNET.Data.VO;
using RestWithAspNET.Models;
using RestWithAspNET.Repositories.Generic;

namespace RestWithAspNET.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
    }
}