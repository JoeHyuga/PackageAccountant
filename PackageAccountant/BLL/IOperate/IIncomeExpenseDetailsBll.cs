using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL.IOperate
{
    public interface IIncomeExpenseDetailsBll
    {
        void Insert(DataTable data, string userid,string type);
    }
}
