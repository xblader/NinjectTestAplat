using AplatServices;
using log4net;
using Ninject.Web.WebApi.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace NinjectTestAplat.Attributes
{
    public class LogFilter : AbstractActionFilter
    {
        private readonly IControleAcessoFactory factory;
        private readonly string prefix;

        public LogFilter(IControleAcessoFactory factory)
        {
            this.factory = factory;
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
            //var queryString = actionContext.Request
            //            .GetQueryNameValuePairs()
            //            .ToDictionary(x => x.Key, x => x.Value);
            //IControleAcesso acesso = this.factory.Create(queryString["name"]);
            //this.log.DebugFormat(
            //    "Executing action {0}.{1}",
            //    actionContext.ActionDescriptor.ControllerDescriptor.ControllerName,
            //    actionContext.ActionDescriptor.ActionName);
        }

        public override void OnActionExecuted(System.Web.Http.Filters.HttpActionExecutedContext actionExecutedContext)
        {
            //this.log.DebugFormat(
            //    "Executed action {0}.{1}",
            //    actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName,
            //    actionExecutedContext.ActionContext.ActionDescriptor.ActionName);
        }
    }
}
