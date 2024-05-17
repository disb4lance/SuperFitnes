using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class Sviazi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Trains_TrainIsnNode",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_TrainIsnNode",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "TrainIsnNode",
                table: "Exercises");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Trains",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Trains_UserId",
                table: "Trains",
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
                name: "FK_Trains_Users_UserId",
                table: "Trains",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "IsnNode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Trains_TrainingId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Trains_Users_UserId",
                table: "Trains");

            migrationBuilder.DropIndex(
                name: "IX_Trains_UserId",
                table: "Trains");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_TrainingId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Trains");

            migrationBuilder.AddColumn<Guid>(
                name: "TrainIsnNode",
                table: "Exercises",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrainIsnNode",
                table: "Exercises",
                column: "TrainIsnNode");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Trains_TrainIsnNode",
                table: "Exercises",
                column: "TrainIsnNode",
                principalTable: "Trains",
                principalColumn: "IsnNode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
