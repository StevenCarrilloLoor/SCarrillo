using System.ComponentModel.DataAnnotations;

namespace SCarrillo.Models
{
    public class Carrera
    {
        [Key]
        public int CarreraId { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCarrera { get; set; }

        [Required]
        [StringLength(100)]
        public string Campus { get; set; }

        [Required]
        [Range(1, 12)]
        public int NumeroSemestres { get; set; }

    }
}
