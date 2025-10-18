using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class SalasPadrao
    {
        [Key]
        public int Id { get; set; }
        public int Capacidade { get; set; }
        public int TipoDaSalaId { get; set; }
        // Propriedade de navegação
        [ForeignKey(nameof(TipoDaSalaId))]
        public TipoDeSala? TipoDaSala { get; set; }

    }
}
