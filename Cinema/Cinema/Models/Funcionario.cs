using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }
        public string? Cargo { get; set; }
        public DateTime DataAdmissao { get; set; }
        public decimal Salario { get; set; }

        public int PessoaId { get; set; }
        // Propriedade de Navegação
        [ForeignKey("PessoaId")]
        public required Pessoa Pessoa { get; set; }
    }
}
