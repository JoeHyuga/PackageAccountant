using DAL.Entity;
using DAL.Entity.Result;
using DAL.Entity.Result.ChartResult;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL.IOperate
{
    public interface IIncomeExpenseDetailsBll
    {
        void Insert(DataTable data, string userid,string type);
        List<PieResult> GetAccountTypeIncomeExpensePie(int accountTypeId, DateTime pStartTime, DateTime pEndTime, string pType);
        List<LineResult> GetAccountTypeIncomeExpenseLine(int accountTypeId, DateTime pStartTime, DateTime pEndTime, string pType);

        List<IncomeExpenseResult> GetAccountSumTypeAmount(int accountTypeId, DateTime pStartTime, DateTime pEndTime, string pType);
    }
}
