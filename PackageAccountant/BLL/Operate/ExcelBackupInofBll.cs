using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Operate
{
    public class ExcelBackupInofBll
    {

        private EFPackageDbContext _context=null;
        public ExcelBackupInofBll(EFPackageDbContext context)
        {
            _context = context;
        }
        public void Insert(ExcelBackupInfor entity)
        {
            var unit =new UnitOfWork(_context);
            /*
             do some operation for this program
             */
            unit.ExcelBackupInforRepository.Insert(entity);
            unit.saveChange();
        }
    }
}
