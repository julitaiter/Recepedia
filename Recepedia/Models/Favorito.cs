﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recepedia.Models
{
    public class Favorito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdFavorito { get; set; }
        public int IdReceta { get; set; }
        public int IdUsuario { get; set; }
    }
}