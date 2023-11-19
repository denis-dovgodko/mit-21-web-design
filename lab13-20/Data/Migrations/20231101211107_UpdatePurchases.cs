using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab13.Data.Migrations
{
    public partial class UpdatePurchases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Purchases",
                newName: "TicketId");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Purchases",
                newName: "Phone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Purchases",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Purchases",
                newName: "Address");
        }
    }
}
