using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly RoomDomen roomDomen;
        public ClientController( RoomDomen _roomDomen)
        {
            roomDomen = _roomDomen;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> StatusRoom(int id)
        {
            var room = await roomDomen.CheckRoom(id);

            if (room == "объект не найден")
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> TakeRoom(int id)
        {
            var room = await roomDomen.ChangeBusy(id);

            if (room == "объект не найден")
            {
                return NotFound();
            }

            return Ok(room);

        }


    }
}
