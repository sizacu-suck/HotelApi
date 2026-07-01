using HotelApi.Domen;

namespace HotelApi.Business_Layer
{
    public class Posibilities : Iposibilities
    {
        private readonly IRoomDomen _roomRepository; // Зависим только от интерфейса репозитория

        public Posibilities(IRoomDomen roomRepository)
        {
            _roomRepository = roomRepository;
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

        public async Task<string> CreateRoom(RoomClass room)
        {
            if (room.cost <= 0)
            {
                return "У комнаты не можеть быть отрицательныя цена";
            }
            await _roomRepository.Post(room);
            return "Комната успешно создана";

        }

        public async Task<string> DeleteRoom(int id)
        {
            var room = await _roomRepository.Get(id);

            if (room == null)
            {
                return "объект не найден";
            }
            if (room.busy == true)
            {
                return "Для удаления комната должна быть пустой";
            }

            return await _roomRepository.Delete(id);
        
        }

        public async Task<IEnumerable<RoomClass>> GetAll()
        {
            return await _roomRepository.GetAll();
        }

        public async Task<string> PutRoom(RoomClass room)
        {
            if (room.cost <= 0)
            {
                return "У комнаты не может быть отрицательныя цена";
            }
            await _roomRepository.Put(room);
            return "Комната успешно создана";
        }

        public async Task<string> TakeRoom(int id)
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
    }
}
