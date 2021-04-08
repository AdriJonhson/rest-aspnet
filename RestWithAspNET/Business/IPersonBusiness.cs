using System.Collections.Generic;
using RestWithAspNET.Data.VO;
using RestWithAspNET.Models;

namespace RestWithAspNET.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        void Delete(long id);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        List<PersonVO> FindByName(string firstName, string lastName);

        PersonVO Disable(long id);
    }
}