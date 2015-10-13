sdfsdfsf

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwinSelfHost
{
    /// <summary>
    /// This is controller summary 555
    /// </summary>
    [RoutePrefix("api/myController")]
    public class ValueController : ApiController
    {
        /// <summary>
        /// This is action summary 111
        /// </summary>
        /// <remarks>Action remarks 111</remarks>
        /// <response code="502">Account created 502</response>
        /// <response code="400">Username already in use444</response>
        /// <response code="201">Account created 201</response>
        /// <response code="202">Account created 202</response>
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

        
        /// <summary>
        /// Get action summary
        /// </summary>
        /// <param name="id">This is parameter summary 111</param>
        /// <returns>Some value 111</returns>
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