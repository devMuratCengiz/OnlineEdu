using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DataAccess.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly OnlineEduContext _context;

        public GenericRepository(OnlineEduContext context)
        {
            _context = context;
        }

        public DbSet<T> Table { get=> _context.Set<T>(); }
        public int Count()
        {
            return Table.Count();
        }

        public void Create(T entity)
        {
            Table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var value = Table.Find(id);
            if(value ==null)
            {
                throw new KeyNotFoundException(id + " id için kayıt bulunamadı.");
            }
            Table.Remove(value);
            _context.SaveChanges();
        }

        public int FilteredCount(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).Count();
        }

        public T GetByFilter(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).FirstOrDefault();    
        }

        public T GetById(int id)
        {
            var value = Table.Find(id);
            if (value == null)
            {
                throw new KeyNotFoundException(id + " id için kayıt bulunamadı.");
            }
            return value;
        }

        public List<T> GetFilteredList(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).ToList();
        }

        public List<T> GetList()
        {
            var values = Table.ToList();
            if(values == null)
            {
                throw new KeyNotFoundException("Veri bulunamadı");
            }
            return values;
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            Table.Update(entity);
            _context.SaveChanges();
        }
    }
}
