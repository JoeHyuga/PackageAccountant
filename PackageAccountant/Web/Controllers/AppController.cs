using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL.Entity;
using Common;
using DAL;
using BLL.IOperate;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class AppController : Controller
    {
        private readonly EFPackageDbContext _context;
        private IMenuBll _imenuBll;

        public AppController(IMenuBll menuBll, EFPackageDbContext context)
        {
            _imenuBll = menuBll;
            _context = context;
        }

        [HttpGet("GetMenuList")]
        public AppResult<Menu> GetMenuList()
        {
            var result = new AppResult<Menu>();
            result.list = _imenuBll.GetMenuList();
            return result;
        }
    }
}
