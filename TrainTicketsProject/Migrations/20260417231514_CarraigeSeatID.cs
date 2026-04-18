using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainTicketsProject.Migrations
{
    /// <inheritdoc />
    public partial class CarraigeSeatID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_tripSchedules_ReturnTripScheduleId",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_tripSchedules_TripScheduleId",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_routes_trains_TrainId",
                table: "routes");

            migrationBuilder.DropIndex(
                name: "IX_routes_TrainId",
                table: "routes");

            migrationBuilder.DropColumn(
                name: "TrainId",
                table: "routes");

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "trains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarriageId",
                table: "bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarriageSeatId",
                table: "bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReturnCarriageId",
                table: "bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReturnCarriageSeatId",
                table: "bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_trains_RouteId",
                table: "trains",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_CarriageId",
                table: "bookings",
                column: "CarriageId");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_CarriageSeatId",
                table: "bookings",
                column: "CarriageSeatId");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_ReturnCarriageId",
                table: "bookings",
                column: "ReturnCarriageId");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_ReturnCarriageSeatId",
                table: "bookings",
                column: "ReturnCarriageSeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_Carriages_CarriageId",
                table: "bookings",
                column: "CarriageId",
                principalTable: "Carriages",
                principalColumn: "CarriageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_Carriages_ReturnCarriageId",
                table: "bookings",
                column: "ReturnCarriageId",
                principalTable: "Carriages",
                principalColumn: "CarriageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_carriageSeats_CarriageSeatId",
                table: "bookings",
                column: "CarriageSeatId",
                principalTable: "carriageSeats",
                principalColumn: "CarriageSeatId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_carriageSeats_ReturnCarriageSeatId",
                table: "bookings",
                column: "ReturnCarriageSeatId",
                principalTable: "carriageSeats",
                principalColumn: "CarriageSeatId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_tripSchedules_ReturnTripScheduleId",
                table: "bookings",
                column: "ReturnTripScheduleId",
                principalTable: "tripSchedules",
                principalColumn: "TripScheduleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_tripSchedules_TripScheduleId",
                table: "bookings",
                column: "TripScheduleId",
                principalTable: "tripSchedules",
                principalColumn: "TripScheduleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trains_routes_RouteId",
                table: "trains",
                column: "RouteId",
                principalTable: "routes",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_Carriages_CarriageId",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_Carriages_ReturnCarriageId",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_carriageSeats_CarriageSeatId",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_carriageSeats_ReturnCarriageSeatId",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_tripSchedules_ReturnTripScheduleId",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_tripSchedules_TripScheduleId",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_trains_routes_RouteId",
                table: "trains");

            migrationBuilder.DropIndex(
                name: "IX_trains_RouteId",
                table: "trains");

            migrationBuilder.DropIndex(
                name: "IX_bookings_CarriageId",
                table: "bookings");

            migrationBuilder.DropIndex(
                name: "IX_bookings_CarriageSeatId",
                table: "bookings");

            migrationBuilder.DropIndex(
                name: "IX_bookings_ReturnCarriageId",
                table: "bookings");

            migrationBuilder.DropIndex(
                name: "IX_bookings_ReturnCarriageSeatId",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "trains");

            migrationBuilder.DropColumn(
                name: "CarriageId",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "CarriageSeatId",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "ReturnCarriageId",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "ReturnCarriageSeatId",
                table: "bookings");

            migrationBuilder.AddColumn<int>(
                name: "TrainId",
                table: "routes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_routes_TrainId",
                table: "routes",
                column: "TrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_tripSchedules_ReturnTripScheduleId",
                table: "bookings",
                column: "ReturnTripScheduleId",
                principalTable: "tripSchedules",
                principalColumn: "TripScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_tripSchedules_TripScheduleId",
                table: "bookings",
                column: "TripScheduleId",
                principalTable: "tripSchedules",
                principalColumn: "TripScheduleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_routes_trains_TrainId",
                table: "routes",
                column: "TrainId",
                principalTable: "trains",
                principalColumn: "TrainId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
