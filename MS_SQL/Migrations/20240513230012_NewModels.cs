using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class NewModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    IsnNode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.IsnNode);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IsnNode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IsnNode);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    IsnNode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainIsnNode = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.IsnNode);
                    table.ForeignKey(
                        name: "FK_Exercises_Trains_TrainIsnNode",
                        column: x => x.TrainIsnNode,
                        principalTable: "Trains",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalMetricss",
                columns: table => new
                {
                    IsnNode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    BodyMeasurements = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalMetricss", x => x.IsnNode);
                    table.ForeignKey(
                        name: "FK_PhysicalMetricss_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrainIsnNode",
                table: "Exercises",
                column: "TrainIsnNode");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalMetricss_UserId",
                table: "PhysicalMetricss",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "PhysicalMetricss");

            migrationBuilder.DropTable(
                name: "Trains");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
