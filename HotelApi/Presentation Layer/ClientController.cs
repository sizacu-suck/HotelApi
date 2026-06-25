using HotelApi.Domen;
using HotelApi.Process_Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClienDomen clientDomen;
        public ClientController(IClienDomen _clientDomen)
        {
            clientDomen = _clientDomen;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> StatusRoom(int id)
        {
            var room = await clientDomen.CheckRoom(id);

            if (room == "объект не найден")
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> TakeRoom(int id)
        {
            var room = await clientDomen.ChangeBusy(id);

            if (room == "объект не найден")
            {
                return NotFound();
            }

            return Ok(room);

        }


    }
}
