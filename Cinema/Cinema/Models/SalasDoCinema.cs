using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class SalasDoCinema
    {
        [Key]
        public int Id { get; set; }
        public bool Disponibilidade { get; set; }
        public int SalasPadraoId { get; set; }
        //propriedade de navegação
        [ForeignKey(nameof(SalasPadraoId))]
        public SalasPadrao? SalasPadrao { get; set; }

        public int AssentoId { get; set; }
        //propriedade de navegação
        [ForeignKey(nameof(AssentoId))]
        public Assento? Assento { get; set; }
    }
}
