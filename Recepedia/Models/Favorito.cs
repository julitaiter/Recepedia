using System.ComponentModel.DataAnnotations;

namespace Recepedia.Models
{
    public class Favorito
    {
        [Key]
        public int IdFavorito { get; set; }
        public int IdReceta { get; set; }
        public int IdUsuario { get; set; }
    }
}