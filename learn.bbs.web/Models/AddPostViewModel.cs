using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace learn.bbs.web.Models
{
    public class AddPostViewModel
    {
        public string AreaUid { get; set; }
        [DisplayName("标题")]
        [Required]
        [StringLength(20)]
        public string Title { get; set; }
        [DisplayName("内容")]
        [Required]
        public string Content { get; set; }
    }
}