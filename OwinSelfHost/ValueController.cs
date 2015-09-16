using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwinSelfHost
{
    public class ValueController : ApiController
    {
        // GET api/values 
        public async Task<IEnumerable<Model>> Get()
        {
            return await Task.FromResult(new[]
            {
                new Model
                {
                    FirstName = "Dragon",
                    LastName = "Andrei",
                    Age = 22
                }
            });
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