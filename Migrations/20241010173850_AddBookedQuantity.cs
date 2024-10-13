using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simple_booking_system.Migrations
{
    /// <inheritdoc />
    public partial class AddBookedQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookedQuantity",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookedQuantity",
                table: "Bookings");
        }
    }
}
