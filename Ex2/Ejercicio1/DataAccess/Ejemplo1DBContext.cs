using Ejercicio2.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.Models.DataModels;

namespace Ejercicio2.DataAccess
{
    public class Ejemplo1DBContext : DbContext
    {
        public Ejemplo1DBContext(DbContextOptions<Ejemplo1DBContext> options) : base(options)
        {
        }

        public DbSet<Course>? Courses { get; set; }

        public DbSet<User>? Users { get; set; }


    }
}
