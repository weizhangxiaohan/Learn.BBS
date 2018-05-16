using learn.bbs.bl;
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
    public class AreaController : Controller
    {
        private AreaDO areaBO = new AreaDO();
        private static int _pageSize = 10;

        [HttpPost]
        public ActionResult Search(string area_name, byte? area_status,int pageIndex = 1)
        {
            throw new Exception("你4谁");

            //var model = areaBO.FindByCondition(area => area.area_name.Contains(area_name))
            //    .Where(a => a.area_status == area_status)
            //    .Take(_pageSize)
            //    .ToList();
            var model = areaBO.GetAllArea();
            if (!string.IsNullOrEmpty(area_name))
            {
                model = model.Where(area => area.area_name.Contains(area_name));
            }
            if (area_status != null)
            {
                model = model.Where(a => a.area_status == area_status);
            }
            model = model.OrderByDescending(a => a.create_time);

            return PartialView("_ListPartView", model.ToPagedList(pageIndex, _pageSize));
        }

        [Authorize(Users = "admin")]     
        public ActionResult GetAreasByPage(int pageIndex = 1)
        {
            var model = areaBO.GetAllArea()
                .OrderByDescending(a => a.last_modify_time)
                .ToPagedList(pageIndex, _pageSize);
            return View("List", model);
        }

        [Route("area/mine/{index:int?}")]
        public ActionResult GetMyAreasByPage(int index = 1)
        {
            var model = areaBO.GetAllArea()
                .OrderByDescending(a => a.last_modify_time)
                .Skip((index - 1) * _pageSize)
                .Take(_pageSize)
                .ToList();
            return View("MyAreaList", model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddAreaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var area = new bbs_area();
                area.area_uid = Guid.NewGuid();
                area.appraise_type = model.AppraiseType;
                area.area_name = model.AreaName;
                area.area_status = model.AreaStatus;
                area.area_url = model.AreaUrl;
                area.begin_time = model.BeginTime;
                area.end_time = model.EndTime;
                area.creator = this.User.Identity.Name;
                area.create_time = DateTime.Now;
                area.last_modify_time = DateTime.Now;
                area.is_allow_reply = (byte)(model.IsAllowReply ? 1 : 0);
                area.post_count = 0;
                area.remark = model.Remark;
                areaBO.Add(area);
            }

            return RedirectToAction("GetAreasByPage", new { pageIndex = 1 });
        }

        public ActionResult Edit(Guid areaUid)
        {
            var entity = areaBO.FindByCondition(a=>a.area_uid == areaUid).First();
            var vm = new EditAreaViewModel();
            vm.AreaUid = entity.area_uid;
            vm.AreaName = entity.area_name;
            vm.AppraiseType = entity.appraise_type;
            vm.AreaStatus = entity.area_status;
            vm.AreaUrl = entity.area_url;
            vm.BeginTime = entity.begin_time;
            vm.EndTime = entity.end_time;
            vm.IsAllowReply = entity.is_allow_reply == 1;
            vm.Remark = entity.remark;
            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(EditAreaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var area = new bbs_area();
                area.area_uid = model.AreaUid;
                area.appraise_type = model.AppraiseType;
                area.area_name = model.AreaName;
                area.area_status = model.AreaStatus;
                area.area_url = model.AreaUrl;
                area.begin_time = model.BeginTime;
                area.end_time = model.EndTime;
                area.creator = this.User.Identity.Name;
                area.create_time = DateTime.Now;
                area.last_modify_time = DateTime.Now;
                area.is_allow_reply = (byte)(model.IsAllowReply ? 1 : 2);
                area.post_count = 0;
                area.remark = model.Remark;
                areaBO.Edit(area);
            }

            return RedirectToAction("GetAreasByPage", new { pageIndex = 1 });
        }

        [HttpPost]
        public void Delete(string[] areaUids)
        {
            foreach (string item in areaUids)
            {
                var areaUid = Guid.Parse(item);
                areaBO.Delete(areaUid);
            }
        }
    }
}