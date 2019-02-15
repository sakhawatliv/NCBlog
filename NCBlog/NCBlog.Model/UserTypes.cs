using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace NCBlog.Model
{
    public class UserTypes
    {
        
        public int Id { get; set; }
        [Required]
        public string TypeName { get; set; }
    }
}
