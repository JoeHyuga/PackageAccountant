﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entity
{
    public class IncomeExpenseDetails
    {
        public DateTime PTime { get; set; }
        public string PType { get; set; }
        public int AccountItermId { get; set; }
        public decimal Amount { get; set; }
        public int AccountTypeId { get; set; }
        public string Comments { get; set; }
        public DateTime UpdateDate { get; set; }
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
    }
}
