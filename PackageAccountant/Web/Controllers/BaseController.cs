using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        protected bool isLogin
        {
            get {
                string username = null;
                username=HttpContext.Session.GetString("username");
                return string.IsNullOrEmpty(username);
            }
        }
    }
}
