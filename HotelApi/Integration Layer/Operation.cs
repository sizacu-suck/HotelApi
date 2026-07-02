using HotelApi.Domen;
using Microsoft.EntityFrameworkCore;

namespace HotelApi;

public class Operation : IRoomDomen
{
    private readonly Context context;

    public Operation(Context _context)
    {
        this.context = _context;
    }

    public async Task<IEnumerable<RoomClass>> GetAll()
    {
        return await context.Room.ToListAsync();
    }

    public async Task<RoomClass?> Get(int id)
    {
        return await context.Room.FindAsync(id);
    }

    public async Task AddAsync(RoomClass room)
    {
        await context.Room.AddAsync(room);
        await context.SaveChangesAsync();
    }

    public async Task<string> UpdateAsync(RoomClass room)
    {
        var existingRoom = await context.Room.FindAsync(room.id);
        if (existingRoom == null)
        {
            return ($"Комната не найдена");
        }

        existingRoom.description = room.description;
        existingRoom.cost = room.cost;
        existingRoom.busy = room.busy;

        await context.SaveChangesAsync();
        return ("Успешно");
    }

    public async Task<string> DeleteAsync(int id)
    {
        var room = await context.Room.FindAsync(id);
        if (room == null)
        {
            return ("Комната не найдена");
        }

        context.Room.Remove(room);
        await context.SaveChangesAsync();
        return ("Успешно");
    }
}
