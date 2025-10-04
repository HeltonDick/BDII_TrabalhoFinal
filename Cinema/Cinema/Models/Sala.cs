using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Sala
    {
        [Key]
        public int Id { get; set; }
        public int Capacidade { get; set; }
    }
}
