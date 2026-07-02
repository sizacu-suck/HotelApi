using HotelApi.Domen;

namespace HotelApi.Business_Layer
{
    public class Posibilities : IPosibilities
    {
        private readonly IRoomDomen _roomRepository; 

        public Posibilities(IRoomDomen roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<string> CheckRoom(int id)
        {
            var room = await _roomRepository.Get(id);

            if (room == null)
            {
                return  "Комната не найдена";
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
                return "У комнаты не может быть отрицательная цена";
            }
            
            await _roomRepository.AddAsync(room);
            return "Комната успешно создана";
        }

        public async Task<string> DeleteRoom(int id)
        {
            var room = await _roomRepository.Get(id);

            if (room == null)
            {
                return ("Комната не найдена");
            }
            
            if (room.busy == true)
            {
                 return("Для удаления комната должна быть пустой");
            }

            await _roomRepository.DeleteAsync(id);
            return "Комната успешно удалена";
        }

        public async Task<IEnumerable<RoomClass>> GetAll()
        {
            return await _roomRepository.GetAll();
        }

        public async Task<RoomClass?> GetRoom(int id)
        {
            var room = await _roomRepository.Get(id);
            
            if (room == null)
            {
                return null;
            }
            
            return room;
        }

        public async Task<string> PutRoom(RoomClass room)
        {
            if (room.cost <= 0)
            {
                return ("У комнаты не может быть отрицательная цена");
            }
            
            await _roomRepository.UpdateAsync(room);
            return "Комната успешно изменена";
        }

        public async Task<string> TakeRoom(int id)
        {
            var room = await _roomRepository.Get(id);

            if (room == null)
            {
                return ($"Комната не найдена");
            }

            if (room.busy == true)
            {
                return ("Комната уже забронирована");
            }
            
            room.busy = true;
            await _roomRepository.UpdateAsync(room);

            return "Комната успешно вами забронирована";
        }
    }
}
