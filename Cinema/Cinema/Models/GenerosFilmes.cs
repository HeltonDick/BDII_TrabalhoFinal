using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    [PrimaryKey(nameof(GeneroId), nameof(FilmeId))]
    public class GenerosFilmes
    {
        public int GeneroId { get; set; }
        // Propriedade de navegação
        [ForeignKey(nameof(GeneroId))]
        public Genero? Genero { get; set; }

        public int FilmeId { get; set; }
        // Propriedade de navegação
        [ForeignKey(nameof(FilmeId))]
        public Filme? Filme { get; set; }
    }
}
