using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recepedia.Migrations
{
    /// <inheritdoc />
    public partial class IngPorRec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingrediente_Receta_RecetaIDReceta",
                table: "Ingrediente");

            migrationBuilder.DropForeignKey(
                name: "FK_Receta_Categoria_CategoriaIdCategoria",
                table: "Receta");

            migrationBuilder.DropForeignKey(
                name: "FK_Receta_Dificultad_DificultadIDDificultad",
                table: "Receta");

            migrationBuilder.DropIndex(
                name: "IX_Receta_CategoriaIdCategoria",
                table: "Receta");

            migrationBuilder.DropIndex(
                name: "IX_Receta_DificultadIDDificultad",
                table: "Receta");

            migrationBuilder.DropIndex(
                name: "IX_Ingrediente_RecetaIDReceta",
                table: "Ingrediente");

            migrationBuilder.DropColumn(
                name: "NombreFoto",
                table: "Receta");

            migrationBuilder.DropColumn(
                name: "RecetaIDReceta",
                table: "Ingrediente");

            migrationBuilder.RenameColumn(
                name: "DificultadIDDificultad",
                table: "Receta",
                newName: "DificultadIdDificultad");

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    IdFavorito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReceta = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => x.IdFavorito);
                });

            migrationBuilder.CreateTable(
                name: "IngPorRec",
                columns: table => new
                {
                    IdIngPorRec = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReceta = table.Column<int>(type: "int", nullable: false),
                    IdIngrediente = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecetaIDReceta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngPorRec", x => x.IdIngPorRec);
                    table.ForeignKey(
                        name: "FK_IngPorRec_Receta_RecetaIDReceta",
                        column: x => x.RecetaIDReceta,
                        principalTable: "Receta",
                        principalColumn: "IDReceta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngPorRec_RecetaIDReceta",
                table: "IngPorRec",
                column: "RecetaIDReceta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.DropTable(
                name: "IngPorRec");

            migrationBuilder.RenameColumn(
                name: "DificultadIdDificultad",
                table: "Receta",
                newName: "DificultadIDDificultad");

            migrationBuilder.AddColumn<string>(
                name: "NombreFoto",
                table: "Receta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RecetaIDReceta",
                table: "Ingrediente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receta_CategoriaIdCategoria",
                table: "Receta",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Receta_DificultadIDDificultad",
                table: "Receta",
                column: "DificultadIDDificultad");

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_RecetaIDReceta",
                table: "Ingrediente",
                column: "RecetaIDReceta");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingrediente_Receta_RecetaIDReceta",
                table: "Ingrediente",
                column: "RecetaIDReceta",
                principalTable: "Receta",
                principalColumn: "IDReceta");

            migrationBuilder.AddForeignKey(
                name: "FK_Receta_Categoria_CategoriaIdCategoria",
                table: "Receta",
                column: "CategoriaIdCategoria",
                principalTable: "Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receta_Dificultad_DificultadIDDificultad",
                table: "Receta",
                column: "DificultadIDDificultad",
                principalTable: "Dificultad",
                principalColumn: "IDDificultad",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
