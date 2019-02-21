using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCBlog.Models
{
    public class BlogPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        public DateTime PostDate { get; set; }
        public string PostContentId { get; set; }
        public PostCommentViewModel PostComment { get; set; }
        public string Description { get; set; }
        public int UsersId { get; set; }
        public UsersViewModel Users { get; set; }
    }
}
