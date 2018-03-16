﻿using learn.bbs.bl;
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

namespace learn.bbs.web.Controllers
{
    public class PostController : Controller
    {
        private PostBO postBO = new PostBO();

        [Route("post/{areaUid}/add")]
        public ActionResult Add(Guid areaUid)
        {
            ViewBag.AreaUid = areaUid;
            return View("Add");
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

            return Redirect(string.Format("/post/{0}/page/1", model.AreaUid));
        }

        // GET: Post
        public ActionResult List()
        {
            return View();
        }

        [Route("post/page")]
        public ActionResult GetPostsByPage(int pageIndex)
        {
            var model = postBO.GetAllPost().OrderByDescending(p => p.last_reply_time).ToPagedList(pageIndex,10);
            return View("List", model);
        }

        public ActionResult GetPostsOfAreaByPage(Guid areaUid, int pageIndex)
        {
            //ViewBag.AreaUid = this.ControllerContext.HttpContext.Request.QueryString[""];
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
            vm.Title = entity.title;
            vm.Content = entity.content;
            vm.Author = entity.creator;
            vm.CreateTime = entity.create_time;

            return View("Detail", vm);
        }
    }
}