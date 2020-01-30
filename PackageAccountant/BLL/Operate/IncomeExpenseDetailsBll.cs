using BLL.IOperate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DAL;

namespace BLL.Operate
{
    public class IncomeExpenseDetailsBll : BaseBll, IIncomeExpenseDetailsBll
    {
        public IncomeExpenseDetailsBll(EFPackageDbContext options) : base(options) { }

        public void Insert(DataTable data, string userid,string type)
        {
            
        }

        public void CleanData(DataTable dt, string userid)
        {

        }
    }
}
