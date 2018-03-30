using learn.bbs.dal.EfModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn.bbs.dal
{
    public class AreaDAO
    {
        public BbsContext DB
        {
            get
            {
                return BbsDbContext.Instants;
            }
        }

        public IQueryable<bbs_area> GetAllArea()
        {
            var areas = DB.bbs_area.AsNoTracking().Where(a=>a.area_uid != Guid.Empty);
            return areas;
        }

        public void AddArea(bbs_area area)
        {
            DB.bbs_area.Add(area);
            DB.SaveChanges();
        }

        public void EditArea(bbs_area area)
        {
            var entity = DB.bbs_area.Where(a => a.area_uid == area.area_uid).First();

            entity.appraise_type = area.appraise_type;
            entity.area_name = area.area_name;
            entity.area_status = area.area_status;
            entity.area_url = area.area_url;
            entity.begin_time = area.begin_time;
            entity.create_time = area.create_time;
            entity.creator = area.creator;
            entity.creator_uid = area.creator_uid;
            entity.end_time = area.end_time;
            entity.is_allow_reply = area.is_allow_reply;
            entity.last_modify_time = area.last_modify_time;
            entity.last_modify_user = area.last_modify_user;
            entity.last_modify_user_uid = area.last_modify_user_uid;
            entity.remark = area.remark;


            DB.Entry<bbs_area>(entity).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }

        public void DeleteArea(Guid areaUid)
        {
            var model = DB.bbs_area.FirstOrDefault(a => a.area_uid == areaUid);
            DB.bbs_area.Remove(model);
            DB.SaveChanges();
        }
    }
}
