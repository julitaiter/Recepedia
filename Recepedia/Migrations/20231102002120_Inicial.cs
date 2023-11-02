using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recepedia.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Dificultad",
                columns: table => new
                {
                    IDDificultad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDificultad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dificultad", x => x.IDDificultad);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IDUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    RepetirContraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    NombreFoto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IDUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Receta",
                columns: table => new
                {
                    IDReceta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreReceta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaIdCategoria = table.Column<int>(type: "int", nullable: false),
                    Preparacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiempoPreparacion = table.Column<int>(type: "int", nullable: false),
                    CantidadPlatos = table.Column<float>(type: "real", nullable: false),
                    DificultadIDDificultad = table.Column<int>(type: "int", nullable: false),
                    NombreFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cant_Likes = table.Column<int>(type: "int", nullable: false),
                    Autor = table.Column<int>(type: "int", nullable: false),
                    UsuarioIDUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receta", x => x.IDReceta);
                    table.ForeignKey(
                        name: "FK_Receta_Categoria_CategoriaIdCategoria",
                        column: x => x.CategoriaIdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receta_Dificultad_DificultadIDDificultad",
                        column: x => x.DificultadIDDificultad,
                        principalTable: "Dificultad",
                        principalColumn: "IDDificultad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receta_Usuario_UsuarioIDUsuario",
                        column: x => x.UsuarioIDUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IDUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    IDIngrediente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreIngrediente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecetaIDReceta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.IDIngrediente);
                    table.ForeignKey(
                        name: "FK_Ingrediente_Receta_RecetaIDReceta",
                        column: x => x.RecetaIDReceta,
                        principalTable: "Receta",
                        principalColumn: "IDReceta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_RecetaIDReceta",
                table: "Ingrediente",
                column: "RecetaIDReceta");

            migrationBuilder.CreateIndex(
                name: "IX_Receta_CategoriaIdCategoria",
                table: "Receta",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Receta_DificultadIDDificultad",
                table: "Receta",
                column: "DificultadIDDificultad");

            migrationBuilder.CreateIndex(
                name: "IX_Receta_UsuarioIDUsuario",
                table: "Receta",
                column: "UsuarioIDUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "Receta");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Dificultad");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
