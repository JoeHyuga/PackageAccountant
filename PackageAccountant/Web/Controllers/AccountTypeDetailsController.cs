using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL.Entity;
using Common;
using DAL;
using BLL.IOperate;
using Microsoft.AspNetCore.Cors;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class AccountTypeDetailsController : Controller
    {
        private readonly EFPackageDbContext _context;
        private IAccountTypeDetailsBll _iaccounttypeBll;

        public AccountTypeDetailsController(IAccountTypeDetailsBll iaccounttypeBll, EFPackageDbContext context)
        {
            _iaccounttypeBll = iaccounttypeBll;
            _context = context;
        }

        [HttpGet("GetAccountType")]
        [EnableCors("any")]
        public AppResult<AccountTypeDetails> GetAccountType()
        {
            var result = new AppResult<AccountTypeDetails>();
            result.list = _iaccounttypeBll.AccountTypeDetails();
            return result;
        }
    }
}
