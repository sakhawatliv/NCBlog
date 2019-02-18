using System;
using System.Collections.Generic;
using System.Text;
using NCBlog.Repository.BaseRepository;
using NCBlog.Repository.DbContext;

namespace NCBlog.Repository.UserTypes
{
    public class UserTypesRepository:BaseRepository<Model.UserTypes>,IUserTypesRepository
    {
        public UserTypesRepository(NCBlogDbContext ncBlogDbContext) : base(ncBlogDbContext)
        {
        }
    }
}
