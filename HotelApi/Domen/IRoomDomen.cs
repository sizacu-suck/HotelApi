namespace HotelApi.Domen
{
    public interface IRoomDomen
    {
        Task<IEnumerable<RoomClass>> GetAll();
        Task<RoomClass?> Get(int id);
        Task AddAsync(RoomClass room);
        Task<string> UpdateAsync(RoomClass room);
        Task<string> DeleteAsync(int id);
    }
}
