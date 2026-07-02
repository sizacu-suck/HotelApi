namespace HotelApi.Domen
{
    public interface IPosibilities
    {
        Task<string> TakeRoom(int id);
        Task<string> CheckRoom(int id);
        Task<IEnumerable<RoomClass>> GetAll();
        Task<string> CreateRoom(RoomClass room);
        Task<string> PutRoom(RoomClass room);
        Task<string> DeleteRoom(int id);
        public Task<RoomClass?> GetRoom(int id);

    }
}
