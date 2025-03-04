using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace motivation.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quotes_emotions_emotionIdId",
                table: "quotes");

            migrationBuilder.DropIndex(
                name: "IX_quotes_emotionIdId",
                table: "quotes");

            migrationBuilder.DropColumn(
                name: "emotionIdId",
                table: "quotes");

            migrationBuilder.AddColumn<int>(
                name: "EmotionId",
                table: "quotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "emotions",
                columns: new[] { "Id", "emotionDescription", "name" },
                values: new object[,]
                {
                    { 1, null, "happy" },
                    { 2, null, "sad" },
                    { 3, null, "anxious" },
                    { 4, null, "confident" },
                    { 5, null, "stressed" }
                });

            migrationBuilder.InsertData(
                table: "quotes",
                columns: new[] { "Id", "EmotionId", "motivation", "quoteCreated" },
                values: new object[,]
                {
                    { 1, 1, "Happiness is a journey, not a destination.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, "It's okay to feel sad; tomorrow is a new day.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, "Take a deep breath; you've got this.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, "Believe in yourself, and the rest will follow.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, "Stress is just another test to show your strength.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_quotes_EmotionId",
                table: "quotes",
                column: "EmotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_quotes_emotions_EmotionId",
                table: "quotes",
                column: "EmotionId",
                principalTable: "emotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quotes_emotions_EmotionId",
                table: "quotes");

            migrationBuilder.DropIndex(
                name: "IX_quotes_EmotionId",
                table: "quotes");

            migrationBuilder.DeleteData(
                table: "quotes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "quotes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "quotes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "quotes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "quotes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "emotions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "emotions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "emotions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "emotions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "emotions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "EmotionId",
                table: "quotes");

            migrationBuilder.AddColumn<int>(
                name: "emotionIdId",
                table: "quotes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_quotes_emotionIdId",
                table: "quotes",
                column: "emotionIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_quotes_emotions_emotionIdId",
                table: "quotes",
                column: "emotionIdId",
                principalTable: "emotions",
                principalColumn: "Id");
        }
    }
}
