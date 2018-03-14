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
                area.appraise_type = model.appraise_type;
                area.area_name = model.area_name;
                area.area_status = model.area_status;
                area.area_url = model.area_url;
                area.begin_time = model.begin_time;
                area.end_time = model.end_time;
                area.creator = this.User.Identity.Name;
                area.create_time = DateTime.Now;
                area.last_modify_time = DateTime.Now;
                area.is_allow_reply = 1;
                area.post_count = 0;
                area.remark = model.remark;
                areaBO.Add(area);
            }

            return RedirectToAction("page", new { index = 1 });
        }

        [HttpPost]
        public ActionResult Delete(string[] areaUids)
        {
            foreach (string item in areaUids)
            {
                var areaUid = Guid.Parse(item);
                areaBO.Delete(areaUid);
            }
            return RedirectToAction("page", new { index = 1 });
        }
    }
}