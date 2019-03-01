using NCBlog.Repository.BaseRepository;
using NCBlog.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCBlog.Repository.User
{
   public class UsersRepository : BaseRepository<Model.Users>, IUsersRepository
    {
        public UsersRepository(NCBlogDbContext ncBlogDbContext) : base(ncBlogDbContext)
        {
        }
    }
}
