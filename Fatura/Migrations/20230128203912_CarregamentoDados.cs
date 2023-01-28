using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fatura.Migrations
{
    public partial class CarregamentoDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Transacoes",
                columns: new[] { "Id", "DataCompra", "DescricaoCompra", "Moeda", "NumeroCartao", "Valor" },
                values: new object[] { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "1234", 1200.0 });

            migrationBuilder.InsertData(
                table: "Transacoes",
                columns: new[] { "Id", "DataCompra", "DescricaoCompra", "Moeda", "NumeroCartao", "Valor" },
                values: new object[] { 2, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "1234", 400.0 });

            migrationBuilder.InsertData(
                table: "Transacoes",
                columns: new[] { "Id", "DataCompra", "DescricaoCompra", "Moeda", "NumeroCartao", "Valor" },
                values: new object[] { 3, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "4321", 400.0 });

            migrationBuilder.InsertData(
                table: "Transacoes",
                columns: new[] { "Id", "DataCompra", "DescricaoCompra", "Moeda", "NumeroCartao", "Valor" },
                values: new object[] { 4, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "1234", 200.0 });

            migrationBuilder.InsertData(
                table: "Transacoes",
                columns: new[] { "Id", "DataCompra", "DescricaoCompra", "Moeda", "NumeroCartao", "Valor" },
                values: new object[] { 5, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "1234", 50.0 });

            migrationBuilder.InsertData(
                table: "Transacoes",
                columns: new[] { "Id", "DataCompra", "DescricaoCompra", "Moeda", "NumeroCartao", "Valor" },
                values: new object[] { 6, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "4321", 50.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transacoes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transacoes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transacoes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Transacoes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Transacoes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Transacoes",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
