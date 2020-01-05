using log4net;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Common.log4net
{
    public class HttpGlobalExceptionFilter: IExceptionFilter
    {
        private ILog log=LogManager.GetLogger(Startup.repository.Name, typeof(HttpGlobalExceptionFilter));

        public void OnException(ExceptionContext context)
        {
            log.Error("context：" + context);
            log.Error("context.Exception.Message：" + context.Exception.Message??"");
            log.Error("context.Exception.InnerException.Message：" + context.Exception.InnerException.Message??"");
        }
    }
}
