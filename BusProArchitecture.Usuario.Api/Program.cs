
using BusProArchitecture.IOC.Dependencies;
using Microsoft.EntityFrameworkCore;
using BusProArchitecture.Usuario.Persistence.Context;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<BoletoBusContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BoletoBusContext")));

// Agregar las dependencias del modulo de buses y asientos //
builder.Services.AddReservaDependecy();













builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
