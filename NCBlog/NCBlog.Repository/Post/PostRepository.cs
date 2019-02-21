using System;
using System.Collections.Generic;
using System.Text;
using NCBlog.Model;
using NCBlog.Repository.BaseRepository;
using NCBlog.Repository.DbContext;

namespace NCBlog.Repository.Post
{
    public class PostRepository:BaseRepository<BlogPost>,IPostRepository
    {
        public PostRepository(NCBlogDbContext context) : base(context)
        {
        }
    }
}
