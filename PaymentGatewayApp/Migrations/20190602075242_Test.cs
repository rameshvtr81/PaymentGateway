using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentGatewayApp.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentOptions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOptions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    TransactionMethod = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    Cardnumber = table.Column<string>(nullable: true),
                    CVV = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Reference = table.Column<string>(nullable: true),
                    MerchantId = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TransReport",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    TransactionMethod = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    Cardnumber = table.Column<string>(nullable: true),
                    CVV = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Reference = table.Column<string>(nullable: true),
                    MerchantId = table.Column<string>(nullable: true),
                    TransDate = table.Column<DateTime>(nullable: false),
                    Createddate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransReport", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Maybank" },
                    { 2, "CIMB Bank" },
                    { 3, "Public Bank Berhad" },
                    { 4, "RHB Bank" },
                    { 5, "Hong Leong Bank" },
                    { 6, "OCBC Bank Malaysia" },
                    { 7, "HSBC Bank Malaysia" },
                    { 8, "CitiBank Malaysia" },
                    { 9, "Bank Muamalat Malaysia Berhad" },
                    { 10, "Alliance Bank" }
                });

            migrationBuilder.InsertData(
                table: "PaymentOptions",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Online Banking" },
                    { 2, "Gateway Wallet" },
                    { 3, "Debit/Credit Card" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "PaymentOptions");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "TransReport");
        }
    }
}
