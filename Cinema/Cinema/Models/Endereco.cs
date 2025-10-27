using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        public int Numero { get; set; }
        public string? Referencia { get; set; }
        public string? Logradouro { get; set; }
        public string? Cep { get; set; }
        public string? Rua1 { get; set; }
        public string? Rua2 { get; set; }

        public int BairroId { get; set; }
        // Propriedade de Navegação
        [ForeignKey(nameof(BairroId))]
        public Bairro? Bairro { get; set; }
    }
}
