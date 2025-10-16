using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        public string? PrimeiroNome { get; set; }
        public string? UltimoNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Cpf { get; set; }
        public int Numero { get; set; }

        public int SexoId { get; set; }
        // Propriedade de Navegação
        [ForeignKey("SexoId")]
        public Sexo? Sexo { get; set; }

        public int EnderecoId { get; set; }
        // Propriedade de Navegação
        [ForeignKey("EnderecoId")]
        public Endereco? Endereco { get; set; }

        // Propriedade de Navegação - Relação Muitos para Muitos
        public List<OficiosDePessoas>? OficiosDePessoas { get; set; }
    }
}
