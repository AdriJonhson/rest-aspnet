using System.Collections.Generic;
using RestWithAspNET.Models.Base;

namespace RestWithAspNET.Repositories.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T data);
        T Update(T data);
        void Delete(long id);
        T FindById(long id);
        List<T> FindAll();
        List<T> FindAllWithPageSearch(string query);
        int GetCount(string query);
        
        bool Exists(long id);
    }
}