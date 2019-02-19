using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCBlog.Repository.BaseRepository
{
    public interface IBaseRepository<T>:IDisposable where T:class
    {
        T GetById(int id);
        IList<T> GetAll();
        void Insert(T entity);
        T Update(T entity);
        
    }
}
