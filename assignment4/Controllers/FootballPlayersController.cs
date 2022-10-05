using assignment1;
using assignment4.Managers;
using Microsoft.AspNetCore.Mvc;

namespace assignment4.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class FootballPlayersController : ControllerBase
    {
        private readonly FootballPlayersManager _manager = new();

        // GET: api/<players>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<FootballPlayer>> Get()
        {
            return Ok(_manager.GetAll());
        }

        // GET api/<players>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Get(int id)
        {
            return Ok(_manager.GetById(id));
        }

        // POST api/<players>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<FootballPlayer> Post([FromBody] FootballPlayer value)
        {
            var player = _manager.Add(value);
            return Created($"api/players/{player.Id}", player);
        }

        // PUT api/<players>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Put(int id, [FromBody] FootballPlayer value)
        {
            return Ok(_manager.Update(id, value));
        }

        // DELETE api/<players>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            return Ok(_manager.Delete(id));
        }
    }
}
