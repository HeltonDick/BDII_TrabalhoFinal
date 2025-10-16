using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Oficio
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }

        // Propriedade de Navegação - Relação Muitos para Muitos
        public List<OficiosDePessoas>? OficiosDePessoas { get; set; }
    }
}
