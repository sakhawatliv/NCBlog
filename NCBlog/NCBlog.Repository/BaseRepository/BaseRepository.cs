using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCBlog.Repository.DbContext;

namespace NCBlog.Repository.BaseRepository
{
    public class BaseRepository<T>:IBaseRepository<T> where T:class 
    {
        private NCBlogDbContext _naBlogDbContext;

        public BaseRepository(NCBlogDbContext ncBlogDbContext)
        {
            _naBlogDbContext = ncBlogDbContext;
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<T> Insert(T entity)
        {
            await _naBlogDbContext.AddAsync(entity);
            await _naBlogDbContext.SaveChangesAsync();
            return entity;
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public Model.UserTypes GetById(int id)
        {
            throw new NotImplementedException();
        }

        //public Model.UserTypes GetById(int id)
        //{
        //    var dd = _naBlogDbContext.UserTypeses.Where(c =>c.Id ==id).ToList();
        //    return dd;
        //}

        public ICollection<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
