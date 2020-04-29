using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickBuy.Repositorio.Migrations
{
    public partial class CargaFormaPagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FomasPagamento",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[] { 1, "Forma de pagamento - Boleto", "Boleto" });

            migrationBuilder.InsertData(
                table: "FomasPagamento",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[] { 2, "Forma de pagamento - Cartão de Crédito", "CartaoCredito" });

            migrationBuilder.InsertData(
                table: "FomasPagamento",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[] { 3, "Forma de pagamento - Depósito", "Deposito" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FomasPagamento",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FomasPagamento",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FomasPagamento",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
