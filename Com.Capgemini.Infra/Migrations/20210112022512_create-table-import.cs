using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Com.Capgemini.Infra.Migrations
{
    public partial class createtableimport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImportacaoId",
                table: "Produto",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Importacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DtImportacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Importacao", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_ImportacaoId",
                table: "Produto",
                column: "ImportacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Importacao_ImportacaoId",
                table: "Produto",
                column: "ImportacaoId",
                principalTable: "Importacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Importacao_ImportacaoId",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "Importacao");

            migrationBuilder.DropIndex(
                name: "IX_Produto_ImportacaoId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "ImportacaoId",
                table: "Produto");
        }
    }
}
