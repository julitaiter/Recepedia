using Microsoft.EntityFrameworkCore;
using Recepdia.Context;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recepedia.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDUsuario { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre de usuario")]
        public string Nombre_Usuario { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese un apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Ingrese un mail")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Ingrese una contraseña")]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "Más de 4 caracteres y menos de 16 ")]
        public string Contraseña { get; set; }

        [Compare(nameof(Contraseña), ErrorMessage ="Las contraseñas no coinciden")]
        public string RepetirContraseña { get; set; }
        public bool Admin { get; set; }
        [Required(ErrorMessage = "Ingrese una foto")]

        public string NombreFoto { get; set; }
        public List<Receta>? Favoritos { get; set; }


        public Usuario() { }

        public Usuario(int iDUsuario, string nombre_Usuario, string nombre, string apellido, string mail, string contraseña, bool admin, string nom_foto, List<Receta> favs)
        {
            IDUsuario = iDUsuario;
            Nombre_Usuario = nombre_Usuario;
            Nombre = nombre;
            Apellido = apellido;
            Mail = mail;
            Contraseña = contraseña;
            Admin = admin;
            NombreFoto = nom_foto;
            Favoritos = favs;
        }

        public static Usuario TraerUsuarioPorId(RecepediaContext context,int id)
        {
            return context.Usuario.FirstOrDefault(u => u.IDUsuario == id);
        }

        public static List<Receta> TraerFavoritos(RecepediaContext context, int id)
        {
            List<Favorito> favoritos = context.Favoritos.Where(r => r.IdUsuario == id).ToList();
            List<Receta> recetasFav = new List<Receta>();
            foreach (Favorito fav in favoritos)
            {
                recetasFav.Add(context.Receta.Find(fav.IdReceta));
            }
            return recetasFav;
        }
    }
}