using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Http;
using BLL.IOperate;
using DAL.Entity.Result;
using DAL.Entity.Result.ChartResult;
using Common;

namespace BLL.Operate
{
    public class IncomeExpenseDetailsBll : BaseBll, IIncomeExpenseDetailsBll
    {
        public IncomeExpenseDetailsBll(EFPackageDbContext options) : base(options) { }

        public void Insert(DataTable data, string userid, string type)
        {
            try
            {
                CleanData();
                var list = new List<IncomeExpenseDetails>();
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    var entity = new IncomeExpenseDetails()
                    {
                        PTime = ConvertChineseDateToYYYYMMDD(data.Rows[i]["时间"].ToString()),
                        Amount = Convert.ToDecimal(data.Rows[i]["金额"]),
                        Comments = data.Rows[i]["备注"].ToString(),
                        PType = data.Rows[i]["收支类型"].ToString(),
                        AccountItermId = GetAccountItermId(data.Rows[i]["账目分类"].ToString()),
                        AccountTypeId = GetAccountTypeId(data.Rows[i]["账户"].ToString()),
                        UserId = userid,
                        UpdateDate = DateTime.Now
                    };
                    unit.IncomeExpenseDetailsRepository.Insert(entity);
                }
                unit.saveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 将dd-m月-yyyy格式转换为yyyy-MM-dd
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTime ConvertChineseDateToYYYYMMDD(string date)
        {
            return Convert.ToDateTime(date);
        }

        public int GetAccountItermId(string item)
        {
            var list = unit.AccountItermDetailsRepository.Get(p => p.AccountIterm == item);
            return list.AccountItermId;
        }

        public int GetAccountTypeId(string type)
        {
            var list = unit.AccountTypeDetailsRepository.Get(p => p.AccountType == type);
            return list.AccountTypeId;
        }

        public void CleanData()
        {
            unit.IncomeExpenseDetailsRepository.ExecStroedProcedure("EXEC spTruncate 'IncomeExpenseDetails' ");
        }

        public List<PieResult> GetAccountTypeIncomeExpensePie(int accountTypeId, DateTime pStartTime, DateTime pEndTime, string pType)
        {
            var incomeExpenseResult = SumTypeAmount(accountTypeId, pStartTime, pEndTime, pType);

            List<PieResult> result = new List<PieResult>();
            List<string> label = new List<string>();
            List<decimal> data = new List<decimal>();
            var background = new ChartHelp().GetRandomColor(incomeExpenseResult.Count);
            foreach (var I in incomeExpenseResult)
            {
                label.Add(I.AccountIterm);
                data.Add(I.Amount);
            }

            result.Add(new PieResult
            {
                backgroundColor = background,
                labels = label,
                data = data
            });
            return result;
        }

        public List<IncomeExpenseResult> SumTypeAmount(int accountTypeId, DateTime pStartTime, DateTime pEndTime, string pType)
        {
            var list = unit.IncomeExpenseDetailsRepository.GetAllList(p => p.AccountTypeId == accountTypeId && (p.PTime <= pEndTime && p.PTime >= pStartTime) && p.PType == pType);

            var incomeExpense = (from de in list
                                 group de by new
                                 {
                                     de.PType,
                                     de.AccountItermId,
                                     de.AccountTypeId
                                 } into t
                                 select new IncomeExpenseDetails
                                 {
                                     PType = t.Key.PType,
                                     AccountItermId = t.Key.AccountItermId,
                                     AccountTypeId = t.Key.AccountTypeId,
                                     Amount = t.Sum(x => x.Amount)
                                 }).ToList();

            var accountIterm = unit.AccountItermDetailsRepository.GetAllList();

            var accountType = unit.AccountTypeDetailsRepository.GetAllList();

            var incomeExpenseResult = (from a in incomeExpense
                                       join b in accountIterm on a.AccountItermId equals b.AccountItermId
                                       join c in accountType on a.AccountTypeId equals c.AccountTypeId
                                       select new IncomeExpenseResult
                                       {
                                           AccountItermId = a.AccountItermId,
                                           Amount = a.Amount,
                                           AccountTypeId = a.AccountTypeId,
                                           AccountIterm = b.AccountIterm,
                                           AccountType = c.AccountType,
                                           PTime = a.PTime,
                                           PType = a.PType
                                       }).ToList();

            return incomeExpenseResult;
        }

        public List<IncomeExpenseResult> GetAccountSumTypeAmount(int accountTypeId, DateTime pStartTime, DateTime pEndTime, string pType)
        {
            var incomeExpenseResult = SumTypeAmount(accountTypeId, pStartTime, pEndTime, pType);
            var total = incomeExpenseResult.Sum(p => p.Amount);

            var result = (from a in incomeExpenseResult
                          select new IncomeExpenseResult
                          {
                              AccountItermId = a.AccountItermId,
                              Amount = a.Amount,
                              AccountTypeId = a.AccountTypeId,
                              AccountIterm = a.AccountIterm,
                              PTime = a.PTime,
                              PType = a.PType,
                              AccountType = a.AccountType,
                              StrPercentage = Math.Round((a.Amount / total * 100), 2).ToString() + "%",
                              Percentage= Math.Round((a.Amount / total * 100), 2)
                          }).ToList();

            return result.OrderByDescending(p=>p.Percentage).ToList();
        }

        public List<IncomeExpenseResult> SumTypeAmount2(int accountTypeId, DateTime pStartTime, DateTime pEndTime, string pType)
        {
            var list = unit.IncomeExpenseDetailsRepository.GetAllList(p => p.AccountTypeId == accountTypeId && (p.PTime <= pEndTime && p.PTime >= pStartTime) && p.PType == pType);

            var incomeExpense = (from de in list
                                 group de by new
                                 {
                                     de.PType,
                                     de.AccountTypeId
                                 } into t
                                 select new IncomeExpenseDetails
                                 {
                                     PType = t.Key.PType,
                                     AccountTypeId = t.Key.AccountTypeId,
                                     Amount = t.Sum(x => x.Amount)
                                 }).ToList();

            var accountType = unit.AccountTypeDetailsRepository.GetAllList();

            var incomeExpenseResult = (from a in incomeExpense
                                       join c in accountType on a.AccountTypeId equals c.AccountTypeId
                                       select new IncomeExpenseResult
                                       {
                                           AccountItermId = a.AccountItermId,
                                           Amount = a.Amount,
                                           AccountTypeId = a.AccountTypeId,
                                           AccountType = c.AccountType,
                                           PTime = a.PTime,
                                           PType = a.PType
                                       }).ToList();

            return incomeExpenseResult;
        }

        public List<LineResult> GetAccountTypeIncomeExpenseLine(int accountTypeId, DateTime pStartTime, DateTime pEndTime, string pType)
        {
            throw new NotImplementedException();
        }
    }
}
