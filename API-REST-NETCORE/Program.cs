using Microsoft.EntityFrameworkCore;
using Core.Helpers;
using Core.BL.Interfaces;
using Core.BL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Cadena de conexion
ContextConfiguration.ConexionCadena = builder.Configuration.GetConnectionString("cadenaSQL");

// Se hace la instancia a las interfaces y servicios a traves de inyeccion 
builder.Services.AddTransient<ICotizacion, CotizacionServices>();
builder.Services.AddTransient<IAmortizacion, AmortizacionServices>();


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
