using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NCBlog.Repository.DbContext;

namespace NCBlog.Repository.BaseRepository
{
    public class BaseRepository<T>:IBaseRepository<T> where T:class
    {
        protected NCBlogDbContext _dbContext;
        public BaseRepository(NCBlogDbContext context)
        {
            _dbContext = context;
        }

        public DbSet<T> Table
        {
            get { return _dbContext.Set<T>(); }
        }
        public void Insert(T entity)
        {
            var item = Table.Add(entity);
            _dbContext.SaveChanges();

        }
        public T Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }
        public T GetById(int id)
        {
            var item = Table.Find(id);
            return item;
        }
        public IList<T> GetAll()
        {
            var list = Table.ToList();
            return list;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
