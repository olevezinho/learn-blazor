using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MudBlazorBolos.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bolos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ImagemUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Bolos",
                columns: new[] { "Id", "Descricao", "ImagemUrl", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, "Um bolo tipico português", "https://www.rissolariatradicional.com/wp-content/uploads/2020/11/1-Pastel-de-Nata-centrado.jpg", "Pastel de Nata", 3.5m },
                    { 2, "Um bolo tipico frances", "https://upload.wikimedia.org/wikipedia/commons/2/2a/Croissant-Petr_Kratochvil.jpg", "Croissant", 7.5m },
                    { 3, "Um bolo tipico de felgueiras", "https://merceariadeportugal.com/cdn/shop/products/PAO_DE_LO_INDIVIDUAL_800x.png", "Pão de ló", 17.5m },
                    { 4, "Um bolo tipico português", "https://www.fabricoproprio.net/c/wp-content/uploads/2022/11/38_jesuita.jpg", "Jesuíta", 17.5m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bolos");
        }
    }
}
