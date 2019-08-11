using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Operate
{
    public class ExcelBackupInofBll:BaseBll
    {
        public ExcelBackupInofBll(EFPackageDbContext context) : base(context) { }
        public void Insert(ExcelBackupInfor entity)
        {
            unit.ExcelBackupInforRepository.Insert(entity);
            unit.saveChange();
        }
    }
}
