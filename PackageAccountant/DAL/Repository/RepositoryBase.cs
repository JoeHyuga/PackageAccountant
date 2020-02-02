using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repository
{
    public class RepositoryBase<T>:IRepository<T> where T:class
    {
        public readonly EFPackageDbContext _dbContext=null;
        public readonly DbSet<T> _dbSet;

        public RepositoryBase(EFPackageDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }
        public IQueryable<T> GetAllList(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _dbSet;
            }
            return _dbSet.Where(predicate);
        }
        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void ExecStroedProcedure(string sql)
        {
           // _dbSet.FromSqlRaw(sql);
        }
    }
}
