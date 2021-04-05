using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestWithAspNET.Models.Base;
using RestWithAspNET.Models.Context;
using RestWithAspNET.Repositories.Generic;

namespace RestWithAspNET.Repositories.Implemetations
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySQLContext _context;

        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = context.Set<T>();
        }

        public T Create(T data)
        {
            try
            {
                dataset.Add(data);
                _context.SaveChanges();
                
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public T Update(T data)
        {
            try
            {
                var result = FindById(data.Id);

                _context.Entry(result).CurrentValues.SetValues(data);
                _context.SaveChanges();
                
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Delete(long id)
        {
            try
            {
                var result = FindById(id);

                if (result != null)
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public bool Exists(long id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }
    }
}