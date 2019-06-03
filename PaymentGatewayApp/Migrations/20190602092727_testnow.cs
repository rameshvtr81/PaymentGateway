using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentGatewayApp.Migrations
{
    public partial class testnow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionsID",
                table: "TransReport",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionsID",
                table: "TransReport");
        }
    }
}
