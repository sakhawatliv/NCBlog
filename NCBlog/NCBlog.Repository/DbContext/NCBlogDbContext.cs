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

        public DbSet<Model.UserTypes> UserTypeses { get; set; }
        public DbSet<WriteBlog> WriteBlogs { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        
    }
}
