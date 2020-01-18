using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entity
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        [Key]
        public int UserId { get; set; }
    }
}
