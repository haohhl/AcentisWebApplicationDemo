using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Repository
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
    public class Repository<T> : IRepository<T> where T:class
    {
        private readonly ApplicationContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public Repository(ApplicationContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = this._dbContext.Set<T>();
        }
        
        public IEnumerable<T> GetAll()
        {
            return this._dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            this._dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            this._dbSet.Attach(entity);
            this._dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            this._dbSet.Remove(entity);
        }
    }
}
