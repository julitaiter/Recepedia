using Microsoft.EntityFrameworkCore;
using Recepedia.Models;

namespace Recepdia.Context
{
    public class RecepediaContext : DbContext
    {
        public RecepediaContext(DbContextOptions<RecepediaContext>options) : base(options)
        {
        }
        public DbSet<Receta> Receta{ get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Dificultad> Dificultad { get; set; }
        public DbSet<Ingrediente> Ingrediente{ get; set; }
        public DbSet<Usuario> Usuario{ get; set; }
    }
}

