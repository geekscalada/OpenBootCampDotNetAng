using Ejercicio1.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio1.DataAccess
{
    public class Ejemplo1DBContext : DbContext
    {
        public Ejemplo1DBContext(DbContextOptions<Ejemplo1DBContext> options) : base(options)
        {
        }

        public DbSet<Course>? Courses { get; set; }


    }
}
