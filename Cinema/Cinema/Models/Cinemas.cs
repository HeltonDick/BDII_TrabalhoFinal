using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class Cinemas
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Cnpj { get; set; }
        public string? Email { get; set; }

        public int EnderecoId { get; set; }
        // Propriedade de navegação
        [ForeignKey(nameof(EnderecoId))]
        public Endereco? Endereco { get; set; }
    }
}
