using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NCBlog.Model;

namespace NCBlog.Api.Models.DbContext
{
    public class NCBlogDbContext:Microsoft.EntityFrameworkCore.DbContext
    {
        public NCBlogDbContext(DbContextOptions<NCBlogDbContext> options) : base(options)
        {

        }

        public DbSet<UserTypes> UserTypeses { get; set; }
    }
}
