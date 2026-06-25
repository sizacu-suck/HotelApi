
using HotelApi.Domen;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Process_Logic
{
    public class ClientDomen : IClienDomen
    {
        private readonly IRoomDomen _roomRepository;

        public ClientDomen(IRoomDomen roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<string> ChangeBusy(int id)
        {
            var room = await _roomRepository.Get(id);

            if (room == null)
            {
                return "объект не найден";
            }

            if (room.busy == true)
            {
                return "Комната уже забронирована";
            }
            room.busy = true;
            await _roomRepository.Put(room);

            return "Комната успешно вами забронирована";
        }
        public async Task<string> CheckRoom(int id)
        {
            var room = await _roomRepository.Get(id);

            if (room == null)
            {
                return "объект не найден";
            }

            if (room.busy == true)
            {
                return "Комната уже забронирована";
            }

            return "Комната не забронирована";
        }
    }
}
