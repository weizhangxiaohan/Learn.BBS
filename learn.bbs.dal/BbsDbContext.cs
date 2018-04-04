using learn.bbs.dal.EfModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn.bbs.dal
{
    public class DbContextHelper
    {
        private static BbsContext _context = null;

        public static BbsContext Instants
        {
            get
            {
                if (_context == null)
                {
                    _context = new BbsContext();
                }
                return _context;
            }
        }
    }
}
