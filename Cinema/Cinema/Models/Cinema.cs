using Cinema.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFTest.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Cnpj { get; set; }
        public string? Email { get; set; }

        public int EnderecoId { get; set; }
        // Propriedade de navegação
        [ForeignKey("EnderecoId")]
        public required Endereco Endereco { get; set; }
    }
}
