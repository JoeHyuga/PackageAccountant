using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Operate
{
    public class BaseBll
    {
        public EFPackageDbContext _context = null;
        public UnitOfWork unit=null;
        public BaseBll(EFPackageDbContext context)
        {
            _context = context;
            unit = new UnitOfWork(_context);
        }

    }
}
