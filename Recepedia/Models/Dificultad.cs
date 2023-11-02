using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Recepedia.Models
{
    public class Dificultad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDDificultad { get; set; }
        public string NombreDificultad { get; set; }

        public Dificultad()
        {
        }
        public Dificultad(int id, string nom)
        {
            IDDificultad = id;
            NombreDificultad = nom;
        }
    }
}