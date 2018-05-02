using learn.bbs.dal.EfModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn.bbs.dal
{
    public class ReplyDAO
    {
        public void AddReply(bbs_reply reply)
        {
            DbContextHelper.Instants.bbs_reply.Add(reply);
            DbContextHelper.Instants.SaveChanges();
        }

        public static List<bbs_reply> GetListByPostUid(Guid postUid)
        {
            return DbContextHelper.Instants.bbs_reply.AsQueryable().Where(reply => reply.post_uid == postUid).ToList();
        }
    }
}
