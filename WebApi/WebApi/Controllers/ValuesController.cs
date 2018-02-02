using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        private ICustService Cust;
        public ValuesController(ICustService cust)
        {
            this.Cust = cust;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { Cust.getCust1(), Cust.getCust2() };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
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
