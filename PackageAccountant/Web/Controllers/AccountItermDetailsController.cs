using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Web.Domain.Concrete;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class AccountItermDetailsController : Controller
    {
        private readonly EFDbContext _eFDbContext;
        public AccountItermDetailsController(EFDbContext eFDbContext)
        {
            _eFDbContext = eFDbContext;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var list = _eFDbContext.AccountItermDetails.ToList();
            return "value"+id+list.Count().ToString();
        }
    }
}
