using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entity
{
    public class ExcelBackupInfor
    {
        public DateTime backupdate { get; set; }
        public string backuppath { get; set; }
        public string size { get; set; }
        [Key]
        public int id { get; set; }
    }
}
