using Microsoft.EntityFrameworkCore;

namespace HotelApi.Domen
{
    public interface IClienDomen
    {
        public Task<string> ChangeBusy(int id);
        public Task<string> CheckRoom(int id);
    }
}
