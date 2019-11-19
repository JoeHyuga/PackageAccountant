using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json", "multipart/form-data")]//此处为新增
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        // GET api/Login/5
        [HttpGet("Login")]
        public async Task<IActionResult> Login(string userid)
        {
            HttpContext.Session.SetString("userid", userid);
            return Ok(new { userid = userid });
        }
    }
}
