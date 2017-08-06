using AplatServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NinjectTestAplat.Controllers
{
    //[LogFilter]
    public class ValuesController : ApiController
    {
        private IPermissaoService _service;
        public ValuesController(IPermissaoService service)
        {
            this._service = service;
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
