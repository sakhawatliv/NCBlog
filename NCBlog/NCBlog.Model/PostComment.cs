﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NCBlog.Model
{
    public class PostComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }

    }
}
