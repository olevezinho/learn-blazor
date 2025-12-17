using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorFluentCRUD.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Idade = table.Column<int>(type: "INTEGER", nullable: false),
                    Foto = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Email", "Foto", "Idade", "Nome" },
                values: new object[,]
                {
                    { 1, "lfilipecosta3@gmail.com", "/fotos/profile.jpg", 31, "Luis" },
                    { 2, "johnlennon@ceu.net", "/fotos/profile-lennon.jpg", 31, "John Lennon" },
                    { 3, "ozzy@ceu.net", "/fotos/profile-ozzy.jpg", 78, "Ozzy" },
                    { 4, "amy@ceu.net", "/fotos/profile-amy.jpg", 27, "Amy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");
        }
    }
}
