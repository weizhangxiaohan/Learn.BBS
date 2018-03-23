using learn.bbs.dal;
using learn.bbs.dal.EfModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace learn.bbs.bl
{
    public class AreaDO
    {
        private AreaDAO areaDAO = new AreaDAO();

        public IQueryable<bbs_area> GetAllArea()
        {
            //return areaDAO.GetAllArea().ToList();
            return areaDAO.GetAllArea();
        }

        public IQueryable<bbs_area> FindByCondition(Expression<Func<bbs_area,  bool>> predicate)
        {
            return GetAllArea().Where<bbs_area>(predicate);
        }

        public void Add(bbs_area area)
        {
            areaDAO.AddArea(area);
        }

        public void Edit(bbs_area area)
        {
            areaDAO.EditArea(area);
        }

        public void Delete(Guid areaUid)
        {
            areaDAO.DeleteArea(areaUid);
        }
    }
}
