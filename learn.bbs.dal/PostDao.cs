using learn.bbs.dal.EfModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn.bbs.dal
{
    public class PostDAO
    {
        public IEnumerable<bbs_post> GetAllPost()
        {
            var posts = BbsDbContext.Instants.bbs_post.Where(a => a.post_uid != Guid.Empty).ToList();
            return posts;
        }

        public void AddPost(bbs_post post)
        {
            BbsDbContext.Instants.bbs_post.Add(post);
            BbsDbContext.Instants.SaveChanges();
        }

        public void DeletePost(Guid postUid)
        {
            var model = BbsDbContext.Instants.bbs_post.FirstOrDefault(a => a.post_uid == postUid);
            BbsDbContext.Instants.bbs_post.Remove(model);
            BbsDbContext.Instants.SaveChanges();
        }
    }
}
