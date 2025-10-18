using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }
        public string? TituloOriginal { get; set; }
        public string? Titulo { get; set; }
        public string? Duracao { get; set; }
        public string? Desc { get; set; }
        public DateTime DataFilme { get; set; }

        public List<EstudiosFilmes>? EstudiosFilmes { get; set; }

        public List<GenerosFilmes>? GenerosFilmes { get; set; }

        public int ClassificacaoId { get; set; }
        // Propriedade de navegação
        [ForeignKey(nameof(ClassificacaoId))]
        public Classificacao? Classificacao { get; set; }

        
    }
}
