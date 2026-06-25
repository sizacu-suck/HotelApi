using HotelApi;
using HotelApi.Domen;
using HotelApi.Process_Logic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddDbContext<Context>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IClienDomen, ClientDomen>();


builder.Services.AddScoped<IRoomDomen, RoomDomen>();


var app = builder.Build();


app.MapControllers();

app.Run();
