using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Recepedia.Models
{
    public class Ingrediente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDIngrediente { get; set; }
        public string NombreIngrediente { get; set; }
        public string Cantidad { get; set; }

        public Ingrediente()
        {
        }

        public Ingrediente(int IDIngrediente, string NombreIngrediente, string Cantidad)
        {
            this.IDIngrediente = IDIngrediente;
            this.NombreIngrediente = NombreIngrediente;
            this.Cantidad = Cantidad;
        }
    }
}