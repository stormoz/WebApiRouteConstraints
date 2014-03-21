using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RouteConstraints.Models;

namespace RouteConstraints.Controllers
{
    public class ValuesController : ApiController
    {
        MyViewModel model = new MyViewModel { Name = "Foo", Flag = true };

        // GET api/values
        public IEnumerable<MyViewModel> Get()
        {
            yield return model;
        }

        // GET api/values/5
        public MyViewModel Get(int id)
        {
            return model;
        }

        // Post api/values/5 {name: "any"; flag:true}
        public void Post(int id, [FromBody]MyViewModel value)
        {
            //update whole
        }

        // Post api/values/5 {name: "any"; flag:true}
        public void Put(int id, [FromBody]MyViewModel value)
        {
            //update whole
        }

        // PUT api/values/5 {flag:true}
        [HttpPut]
        [HttpPatch]
        public void Patch(int id, [FromBody]MyViewModel value)
        {
            //update partial
        }
    }
}