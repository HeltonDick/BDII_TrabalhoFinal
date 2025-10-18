using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class Assento
    {
        [Key]
        public int Id { get; set; }
        public int SalaDoCinemaId { get; set; }
        // Propriedade de Navegação
        [ForeignKey(nameof(SalaDoCinemaId))]
        public SalasDoCinema? SalasDoCinema { get; set; }
    }
}
