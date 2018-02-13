using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace SwaggerDemo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// Gets the APIs most valuable values
        /// </summary>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Attempts to retrieve the value identified by <code>id</code>
        /// </summary>
        /// <param name="id">the id of the value to retrieve</param>
        /// <remarks>
        /// This might take a while...
        /// </remarks>
        /// <response code="404">when the id is smaller than 42</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            await Task.Delay(1);
            if (id > 42)
            {
                return NotFound();
            }
            
            return Ok($"value {id}");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}