﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Common.ICommon;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json", "multipart/form-data")]//此处为新增
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ValuesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        #region example
        // GET api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "ddddd", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        #endregion

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> UploadFiles([FromForm]IFormCollection formData)
        {
            IFormFileCollection files = formData.Files;//等价于Request.Form.Files

            long size = files.Sum(f => f.Length);
            string webRootPath = _hostingEnvironment.WebRootPath;
            string connectRootPath = _hostingEnvironment.ContentRootPath;

            foreach (var formFile in files)
            {
                var arry = formFile.FileName.Split('.');
                string fileExt = arry[arry.Length-1]; //文件扩展名，不含“.”
                long fileSize = formFile.Length; //获得文件大小，以字节为单位
                string newFileName = System.Guid.NewGuid().ToString() + "." + fileExt; //随机生成新的文件名
                var filePath = webRootPath.Split("\\")[0] + "\\upload\\" + newFileName;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
            return Ok(new { count = files.Count, size });
        }
    }
}