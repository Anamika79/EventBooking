using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketBooking.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seatings",
                columns: table => new
                {
                    SeatingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    TotalPlatinumSeats = table.Column<int>(type: "int", nullable: false),
                    TotalGoldSeats = table.Column<int>(type: "int", nullable: false),
                    TotalSilverSeats = table.Column<int>(type: "int", nullable: false),
                    PlatinumSeatPrice = table.Column<int>(type: "int", nullable: false),
                    GoldSeatPrice = table.Column<int>(type: "int", nullable: false),
                    SilverSeatPrice = table.Column<int>(type: "int", nullable: false),
                    PlatinumSeatBooked = table.Column<int>(type: "int", nullable: false),
                    GoldSeatBooked = table.Column<int>(type: "int", nullable: false),
                    SilverSeatBooked = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seatings", x => x.SeatingID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seatings");
        }
    }
}
