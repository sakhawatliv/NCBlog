using System;
using System.Collections.Generic;
using System.Text;

namespace NCBlog.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<BlogPost> Post { get; set; }
    }
}
