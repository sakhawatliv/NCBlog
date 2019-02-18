using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCBlog.Repository.BaseRepository
{
    public interface IBaseRepository<T>:IDisposable where T:class
    {
        Task<T> Insert(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        Model.UserTypes GetById(int id);
        ICollection<T> GetAll();
    }
}
