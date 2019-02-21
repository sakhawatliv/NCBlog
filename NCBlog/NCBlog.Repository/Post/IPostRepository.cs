using System;
using System.Collections.Generic;
using System.Text;
using NCBlog.Model;
using NCBlog.Repository.BaseRepository;

namespace NCBlog.Repository.Post
{
    public interface IPostRepository:IBaseRepository<BlogPost>
    {
    }
}
