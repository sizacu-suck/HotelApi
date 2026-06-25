using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly Context dbContext;

        public ClientController(Context _db)
        {
            dbContext = _db;
        }

        [HttpGet]
        public async Task<IActionResult> StatusRoom(int id)
        {
            var room = await dbContext.Room.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            if (room.busy == true)
            {
                return BadRequest("Комната занята");
            }


            return Ok("Комната не занята");
        }

        [HttpPatch]
        public async Task<IActionResult> TakeRoom(int id)
        {
            var room = await dbContext.Room.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            if (room.busy == true)
            {
                return BadRequest("Комната занята");
            }
            
            room.busy = true;
            
            await dbContext.SaveChangesAsync();

            return Ok("Комната забронирована");

        }


    }
}
