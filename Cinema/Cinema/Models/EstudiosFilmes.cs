using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    [PrimaryKey(nameof(EstudioId), nameof(FilmeId))]
    public class EstudiosFilmes
    {
        public int EstudioId { get; set; }
        //Propriedade de navegação
        [ForeignKey(nameof(EstudioId))]
        public Estudio? Estudio { get; set; }

        public int FilmeId { get; set; }
        //Propriedade de navegação
        [ForeignKey(nameof(FilmeId))]
        public Filme? Filme { get; set; }
    }
}
