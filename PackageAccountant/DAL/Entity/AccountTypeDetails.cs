using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entity
{
    public class AccountTypeDetails
    {
        [Key]
        public int AccountTypeId { get; set; }
        public string AccountType { get; set; }
        public string UserId { get; set; }
    }
}
