using System.ComponentModel.DataAnnotations;

namespace SCarrillo.Models
{
    public class Carrera
    {
        [Key]
        public int Id { get; set; }
        public string nombre_Carrera { get; set; }
        public string campus { get; set; }
        public int numero_Carrera { get; set; }

    }
}
