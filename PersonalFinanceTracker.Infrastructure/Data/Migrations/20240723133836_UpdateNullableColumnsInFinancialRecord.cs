using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinanceTracker.Data.Migrations
{
    public partial class UpdateNullableColumnsInFinancialRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1553ed85-8d1c-48c2-acfc-e796d7cb8fdc", "AQAAAAEAACcQAAAAEK96HnajtRlBrcndL5oI5lM0XB7C3gPhpxxnKoba3hsH3N0K+pb7KzoKG3dZTqLXlA==" });

            migrationBuilder.UpdateData(
                table: "FinancialRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 23, 16, 38, 36, 83, DateTimeKind.Local).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "FinancialRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 7, 23, 16, 38, 36, 83, DateTimeKind.Local).AddTicks(4689));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d0426c26-b0da-4bc5-98c0-f0a945327dec", "AQAAAAEAACcQAAAAEO4AZyC7rHv2Cy54jMbcmlpAxIU+9Q3IfdHk6oROB1SAvbCde8JhFeeKUuZ3B4dhjA==" });

            migrationBuilder.UpdateData(
                table: "FinancialRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 23, 14, 2, 16, 97, DateTimeKind.Local).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "FinancialRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 7, 23, 14, 2, 16, 97, DateTimeKind.Local).AddTicks(265));
        }
    }
}
