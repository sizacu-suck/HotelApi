using HotelApi.Domen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IPosibilities roomDomen;

        public AdminController(IPosibilities _roomDomen)
        {
            roomDomen = _roomDomen;
        }

        [HttpGet]
        public async Task<IActionResult> GetallRoom()
        {

            var Rooms = await roomDomen.GetAll();
            return Ok(Rooms);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {

            var room = await roomDomen.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoomClass room)
        {

            var res = await roomDomen.CreateRoom(room);

            if (res == "У комнаты не может быть отрицательная цена")
            {
                return BadRequest(res);
            }

            return Ok(res);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RoomClass room)
        {
            var res = await roomDomen.PutRoom(room);

            if (res == "У комнаты не может быть отрицательная цена")
            {
                return BadRequest(res);
            }

            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await roomDomen.DeleteRoom(id);

            if (res == "Для удаления комната должна быть пустой")
            {
                return BadRequest(res);
            }

            return Ok(res);

        }
    }
}
