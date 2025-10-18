using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    [PrimaryKey(nameof(PessoaId), nameof(OficioId))]
    public class OficiosDePessoas
    {
        public int PessoaId { get; set; }
        // Propriedade de Navegação
        [ForeignKey(nameof(PessoaId))]
        public Pessoa? Pessoa { get; set; }

        public int OficioId { get; set; }
        // Propriedade de Navegação
        [ForeignKey(nameof(OficioId))]
        public Oficio? Oficio { get; set; }

        public required DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
