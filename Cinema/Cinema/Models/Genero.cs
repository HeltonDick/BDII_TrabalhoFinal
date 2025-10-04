using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<GenerosFilmes>? GenerosFilmes { get; set; }
    }
}
