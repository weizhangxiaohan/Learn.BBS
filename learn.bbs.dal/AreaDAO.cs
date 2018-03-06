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
        public IQueryable<bbs_area> GetAllArea()
        {
            var areas = BbsDbContext.Instants.bbs_area.Where(a=>a.area_uid != Guid.Empty);
            return areas;
        }

        public void AddArea(bbs_area area)
        {
            BbsDbContext.Instants.bbs_area.Add(area);
            BbsDbContext.Instants.SaveChanges();
        }

        public void DeleteArea(Guid areaUid)
        {
            var model = BbsDbContext.Instants.bbs_area.FirstOrDefault(a => a.area_uid == areaUid);
            BbsDbContext.Instants.bbs_area.Remove(model);
            BbsDbContext.Instants.SaveChanges();
        }
    }
}
