using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.DataAccess
{
    public class UniversityDBContext: DbContext
    {

        // Además de de loggear en base de datos a través de serilog y de las appsetting
        // también podemos loggear eventos que están ocurriendo en la BDD a través de EF core. 
        // es decir de las operaciones en la BDD con EF Core
        // Se hace con esta config. 


        private readonly ILoggerFactory _loggerFactory;


        public UniversityDBContext(DbContextOptions<UniversityDBContext> options, ILoggerFactory loggerFactory): base(options)
        {
            _loggerFactory = loggerFactory;
        }

        // Add DbSets (Tables of our Data base)
        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Student>? Students { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var logger = _loggerFactory.CreateLogger<UniversityDBContext>();
            // optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }));
            // optionsBuilder.EnableSensitiveDataLogging();


            // Estaríamos filtrando los logs de information, y luego le decimos que nos añada
            // los datos de esos logs y que en caso de que haya errores sean muy detallados
            optionsBuilder.LogTo
                (d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }
}


