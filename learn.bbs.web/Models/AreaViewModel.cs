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
        [DisplayName("主题名称")]
        public string area_name { get; set; }
        [Required]
        [DisplayName("开始时间")]
        public Nullable<System.DateTime> begin_time { get; set; }
        [Required]
        [DisplayName("结束时间")]
        public Nullable<System.DateTime> end_time { get; set; }
        [Required]
        [DisplayName("评价方式")]
        public Nullable<byte> appraise_type { get; set; }
        [Required]
        public Nullable<byte> is_allow_reply { get; set; }
        [Required]
        [DisplayName("主题状态啊")]
        public Nullable<byte> area_status { get; set; }
        [DisplayName("说明")]
        public string remark { get; set; }
    }
}