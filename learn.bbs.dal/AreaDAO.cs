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
            var areas = DB.bbs_area.Where(a=>a.area_uid != Guid.Empty);
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
