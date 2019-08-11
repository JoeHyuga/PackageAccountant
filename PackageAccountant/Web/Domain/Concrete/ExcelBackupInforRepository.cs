using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Entity;

namespace Web.Domain.Concrete
{
    public class ExcelBackupInforRepository
    {
        EFDbContext _db = new EFDbContext();
        public bool Add(ExcelBackupInfor excel)
        {
            var entity = new ExcelBackupInfor()
            {
                backupdate = excel.backupdate,
                backuppath = excel.backuppath,
                size = excel.size
            };
            _db.ExcelBackupInfor.Add(entity);
            var i = _db.SaveChanges();
            return i > 0 ? true : false;
        }
    }
}
