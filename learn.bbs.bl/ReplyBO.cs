using learn.bbs.dal;
using learn.bbs.dal.EfModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn.bbs.bl
{
    public class ReplyBO
    {
        public Guid PostUid { get; set; }
        public string Content { get; set; }

        private ReplyDAO replyDAO = new ReplyDAO();

        public void Add()
        {
            bbs_reply reply = new bbs_reply();
            reply.post_uid = PostUid;
            reply.reply_uid = Guid.NewGuid();
            reply.content = Content;
            replyDAO.AddReply(reply);
        }

        public static List<ReplyBO> GetListByPostUid(Guid postUid )
        {
            List<bbs_reply> replys =  ReplyDAO.GetListByPostUid(postUid);

            return replys.Select(a => new ReplyBO
            {
                 PostUid = a.post_uid.Value,
                 Content = a.content
            }).ToList();
        }
    }
}
