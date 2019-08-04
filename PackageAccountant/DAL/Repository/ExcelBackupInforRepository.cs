using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class ExcelBackupInforRepository : RepositoryBase<ExcelBackupInfor>
    {
        public ExcelBackupInforRepository(EFPackageDbContext context) : base(context){}
    }
}
