using AplatServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace NinjectTestAplat.Attributes
{
    public class AplatAuthorize : AuthorizeAttribute
    {
        private readonly IControleAcessoFactory factory;

        public AplatAuthorize(IControleAcessoFactory factory)
        {
            this.factory = factory;
        }

        public AplatAuthorize()
        {

        }
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var queryString = actionContext.Request
                        .GetQueryNameValuePairs()
                        .ToDictionary(x => x.Key, x => x.Value);
            IControleAcesso acesso = this.factory.Create(queryString["name"], queryString["tokenCA"], queryString["tokenAplat"]);
           
            if (AuthorizeRequest(actionContext))
            {
                return;
            }

            HandleUnauthorizedRequest(actionContext);
        }

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //Code to handle unauthorized request
        }

        private bool AuthorizeRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {

            //Write your code here to perform authorization
            return true;
        }
    }
}
