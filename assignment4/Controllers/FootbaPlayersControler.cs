using Microsoft.AspNetCore.Mvc;

namespace assignment4.Controllers
{
    [Route("api/Players")]
    [ApiController]
    public class FootbaPlayersControler : ControllerBase
    {
        // GET: api/<Players>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Players>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Players>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Players>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Players>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
