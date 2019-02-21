using System;
using System.Collections.Generic;
using System.Text;

namespace NCBlog.Model
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime PostDate { get; set; }
        public string PostContentId { get; set; }
        public PostComment PostComment { get; set; }
        public string Description { get; set; }
        public int UsersId { get; set; }
        public Users Users { get; set; }
    }
}
