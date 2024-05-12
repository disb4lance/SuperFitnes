using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhysicalMetricss_Users_UserId",
                table: "PhysicalMetricss");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPrograms_Users_UserId",
                table: "TrainingPrograms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPrograms_UserId",
                table: "TrainingPrograms");

            migrationBuilder.DropIndex(
                name: "IX_PhysicalMetricss_UserId",
                table: "PhysicalMetricss");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "IsnNode",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserIsnNode",
                table: "TrainingPrograms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserIsnNode",
                table: "PhysicalMetricss",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "IsnNode");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPrograms_UserIsnNode",
                table: "TrainingPrograms",
                column: "UserIsnNode");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalMetricss_UserIsnNode",
                table: "PhysicalMetricss",
                column: "UserIsnNode");

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicalMetricss_Users_UserIsnNode",
                table: "PhysicalMetricss",
                column: "UserIsnNode",
                principalTable: "Users",
                principalColumn: "IsnNode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPrograms_Users_UserIsnNode",
                table: "TrainingPrograms",
                column: "UserIsnNode",
                principalTable: "Users",
                principalColumn: "IsnNode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhysicalMetricss_Users_UserIsnNode",
                table: "PhysicalMetricss");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPrograms_Users_UserIsnNode",
                table: "TrainingPrograms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPrograms_UserIsnNode",
                table: "TrainingPrograms");

            migrationBuilder.DropIndex(
                name: "IX_PhysicalMetricss_UserIsnNode",
                table: "PhysicalMetricss");

            migrationBuilder.DropColumn(
                name: "IsnNode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserIsnNode",
                table: "TrainingPrograms");

            migrationBuilder.DropColumn(
                name: "UserIsnNode",
                table: "PhysicalMetricss");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPrograms_UserId",
                table: "TrainingPrograms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalMetricss_UserId",
                table: "PhysicalMetricss",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicalMetricss_Users_UserId",
                table: "PhysicalMetricss",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPrograms_Users_UserId",
                table: "TrainingPrograms",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
