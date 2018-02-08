using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace learn.bbs.web.Models
{
    public class AddAreaViewModel
    {
        public string area_url { get; set; }

        [Required(ErrorMessage = "主题名称必填")]
        [StringLength(20, ErrorMessage = "{0} 的长度为2到20个字符。", MinimumLength = 2)]
        [DisplayName("主题名称")]
        public string area_name { get; set; }

        [Required]
        [DataType(DataType.Date,ErrorMessage = "请输入日期")]
        [DisplayName("开始时间")]
        public Nullable<System.DateTime> begin_time { get; set; }

        [Required]
        [DataType(DataType.Date)]
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
        [StringLength(400,ErrorMessage ="长度不能超过400个字符")]
        public string remark { get; set; }
    }
}