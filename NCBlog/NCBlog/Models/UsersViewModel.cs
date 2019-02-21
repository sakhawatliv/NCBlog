using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCBlog.Models
{
    public class UsersViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime RegDate { get; set; }
        public int UserTypesId { get; set; }
        public UserTypesViewModel UserTypes { get; set; }
        public List<BlogPostViewModel> Posts { get; set; }
    }
}
