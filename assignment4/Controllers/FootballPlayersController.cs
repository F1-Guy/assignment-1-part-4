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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<FootballPlayer>> Get()
        {
            var players = _manager.GetAll();

            if (players.Any())
                return Ok(players);

            return NoContent();
        }

        // GET api/<players>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Get(int id)
        {
            try
            {
                return Ok(_manager.GetById(id));
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException)
                    return BadRequest(ex.Message);

                return NotFound(ex.Message);
            }
        }

        // POST api/<players>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FootballPlayer> Post([FromBody] FootballPlayer value)
        {
            try
            {
                var player = _manager.Add(value);
                return Created($"api/players/{player.Id}", player);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<players>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Put(int id, [FromBody] FootballPlayer value)
        {
            try
            {
                return Ok(_manager.Update(id, value));
            }
            catch (Exception ex)
            {
                if (ex is ArgumentOutOfRangeException)
                    return BadRequest(ex.Message);

                return NotFound(ex.Message);
            }
        }

        // Add error checking to DELETE and DO TESTS

        // DELETE api/<players>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            try
            {
                return Ok(_manager.Delete(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
