using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entity
{
    public class AccountItermDetails
    {
        [Key]
        public string AccountItermId { get; set; }

        public string AccountIterm { get; set; }
    }
}
