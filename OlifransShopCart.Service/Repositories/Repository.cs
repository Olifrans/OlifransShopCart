using Microsoft.EntityFrameworkCore;
using OlifransShopCart.DataAcsess.Entity;
using OlifransShopCart.Repo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlifransShopCart.Repo.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly OlifransDbContext _context;
        private readonly DbSet<T> entities;

        public Repository(OlifransDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
           return entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return entities.Where(x => x.Id ==id).FirstOrDefault();
        }

        public void Insert(T entity)
        {
            entities.Add(entity);
        }

        public void Save()
        {
           _context.SaveChanges();
        }

        public void Update(T entity)
        {
            entities.Update(entity);
        }
    }
}
