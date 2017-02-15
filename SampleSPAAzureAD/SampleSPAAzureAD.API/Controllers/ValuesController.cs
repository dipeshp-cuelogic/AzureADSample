using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace SampleSPAAzureAD.API.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            var adminGroupId = ConfigurationManager.AppSettings["ida:GroupId"];
            Claim groupAdmin = ClaimsPrincipal.Current.Claims.FirstOrDefault(x => x.Type == "groups" && x.Value.Equals(adminGroupId, StringComparison.InvariantCulture));
            if(groupAdmin != null)
            {
                return Ok("admin");
            } 
            return Unauthorized();
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
