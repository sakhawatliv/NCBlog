using System;
using System.Collections.Generic;
using System.Text;
using NCBlog.Repository.DbContext;

namespace NCBlog.Repository.BaseRepository
{
    public class BaseRepository
    {
        private NCBlogDbContext _naBlogDbContext;

        public BaseRepository(NCBlogDbContext ncBlogDbContext)
        {
            _naBlogDbContext = ncBlogDbContext;
        }


    }
}
