namespace HotelApi
{
    public interface IRoom
    {
        Task<IEnumerable<RoomClass>> GetAll();
        Task<RoomClass?> Get(int id);
        Task Post(RoomClass room);
        Task<string> Put(RoomClass room);
        Task<string> Delete(int id);
        Task<string> ChangeBusy(int id);
        Task<string> CheckRoom(int id);
    }
}
