using learn.bbs.bl;
using learn.bbs.bl.DTOs;
using learn.bbs.dal.EfModel;
using learn.bbs.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using learn.bbs.utility;

namespace learn.bbs.web.Controllers
{
    public class PostController : Controller
    {
        private PostBO postBO = new PostBO();

        public ActionResult Add(Guid areaUid)
        {
            ViewBag.AreaUid = areaUid;
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var postDTO = new PostInfo();
                postDTO.Title = model.Title;
                postDTO.Content = model.Content;
                postDTO.AreaUid = Guid.Parse(model.AreaUid);
                postDTO.Creator = this.User.Identity.Name;
                postBO.PublishPost(postDTO);
            }

            return RedirectToAction("GetPostsOfAreaByPage", new { areaUid = model.AreaUid, pageIndex = 1 });
        }

        // GET: Post
        public ActionResult List()
        {
            return View();
        }

        [Route("post/page")]
        public ActionResult GetPostsByPage(int pageIndex)
        {
            var model = postBO.GetAllPost().OrderByDescending(p => p.last_reply_time).ToPagedList(pageIndex, 10);
            return View("List", model);
        }

        public ActionResult GetPostsOfAreaByPage(Guid areaUid, int pageIndex)
        {
            ViewBag.AreaUid = this.ControllerContext.HttpContext.Request.QueryString["areaUid"];
            var model = postBO.GetPostByArea(areaUid).OrderByDescending(p => p.last_reply_time).ToPagedList(pageIndex, 10);
            return View("List", model);
        }


        public ActionResult Detail(Guid postUid)
        {
            var entity = postBO.GetAllPost()
                .AsQueryable()
                .Where(p => p.post_uid == postUid)
                .FirstOrDefault();

            var vm = new PostDetailViewModel();
            vm.PostUid = entity.post_uid;
            vm.AreaUid = entity.area_uid;
            vm.Title = entity.title;
            vm.Content = entity.content;
            vm.Author = entity.creator;
            vm.CreateTime = entity.create_time;
            vm.Replys = ReplyBO.GetListByPostUid(postUid).Select(a => new ReplyViewModel
            {
                Content = a.Content
            }).ToList();

            return View("Detail", vm);
        }

        [Authorize(Users = "admin")]
        public ActionResult Delete(Guid postUid, Guid areaUid)
        {
            postBO.Delete(postUid);
            return RedirectToAction("GetPostsOfAreaByPage", new { areaUid = areaUid, pageIndex = 1 });
        }

        [HttpPost]
        public JsonResult Reply(string postUid, string content)
        {
            LogHelper.LogToFile(postUid + ":" + content);
            ReplyBO replyBO = new ReplyBO();
            replyBO.PostUid = Guid.Parse(postUid);
            replyBO.Content = content;
            replyBO.Add();
            return Json(replyBO);
        }
    }
}