// 1. Usings to work with EntityFramework
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend;
using UniversityApiBackend.DataAccess;


// Construir configuraciones que va a usar la app
var builder = WebApplication.CreateBuilder(args);


// 2. Connection with SQL Server Express
const string CONNECTIONNAME = "UniversityDB";

// GetConnectionString busca en ConnectionStrings de appsettings
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 3. Add Context to Services of builder
// /DataAccess/UversityDBContext
// Ya tenemos el contexto y podemos generar diferentes modelos.
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Mientras estemos en desarrollo usaremos Swager para documentar
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usaremos
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

