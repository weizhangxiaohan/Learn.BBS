using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace learn.bbs.web.Models
{
    public class PostDetailViewModel
    {
        public Guid PostUid { get; set; }
        public Guid? AreaUid { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}