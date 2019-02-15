using System;
using System.Collections.Generic;
using System.Text;

namespace NCBlog.Model
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime RegDate { get; set; }

    }
}
