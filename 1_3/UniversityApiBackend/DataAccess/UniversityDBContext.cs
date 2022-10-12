using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.DataAccess
{

    // Extendemos el DBContext de Microsoft. 
    public class UniversityDBContext: DbContext
    {
        // Constructor
        // Mismo tipo que la clase. 
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options): base(options)
        {

        }

        // Add DbSets (Tables of our Data base)
        // En las migraciones estas entidades se convertirán en tablas
        // También aparecerá en el diagrama de EF core tools generate DbContext
        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Student>? Students { get; set; }
    }
}


