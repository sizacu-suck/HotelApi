using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly RoomDomen roomRepository;
        public AdminController(RoomDomen _roomRepository)
        {
            roomRepository = _roomRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetallRoom()
        {
            var allRooms = await roomRepository.GetAll();
            if (allRooms == null)
            {
                return NotFound();
            }

            return Ok(allRooms);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var Room = await roomRepository.Get(id);

            if (Room == null)
            {
                return NotFound();
            }

            return Ok(Room);
        }

        [HttpPost]
        
        public async Task<IActionResult> Post([FromBody] RoomClass room)
        {
            await roomRepository.Post(room);
            return Ok(room);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RoomClass room)
        {
            var res = await roomRepository.Put(room);

            if (res == "объект не найден")
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {  
            var res = await roomRepository.Delete(id);
            
            if(res == "объект не найден")
            {
                return NotFound();
            }
            return Ok();
        }
}
}
