using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCBlog.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<BlogPostViewModel> Post { get; set; }
    }
}
