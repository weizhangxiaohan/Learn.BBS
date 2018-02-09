using learn.bbs.bl;
using learn.bbs.bl.DTOs;
using learn.bbs.dal.EfModel;
using learn.bbs.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace learn.bbs.web.Controllers
{
    public class PostController : Controller
    {
        private PostBO postBO = new PostBO();

        [HttpPost]
        [Route("post/page")]
        public ActionResult Add(AddPostViewModel model)
        {
            var postDTO = new PostDTO();
            postDTO.Title = model.Title;
            postDTO.Content = model.Content;
            postBO.PublishPost(postDTO);

            return RedirectToAction("page");
        }

        // GET: Post
        public ActionResult List()
        {
            return View();
        }

        [Route("post/page")]
        public ActionResult GetPostsByPage()
        {
            var model = postBO.GetAllPost().Take(10).ToList();
            return View("List",model);
        }
    }
}