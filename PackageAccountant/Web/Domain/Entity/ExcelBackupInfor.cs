using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Domain.Entity
{
    public class ExcelBackupInfor
    {
        public DateTime backupdate { get; set; }
        public string backuppath { get; set; }
        public string size { get; set; }
    }
}
