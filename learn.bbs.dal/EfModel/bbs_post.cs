//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace learn.bbs.dal.EfModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class bbs_post
    {
        public System.Guid post_uid { get; set; }
        public Nullable<System.Guid> area_uid { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public Nullable<System.Guid> creator_uid { get; set; }
        public string creator { get; set; }
        public Nullable<System.DateTime> create_time { get; set; }
        public Nullable<int> visit_times { get; set; }
        public Nullable<int> reply_times { get; set; }
        public Nullable<int> like_times { get; set; }
        public Nullable<int> star_times { get; set; }
        public Nullable<int> recommend_times { get; set; }
        public Nullable<System.DateTime> last_reply_time { get; set; }
        public Nullable<System.DateTime> last_update_time { get; set; }
    }
}