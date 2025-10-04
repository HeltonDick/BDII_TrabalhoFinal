using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    [PrimaryKey(nameof(GeneroId), nameof(FilmeId))]
    public class GenerosFilmes
    {
        public int GeneroId { get; set; }
        // Propriedade de navegação
        [ForeignKey("GeneroId")]
        public Genero? Genero { get; set; }

        public int FilmeId { get; set; }
        // Propriedade de navegação
        [ForeignKey("FilmeId")]
        public Filme? Filme { get; set; }
    }
}
