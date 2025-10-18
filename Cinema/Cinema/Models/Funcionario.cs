using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }
        public string? Cargo { get; set; }
        public required DateTime DataAdmissao { get; set; }
        public double Salario { get; set; }

        public int PessoaId { get; set; }
        // Propriedade de Navegação
        [ForeignKey(nameof(PessoaId))]
        public Pessoa? Pessoa { get; set; }
    }
}
