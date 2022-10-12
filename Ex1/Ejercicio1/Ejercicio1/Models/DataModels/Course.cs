using System.ComponentModel.DataAnnotations;

namespace Ejercicio1.Models.DataModels
{
    public class Course : BaseModel
    {
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(280)]
        public string DescripcionCorta { get; set; } = string.Empty;

        public string DescripcionLarga  { get; set; } = string.Empty;

        public string PublicoObjetivo { get; set; } = string.Empty;
        public string Objetivos { get; set; } = string.Empty;

        public string Requisitos { get; set; } = string.Empty;

        public Nivel Nivel { get; set; } = Nivel.Basico;     


    }

    public enum Nivel
    {
        Basico,
        Intermedio,
        Avanzado
    }
}





