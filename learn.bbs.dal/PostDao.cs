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
            var posts = DbContextHelper.Instants.bbs_post.Where(a => a.post_uid != Guid.Empty);
            return posts;
        }

        public void AddPost(bbs_post post)
        {
            DbContextHelper.Instants.bbs_post.Add(post);
            DbContextHelper.Instants.SaveChanges();
        }

        public void DeletePost(Guid postUid)
        {
            var model = DbContextHelper.Instants.bbs_post.FirstOrDefault(a => a.post_uid == postUid);
            DbContextHelper.Instants.bbs_post.Remove(model);
            DbContextHelper.Instants.SaveChanges();
        }
    }
}
