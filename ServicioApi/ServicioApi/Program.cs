using Microsoft.EntityFrameworkCore;
using ServicioLibrary.Models;
using ServicioLibrary.Repositories;
using ServicioLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddScoped<IServicioRepository, ServicioRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<db_turnosContext>(options =>
options
.UseSqlServer(builder.Configuration
.GetConnectionString("DefaultConnection")));//Inyecta la conexion con un scoped.

builder.Services.AddScoped<IServicioService, ServicioService>();
builder.Services.AddScoped<IServicioRepository, ServicioRepository>();
builder.Services.AddScoped<ITurnoService, TurnoService>();
builder.Services.AddScoped<ITurnoRepository, TurnoRepository>();    

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
