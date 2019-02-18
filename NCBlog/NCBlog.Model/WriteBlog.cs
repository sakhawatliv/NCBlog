using System;
using System.Collections.Generic;
using System.Text;

namespace NCBlog.Model
{
    public class WriteBlog
    {
        public int Id { get; set; }
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
        public int BlogWriterId { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool IsPublished { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int IsDelete { get; set; }
        public string DeleteBy { get; set; }
        public DateTime DeleteDate { get; set; }
    }
}
