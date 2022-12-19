using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity.Result
{
    public class IncomeExpenseResult
    {
        public DateTime PTime { get; set; }
        public string PType { get; set; }
        public int AccountItermId { get; set; }
        public decimal Amount { get; set; }
        public int AccountTypeId { get; set; }
        public string AccountType { get; set; }
        public string AccountIterm { get; set; }

        public decimal Percentage { get; set; }
        public string StrPercentage { get; set; }
    }
}
