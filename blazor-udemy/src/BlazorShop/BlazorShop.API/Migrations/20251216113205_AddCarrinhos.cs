using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorShop.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCarrinhos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilizadores_Carrinhos_CarrinhoId",
                table: "Utilizadores");

            migrationBuilder.DropIndex(
                name: "IX_Utilizadores_CarrinhoId",
                table: "Utilizadores");

            migrationBuilder.DropColumn(
                name: "CarrinhoId",
                table: "Utilizadores");

            migrationBuilder.RenameColumn(
                name: "IdUtilizador",
                table: "Carrinhos",
                newName: "UtilizadorId");

            migrationBuilder.InsertData(
                table: "Carrinhos",
                columns: new[] { "Id", "UtilizadorId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrinhos_UtilizadorId",
                table: "Carrinhos",
                column: "UtilizadorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carrinhos_Utilizadores_UtilizadorId",
                table: "Carrinhos",
                column: "UtilizadorId",
                principalTable: "Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrinhos_Utilizadores_UtilizadorId",
                table: "Carrinhos");

            migrationBuilder.DropIndex(
                name: "IX_Carrinhos_UtilizadorId",
                table: "Carrinhos");

            migrationBuilder.DeleteData(
                table: "Carrinhos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carrinhos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "UtilizadorId",
                table: "Carrinhos",
                newName: "IdUtilizador");

            migrationBuilder.AddColumn<int>(
                name: "CarrinhoId",
                table: "Utilizadores",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 1,
                column: "CarrinhoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 2,
                column: "CarrinhoId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Utilizadores_CarrinhoId",
                table: "Utilizadores",
                column: "CarrinhoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilizadores_Carrinhos_CarrinhoId",
                table: "Utilizadores",
                column: "CarrinhoId",
                principalTable: "Carrinhos",
                principalColumn: "Id");
        }
    }
}
