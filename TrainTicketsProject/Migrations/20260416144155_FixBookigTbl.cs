using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainTicketsProject.Migrations
{
    /// <inheritdoc />
    public partial class FixBookigTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_routes_trains_TrainId",
                table: "routes");

            migrationBuilder.DropForeignKey(
                name: "FK_transactionEntries_userTrips_UserTripId",
                table: "transactionEntries");

            migrationBuilder.DropTable(
                name: "userTrips");

            migrationBuilder.RenameColumn(
                name: "UserTripId",
                table: "transactionEntries",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_transactionEntries_UserTripId",
                table: "transactionEntries",
                newName: "IX_transactionEntries_BookingId");

            migrationBuilder.CreateTable(
                name: "tripSchedules",
                columns: table => new
                {
                    TripScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    TrainId = table.Column<int>(type: "int", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromStationId = table.Column<int>(type: "int", nullable: false),
                    ToStationId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tripSchedules", x => x.TripScheduleId);
                    table.ForeignKey(
                        name: "FK_tripSchedules_routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "routes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tripSchedules_stations_FromStationId",
                        column: x => x.FromStationId,
                        principalTable: "stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tripSchedules_stations_ToStationId",
                        column: x => x.ToStationId,
                        principalTable: "stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tripSchedules_trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "trains",
                        principalColumn: "TrainId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    TripScheduleId = table.Column<int>(type: "int", nullable: false),
                    TicketType = table.Column<int>(type: "int", nullable: false),
                    TicketNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReturnTripScheduleId = table.Column<int>(type: "int", nullable: true),
                    CalculatedDistance = table.Column<double>(type: "float", nullable: false),
                    FinalTicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_bookings_tripSchedules_ReturnTripScheduleId",
                        column: x => x.ReturnTripScheduleId,
                        principalTable: "tripSchedules",
                        principalColumn: "TripScheduleId");
                    table.ForeignKey(
                        name: "FK_bookings_tripSchedules_TripScheduleId",
                        column: x => x.TripScheduleId,
                        principalTable: "tripSchedules",
                        principalColumn: "TripScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookings_ReturnTripScheduleId",
                table: "bookings",
                column: "ReturnTripScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_TripScheduleId",
                table: "bookings",
                column: "TripScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_tripSchedules_FromStationId",
                table: "tripSchedules",
                column: "FromStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tripSchedules_RouteId",
                table: "tripSchedules",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_tripSchedules_ToStationId",
                table: "tripSchedules",
                column: "ToStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tripSchedules_TrainId",
                table: "tripSchedules",
                column: "TrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_routes_trains_TrainId",
                table: "routes",
                column: "TrainId",
                principalTable: "trains",
                principalColumn: "TrainId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_transactionEntries_bookings_BookingId",
                table: "transactionEntries",
                column: "BookingId",
                principalTable: "bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_routes_trains_TrainId",
                table: "routes");

            migrationBuilder.DropForeignKey(
                name: "FK_transactionEntries_bookings_BookingId",
                table: "transactionEntries");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "tripSchedules");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "transactionEntries",
                newName: "UserTripId");

            migrationBuilder.RenameIndex(
                name: "IX_transactionEntries_BookingId",
                table: "transactionEntries",
                newName: "IX_transactionEntries_UserTripId");

            migrationBuilder.CreateTable(
                name: "userTrips",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromStationId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    ToStationId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CalculatedDistance = table.Column<double>(type: "float", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalTicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReturnTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userTrips", x => x.TripId);
                    table.ForeignKey(
                        name: "FK_userTrips_routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "routes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userTrips_stations_FromStationId",
                        column: x => x.FromStationId,
                        principalTable: "stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userTrips_stations_ToStationId",
                        column: x => x.ToStationId,
                        principalTable: "stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userTrips_FromStationId",
                table: "userTrips",
                column: "FromStationId");

            migrationBuilder.CreateIndex(
                name: "IX_userTrips_RouteId",
                table: "userTrips",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_userTrips_ToStationId",
                table: "userTrips",
                column: "ToStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_routes_trains_TrainId",
                table: "routes",
                column: "TrainId",
                principalTable: "trains",
                principalColumn: "TrainId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transactionEntries_userTrips_UserTripId",
                table: "transactionEntries",
                column: "UserTripId",
                principalTable: "userTrips",
                principalColumn: "TripId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
