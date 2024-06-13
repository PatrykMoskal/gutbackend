using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_ReservationStatuses_ReservationStatusId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ReservationStatusId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "ReservationStatusId",
                table: "Cars",
                newName: "ReservationStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReservationStatus",
                table: "Cars",
                newName: "ReservationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ReservationStatusId",
                table: "Cars",
                column: "ReservationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_ReservationStatuses_ReservationStatusId",
                table: "Cars",
                column: "ReservationStatusId",
                principalTable: "ReservationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
