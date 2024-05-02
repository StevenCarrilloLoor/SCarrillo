using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCarrillo.Models
{
    public class SCarrilloModel
    {
        [Key]
        public int EstudianteId { get; set; }

        [Required]
        [Range(0, 100)]
        public int Edad { get; set; }

        [Required]
        [DecimalPrecision(18, 2)]
        public decimal Promedio { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        [Required]
        [ForeignKey("Carrera")]
        public int CarreraId { get; set; }

        public virtual Carrera Carrera { get; set; }


    }
}
