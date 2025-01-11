using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// SERVICES

// Add CORS service
builder.Services.AddCors();

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// MIDDLEWARE
// Add CORS middleware (put this before app.MapControllers())
app.UseCors(policy => policy
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithOrigins("http://localhost:4200", "https://localhost:4200")); // Your Angular app URL

app.MapControllers();

// Run the application
app.Run();
