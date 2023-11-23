using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Recepdia.Context;
using Microsoft.EntityFrameworkCore;

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
        public int CategoriaIdCategoria { get; set; }
        [Required(ErrorMessage = "Ingrese instrucciones para preparar la receta")]
        public string Preparacion { get; set; }
        [Required(ErrorMessage = "Ingrese tiempo de preparación de receta")]
        public int TiempoPreparacion { get; set; }
        [Required(ErrorMessage = "Ingrese cantidad de platos de receta")]
        public float CantidadPlatos { get; set; }
        [Required(ErrorMessage = "Ingrese dificultad de receta")]
        public int DificultadIdDificultad { get; set; }
        [Required(ErrorMessage = "Ingrese foto de receta")]
        public int Cant_Likes { get; set; }
        public int Autor { get; set; }
        public List<IngPorRec>? Ingredientes { get; set; }
        public Receta()
        {

        }
        public Receta(RecepediaContext contexto)
        {
            ListarIngredientes(contexto);
        }
        private void ListarIngredientes(RecepediaContext contexto)
        {
            //Ingredientes = contexto.IngPorRec.Include(x => x.IdReceta).ToList();
        }
    }
}
