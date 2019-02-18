using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NCBlog.Model;

namespace NCBlog.Repository.DbContext
{
    public class NCBlogDbContext:Microsoft.EntityFrameworkCore.DbContext
    {
        public NCBlogDbContext(DbContextOptions<NCBlogDbContext> options) : base(options)
        {

        }

        public DbSet<UserTypes> UserTypeses { get; set; }
        public DbSet<WriteBlog> WriteBlogs { get; set; }
    }
}
