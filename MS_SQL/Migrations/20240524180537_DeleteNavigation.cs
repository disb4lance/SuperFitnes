using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class DeleteNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Trains_TrainingId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_PhysicalMetricss_Users_UserId",
                table: "PhysicalMetricss");

            migrationBuilder.DropForeignKey(
                name: "FK_Trains_Users_UserId",
                table: "Trains");

            migrationBuilder.DropIndex(
                name: "IX_Trains_UserId",
                table: "Trains");

            migrationBuilder.DropIndex(
                name: "IX_PhysicalMetricss_UserId",
                table: "PhysicalMetricss");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_TrainingId",
                table: "Exercises");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Trains_UserId",
                table: "Trains",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalMetricss_UserId",
                table: "PhysicalMetricss",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrainingId",
                table: "Exercises",
                column: "TrainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Trains_TrainingId",
                table: "Exercises",
                column: "TrainingId",
                principalTable: "Trains",
                principalColumn: "IsnNode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicalMetricss_Users_UserId",
                table: "PhysicalMetricss",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "IsnNode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trains_Users_UserId",
                table: "Trains",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "IsnNode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
