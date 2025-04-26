using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fiap.Api.Donation4.Migrations
{
    /// <inheritdoc />
    public partial class Create_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCategoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailUsuario = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Regra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descricao", "NomeCategoria" },
                values: new object[,]
                {
                    { 1, null, "Celular" },
                    { 2, null, "Gadgets" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "UsuarioId", "EmailUsuario", "NomeUsuario", "Regra", "Senha" },
                values: new object[,]
                {
                    { 1, "admin@admin", "Admin", "admin", "admin123" },
                    { 2, "fmoreni@gmail.com", "Flavio Moreni", "admin", "123456" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_NomeCategoria",
                table: "Categoria",
                column: "NomeCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmailUsuario",
                table: "Usuario",
                column: "EmailUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmailUsuario_Senha",
                table: "Usuario",
                columns: new[] { "EmailUsuario", "Senha" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
