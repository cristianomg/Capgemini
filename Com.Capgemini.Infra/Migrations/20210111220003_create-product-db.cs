using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Com.Capgemini.Infra.Migrations
{
    public partial class createproductdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DtEntrega = table.Column<DateTime>(nullable: false),
                    NmProduto = table.Column<string>(maxLength: 50, nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    VlUnitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.CheckConstraint("check_if_qtd_more_then_zero", "[Quantidade] >= 1");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
