using HotelApi.Domen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly Iposibilities roomDomen;
        public AdminController(Iposibilities _roomDomen)
        {
            roomDomen = _roomDomen;
        }


        [HttpGet]
        public async Task<IActionResult> GetallRoom()
        {
            var allRooms = await roomDomen.GetAll();
            if (allRooms == null)
            {
                return NotFound();
            }

            return Ok(allRooms);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var Room = await roomDomen.GetRoom(id);

            if (Room == null)
            {
                return NotFound();
            }

            return Ok(Room);
        }

        [HttpPost]
        
        public async Task<IActionResult> Post([FromBody] RoomClass room)
        {
            var res = await roomDomen.CreateRoom(room);

            if (res == "У комнаты не можеть быть отрицательная цена") 
            {
                return BadRequest();
            }

            return Ok(room);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RoomClass room)
        {
            var res = await roomDomen.PutRoom(room);

            if (res == "объект не найден")
            {
                return NotFound();
            }
            if (res == "У комнаты не можеть быть отрицательная цена")
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {  
            var res = await roomDomen.DeleteRoom(id);
            if(res == "Для удаления комната должна быть пустой")
            {
                return BadRequest();
            }
            if (res == "объект не найден")
            {
                return NotFound();
            }
            return Ok();
        }
}
}
