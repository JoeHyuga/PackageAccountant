using BLL.IOperate;
using Common;
using DAL;
using DAL.Entity;
using DAL.Entity.Result;
using DAL.Entity.Result.ChartResult;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class IncomeExpenseDetailsController : Controller
    {
        private readonly EFPackageDbContext _context;
        private IIncomeExpenseDetailsBll _iincomExpenseBll;

        public IncomeExpenseDetailsController(IIncomeExpenseDetailsBll iincomExpenseBll, EFPackageDbContext context)
        {
            _iincomExpenseBll = iincomExpenseBll;
            _context = context;
        }

        [HttpGet("GetIncomeExpenseForPieChart")]
        [EnableCors("any")]
        public AppResult<PieResult> GetIncomeExpenseForPieChart(string accountTypeId, string pStartTime, string pEndTime, string pType)
        {
            var result = new AppResult<PieResult>();
            if (!string.IsNullOrEmpty(accountTypeId) && !string.IsNullOrEmpty(pStartTime) && !string.IsNullOrEmpty(pEndTime) && pStartTime != "undefined" && pEndTime != "undefined")
            {
                var list = _iincomExpenseBll.GetAccountTypeIncomeExpensePie(Convert.ToInt32(accountTypeId), Convert.ToDateTime(pStartTime), Convert.ToDateTime(pEndTime), pType);
                result.list = list;
                result.count = list[0].data.Count;
            }
            return result;
        }

        [HttpGet("GetIncomeExpenseForTable")]
        [EnableCors("any")]
        public AppResult<IncomeExpenseResult> GetIncomeExpenseForTable(string accountTypeId, string pStartTime, string pEndTime, string pType)
        {
            var result = new AppResult<IncomeExpenseResult>();
            if (!string.IsNullOrEmpty(accountTypeId) && !string.IsNullOrEmpty(pStartTime) && !string.IsNullOrEmpty(pEndTime) && pStartTime != "undefined" && pEndTime != "undefined")
            {
                var list = _iincomExpenseBll.GetAccountSumTypeAmount(Convert.ToInt32(accountTypeId), Convert.ToDateTime(pStartTime), Convert.ToDateTime(pEndTime), pType);
                result.list = list;
                result.count = list.Count;
            }
            return result;
        }

        [HttpGet("GetIncomeExpenseForLineChart")]
        [EnableCors("any")]
        public AppResult<LineResult> GetIncomeExpenseForLineChart(string accountTypeId, string pStartTime, string pEndTime, string pType)
        {
            var result = new AppResult<LineResult>();
            if (!string.IsNullOrEmpty(accountTypeId) && !string.IsNullOrEmpty(pStartTime) && !string.IsNullOrEmpty(pEndTime) && pStartTime != "undefined" && pEndTime != "undefined")
            {
                var list = _iincomExpenseBll.GetAccountTypeIncomeExpenseLine(Convert.ToInt32(accountTypeId), Convert.ToDateTime(pStartTime), Convert.ToDateTime(pEndTime), pType);
                result.list = list;
                result.count = list[0].data.Count;
            }
            return result;
        }
    }
}
