using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Domain.Entity
{
    public class AccountItermDetails
    {
        [Key]
        public string AccountItermId { get; set; }

        public string AccountIterm { get; set; }
    }
}
