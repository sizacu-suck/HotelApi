using Microsoft.EntityFrameworkCore;

namespace HotelApi.Domen
{
    public interface IRoomDomen
    {
        public  Task<IEnumerable<RoomClass>> GetAll();

        public  Task<RoomClass?> Get(int id);

        public  Task Post(RoomClass room);
        public  Task<string> Put(RoomClass room);
        public  Task<string> Delete(int id);
    }
}
