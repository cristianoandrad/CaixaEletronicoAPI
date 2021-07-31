using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaixaEletronicoAPI.Migrations
{
    public partial class tipoconta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavorecidoId",
                table: "Conta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoContaId",
                table: "Conta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Favorecido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorecido", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoConta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoConta", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Conta_FavorecidoId",
                table: "Conta",
                column: "FavorecidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Conta_TipoContaId",
                table: "Conta",
                column: "TipoContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_Favorecido_FavorecidoId",
                table: "Conta",
                column: "FavorecidoId",
                principalTable: "Favorecido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_TipoConta_TipoContaId",
                table: "Conta",
                column: "TipoContaId",
                principalTable: "TipoConta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Favorecido_FavorecidoId",
                table: "Conta");

            migrationBuilder.DropForeignKey(
                name: "FK_Conta_TipoConta_TipoContaId",
                table: "Conta");

            migrationBuilder.DropTable(
                name: "Favorecido");

            migrationBuilder.DropTable(
                name: "TipoConta");

            migrationBuilder.DropIndex(
                name: "IX_Conta_FavorecidoId",
                table: "Conta");

            migrationBuilder.DropIndex(
                name: "IX_Conta_TipoContaId",
                table: "Conta");

            migrationBuilder.DropColumn(
                name: "FavorecidoId",
                table: "Conta");

            migrationBuilder.DropColumn(
                name: "TipoContaId",
                table: "Conta");
        }
    }
}
