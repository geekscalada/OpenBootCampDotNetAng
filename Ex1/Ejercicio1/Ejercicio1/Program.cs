
using Ejercicio1.DataAccess;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Conn string

const string NAMECONN = "Ejemplo1";
var connectionString = builder.Configuration.GetConnectionString(NAMECONN);



// Adding context to services builder

builder.Services.AddDbContext<Ejemplo1DBContext>(options => 
    
    options.UseSqlServer(connectionString)
    
);



// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
