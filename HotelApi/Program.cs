using HotelApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddDbContext<Context>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IRoom, RoomDomen>();
builder.Services.AddScoped<RoomDomen>();
var app = builder.Build();


app.MapControllers();

app.Run();
