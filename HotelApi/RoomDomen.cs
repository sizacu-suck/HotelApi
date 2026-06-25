
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace HotelApi;

public class RoomDomen 
{
    private readonly Context context;

    public RoomDomen(Context _context)
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

    public async Task Post(RoomClass room)
    {
        await context.Room.AddAsync(room);
        await context.SaveChangesAsync();
    }

    public async Task<string> Put(RoomClass room)
    {
        var newRoom = await context.Room.FindAsync(room.id);
        if (newRoom == null)
        {
            return "объект не найден";
        }
        newRoom.description = room.description;
        newRoom.cost = room.cost;
        newRoom.busy = room.busy;

        await context.SaveChangesAsync();

        return "Комната успешно изменена";

    }
    public async Task<string> Delete(int id)
    {
        var room = await context.Room.FindAsync(id);

        if (room == null)
        {
            return "объект не найден";
        }

        context.Room.Remove(room);

        await context.SaveChangesAsync();

        return "Комната успешно удалена";
    }
    public async Task<string> ChangeBusy(int id)
    {
        var room = await context.Room.FindAsync(id);

        if (room == null)
        {
            return "объект не найден";
        }

        if (room.busy == true)
        {
            return "Комната уже забронирована";
        }
        room.busy = true;
        await context.SaveChangesAsync();

        return "Комната успешно вами забронирована";
    }
    public async Task<string> CheckRoom(int id)
    {
        var room = await context.Room.FindAsync(id);

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

