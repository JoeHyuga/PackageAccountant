using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BLL.Operate;
using Microsoft.AspNetCore.Hosting;
using DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json", "multipart/form-data")]//此处为新增
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly EFPackageDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(IHostingEnvironment hostingEnvironment, EFPackageDbContext context,IHttpContextAccessor httpContextAccessor)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string username)
        {
            var result=new UserInfoBll(_context,_httpContextAccessor).SetUserSession(username);
            
            return Ok(new { username = username,result=result });
        }
    }
}
