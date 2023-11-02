using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Recepedia.Models
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategoria { get; set; }
        public string Nom_Categoria { get; set; }

        /*public Categoria()
        {
        }
        public Categoria(int id, string nom)
        {
            IdCategoria = id;
            Nom_Categoria = nom;
        }*/
    }
}