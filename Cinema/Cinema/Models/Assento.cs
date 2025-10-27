using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class Assento
    {
        [Key]
        public int Id { get; set; }
    }
}
