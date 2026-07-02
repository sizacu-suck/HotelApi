using HotelApi.Domen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IPosibilities clientDomen;

        public ClientController(IPosibilities _clientDomen)
        {
            clientDomen = _clientDomen;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> StatusRoom(int id)
        {
            var room = await clientDomen.CheckRoom(id);

            if (room == "Комната не найдена")
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> TakeRoom(int id)
        {

            var room = await clientDomen.TakeRoom(id);

            if (room == "Комната не найдена")
            {
                return NotFound();
            }
            if (room == "Комната уже забронирована")
            {
                return BadRequest(room);
            }
            return Ok(room);

        }
    }
}
