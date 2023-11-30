using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab15_17.Data.Migrations
{
    /// <inheritdoc />
    public partial class k : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Sessions_SessionId",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Seats_SeatId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Films_FilmId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Films_SessionId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "HallNum",
                table: "Films");

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "Tickets",
                newName: "SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_FilmId",
                table: "Tickets",
                newName: "IX_Tickets_SessionId");

            migrationBuilder.RenameColumn(
                name: "SeatId",
                table: "Sessions",
                newName: "HallId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_SeatId",
                table: "Sessions",
                newName: "IX_Sessions_HallId");

            migrationBuilder.RenameColumn(
                name: "Technology",
                table: "Films",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "Films",
                newName: "Duration");

            migrationBuilder.AddColumn<int>(
                name: "Row",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Seat",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HallName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Technology = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowsCount = table.Column<int>(type: "int", nullable: false),
                    SeatsCount = table.Column<int>(type: "int", nullable: false),
                    MinPrice = table.Column<int>(type: "int", nullable: false),
                    VIP = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_FilmId",
                table: "Sessions",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Films_FilmId",
                table: "Sessions",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Halls_HallId",
                table: "Sessions",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Sessions_SessionId",
                table: "Tickets",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Films_FilmId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Halls_HallId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Sessions_SessionId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_FilmId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Row",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Seat",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "Tickets",
                newName: "FilmId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_SessionId",
                table: "Tickets",
                newName: "IX_Tickets_FilmId");

            migrationBuilder.RenameColumn(
                name: "HallId",
                table: "Sessions",
                newName: "SeatId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_HallId",
                table: "Sessions",
                newName: "IX_Sessions_SeatId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Films",
                newName: "Technology");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Films",
                newName: "SessionId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HallNum",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Column = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Row = table.Column<int>(type: "int", nullable: false),
                    VIP = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_SessionId",
                table: "Films",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Sessions_SessionId",
                table: "Films",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Seats_SeatId",
                table: "Sessions",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Films_FilmId",
                table: "Tickets",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
