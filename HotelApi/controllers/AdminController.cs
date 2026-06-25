using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly Context dbContext;

        public AdminController(Context _db)
        {
            dbContext = _db;
        }


        [HttpGet]
        public async Task<IActionResult> GetallRoom()
        {
            var AllRoom = await dbContext.Room.AsNoTracking().ToListAsync() ;

            if(AllRoom == null)
            {
                return NotFound();
            }


            return Ok(AllRoom);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var Room = await dbContext.Room.FindAsync(id);

            if (Room == null)
            {
                return NotFound();
            }

            return Ok(Room);
        }

        [HttpPost]
        
        public async Task<IActionResult> Post([FromBody] RoomClass room)
        {
            dbContext.Room.Add(room);

            await dbContext.SaveChangesAsync();
            


            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RoomClass room)
        {
            var newRoom = await dbContext.Room.FindAsync(room.id);

            if(newRoom == null)
            {
                return NotFound();
            }

            newRoom.description = room.description;
            newRoom.cost = room.cost;
            newRoom.busy = room.busy;

            await dbContext.SaveChangesAsync();

            return Ok(newRoom);
        }
}
}
