using BLL.IOperate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DAL;
using DAL.Entity;

namespace BLL.Operate
{
    public class IncomeExpenseDetailsBll : BaseBll, IIncomeExpenseDetailsBll
    {
        public IncomeExpenseDetailsBll(EFPackageDbContext options) : base(options) { }

        public void Insert(DataTable data, string userid,string type)
        {
            CleanData();
            var list = new List<IncomeExpenseDetails>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var entity = new IncomeExpenseDetails()
                {
                    PTime = Convert.ToDateTime(data.Rows[i]["时间"]),
                    Amount = Convert.ToDecimal(data.Rows[i]["金额"]),
                    Comments = data.Rows[i]["备注"].ToString(),
                    PType = data.Rows[i]["收支类型"].ToString(),
                    AccountItermId = GetAccountItermId(data.Rows[i]["账目分类"].ToString()),
                    AccountTypeId = GetAccountTypeId(data.Rows[i]["账户"].ToString()),
                    UserId = userid
                };
                unit.IncomeExpenseDetailsRepository.Insert(entity);
            }
            unit.saveChange();
        }

        public int GetAccountItermId(string item)
        {
            var list=unit.AccountItermDetailsRepository.Get(p=>p.AccountIterm==item);
            return list.AccountItermId;
        }

        public int GetAccountTypeId(string type)
        {
            var list = unit.AccountTypeDetailsRepository.Get(p=>p.AccountType==type);
            return list.AccountTypeId;
        }

        public void CleanData()
        {
            unit.IncomeExpenseDetailsRepository.ExecStroedProcedure("EXEC spTruncate 'IncomeExpenseDetails' ");
        }
    }
}
