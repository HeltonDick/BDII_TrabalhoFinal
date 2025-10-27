using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class Ingresso
    {
        [Key]
        public int Id { get; set; }
        public DateTime? DataDaCompra { get; set; }

        public int PessoaId { get; set; }
        // Propriedade de Navegação
        [ForeignKey(nameof(PessoaId))]
        public Pessoa? Pessoa { get; set; }

        public int SessaoId { get; set; }
        // Propriedade de Navegação
        [ForeignKey(nameof(SessaoId))]
        public Sessao? Sessao { get; set; }


}
}
