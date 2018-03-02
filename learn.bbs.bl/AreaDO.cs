using learn.bbs.dal;
using learn.bbs.dal.EfModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn.bbs.bl
{
    public class AreaDO
    {
        private AreaDAO areaDAO = new AreaDAO();

        public IList<bbs_area> GetAllArea()
        {
            return areaDAO.GetAllArea().ToList();
        }

        public IList<bbs_area> FindByCondition(Func<bbs_area, bool> f)
        {
            return GetAllArea().AsEnumerable().Where<bbs_area>(f).ToList<bbs_area>();
        }

        public void Add(bbs_area area)
        {
            areaDAO.AddArea(area);
        }

        public void Delete(Guid areaUid)
        {
            areaDAO.DeleteArea(areaUid);
        }
    }
}
