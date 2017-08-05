using log4net;
using Ninject.Web.WebApi.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace NinjectTestAplat.Attributes
{
    public class LogFilter : AbstractActionFilter
    {
        private readonly ILog log;
        private readonly string prefix;

        public LogFilter(ILog log)
        {
            this.log = log;
        }

        public override bool AllowMultiple
        {
            get
            {
                return true;
            }
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            this.log.DebugFormat(
                "Executing action {0}.{1}",
                actionContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                actionContext.ActionDescriptor.ActionName);
        }

        public override void OnActionExecuted(System.Web.Http.Filters.HttpActionExecutedContext actionExecutedContext)
        {
            this.log.DebugFormat(
                "Executed action {0}.{1}",
                actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                actionExecutedContext.ActionContext.ActionDescriptor.ActionName);
        }
    }
}
