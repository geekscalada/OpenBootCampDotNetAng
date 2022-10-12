using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    // Es una clase Base, tendrá todos los requisitos que el resto
    // de tablas va a tener
    public class BaseEntity
    {
        [Required]
        [Key]
        // Este campo es requerido y es un Key.
        public int Id { get; set; }

        // CreatdBy No acepta valores null porque es un string, entonces
        // cuando sale del constructor debe de ser algo no nulo
        // Podríamos ahcerlo opcional (nullable)
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; } = string.Empty;
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
