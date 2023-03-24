using CRUD_Productos_GML.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

//bloquear las Corns
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
    {
        builder.WithOrigins("http://localhost:5051").AllowAnyMethod().AllowAnyHeader();
    });
});

// leer el archivo de configuracion de la cadena de configuracion
var connectionString = builder.Configuration.GetConnectionString("conexion");
//Agregar el servicio de la BD
builder.Services.AddDbContext<DBContext>(x => x.UseSqlServer(connectionString));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DBContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins); // esto se debe implementar igual con los cors para el Ajax

app.UseAuthorization();

app.MapControllers();

app.Run();
