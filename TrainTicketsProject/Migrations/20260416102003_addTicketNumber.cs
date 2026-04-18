using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainTicketsProject.Migrations
{
    /// <inheritdoc />
    public partial class addTicketNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TicketNumber",
                table: "userTrips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketNumber",
                table: "userTrips");
        }
    }
}
