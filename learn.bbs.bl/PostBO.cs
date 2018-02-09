using learn.bbs.bl.DTOs;
using learn.bbs.dal;
using learn.bbs.dal.EfModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn.bbs.bl
{
    public class PostBO
    {
        private PostDAO postDAO = new PostDAO();

        public IList<bbs_post> GetAllPost()
        {
            return postDAO.GetAllPost().ToList();
        }

        public IList<bbs_post> FindByCondition(Func<bbs_post, bool> f)
        {
            return GetAllPost().AsEnumerable().Where<bbs_post>(f).ToList<bbs_post>();
        }

        public void PublishPost(PostDTO dto)
        {
            var entity = new bbs_post();
            entity.title = dto.Title;
            entity.content = dto.Content;
            postDAO.AddPost(entity);
        }

        public void Delete(Guid postUid)
        {
            postDAO.DeletePost(postUid);
        }
    }
}
