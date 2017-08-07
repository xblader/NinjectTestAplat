using AplatServices;
using Ninject;
using NinjectTestAplat.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NinjectTestAplat.Controllers
{
    //[AplatAuthorize]
    public class ValuesController : ApiController
    {
        private IPermissaoService _service;
        private IControleAcesso acesso;
        public ValuesController(IPermissaoService service, IControleAcesso acesso)
        {
            this._service = service;
            this.acesso = acesso;
        }

        public ValuesController()
        {

        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // GET api/values/5
        public string Get(string teste)
        {
            return "value 4";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
