using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace learn.bbs.web.Models
{
    public class AddPostViewModel
    {
        public string AreaUid { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}