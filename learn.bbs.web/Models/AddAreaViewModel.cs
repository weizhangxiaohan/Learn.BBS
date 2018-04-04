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
        public string AreaUrl { get; set; }

        [Required(ErrorMessage = "贴吧名称必填")]
        [StringLength(20, ErrorMessage = "{0} 的长度为2到20个字符。", MinimumLength = 2)]
        [DisplayName("贴吧名称")]
        public string AreaName { get; set; }

        [Required]
        [DataType(DataType.Date,ErrorMessage = "请输入日期")]
        [DisplayName("开始时间")]
        public Nullable<System.DateTime> BeginTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("结束时间")]
        public Nullable<System.DateTime> EndTime { get; set; }

        [Required]
        [DisplayName("评价方式")]
        public Nullable<byte> AppraiseType { get; set; }

        [Required]
        public bool IsAllowReply { get; set; }

        [Required]
        [DisplayName("贴吧状态")]
        public Nullable<byte> AreaStatus { get; set; }

        [DisplayName("说明")]
        [StringLength(400,ErrorMessage ="长度不能超过400个字符")]
        public string Remark { get; set; }
    }
}