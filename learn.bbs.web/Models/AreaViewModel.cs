using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace learn.bbs.web.Models
{
    public class AreaViewModel
    {
        public string area_url { get; set; }
        [StringLength(20, ErrorMessage = "{0} 的長度至少必須為 {2} 個字。", MinimumLength = 2)]
        public string area_name { get; set; }
        [Required]
        public Nullable<System.DateTime> begin_time { get; set; }
        [Required]
        public Nullable<System.DateTime> end_time { get; set; }
        [Required]
        public Nullable<byte> appraise_type { get; set; }
        [Required]
        public Nullable<byte> is_allow_reply { get; set; }
        [Required]
        public Nullable<byte> area_status { get; set; }
        
        public string remark { get; set; }
    }
}