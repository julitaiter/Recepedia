using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recepedia.Models
{
    public class IngPorRec
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdIngPorRec { get; set; }
        public int IdReceta { get; set; }
        public int IdIngrediente { get; set; }
        public string Cantidad { get; set; }
    }
}
