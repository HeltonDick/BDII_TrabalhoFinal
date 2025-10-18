using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class Sessao
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataSessao { get; set; }

        public int SalasDoCinemaId { get; set; }
        // Propriedade de Navegação
        [ForeignKey(nameof(SalasDoCinemaId))]
        public SalasDoCinema? salasDoCinema { get; set; }

        public int FilmeId { get; set; }
        // Propriedade de Navegação
        [ForeignKey(nameof(FilmeId))]
        public Filme? Filme { get; set; }

        public int IdiomaId { get; set; }
        // Propriedade de Navegação
        [ForeignKey(nameof(IdiomaId))]
        public Idioma? Idioma { get; set; }

        public int DimenssaoId { get; set; }
        // Propriedade de Navegação
        [ForeignKey(nameof(DimenssaoId))]
        public Dimenssao? Dimenssao { get; set; }

        //public List<OficiosDePessoas>? OficiosDePessoas { get; set; }
        public List<Assento>? AssentosDaSala { get; set; }
    }
}
