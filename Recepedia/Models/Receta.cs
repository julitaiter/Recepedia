using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web;


namespace Recepedia.Models
{
    public class Receta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDReceta { get; set; }
        [Required(ErrorMessage = "Ingrese un titulo de receta")]
        public string NombreReceta { get; set; }
        [Required(ErrorMessage = "Ingrese categoría")]
        public int idCategoria { get; set; }
        [Required(ErrorMessage = "Ingrese instrucciones para preparar la receta")]
        public string Preparacion { get; set; }
        [Required(ErrorMessage = "Ingrese tiempo de preparación de receta")]
        public int TiempoPreparacion { get; set; }
        [Required(ErrorMessage = "Ingrese cantidad de platos de receta")]
        public float CantidadPlatos { get; set; }
        [Required(ErrorMessage = "Ingrese dificultad de receta")]
        public int idDificultad { get; set; }
        [Required(ErrorMessage = "Ingrese ingredientes de receta")]
        public List<Ingrediente> Ingredientes { get; set; }
        [Required(ErrorMessage = "Ingrese foto de receta")]
        public string NombreFoto { get; set; }
        public int Cant_Likes { get; set; }
        public int Autor { get; set; }
    }
}
