using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        public int Numero { get; set; }
        public string? Rua1 { get; set; }
        public string? Rua2 { get; set; }
        public string? Referencia { get; set; }
    }
}
