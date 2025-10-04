using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Sexo
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
    }
}
