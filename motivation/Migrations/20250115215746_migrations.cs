using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace motivation.Migrations
{
    /// <inheritdoc />
    public partial class migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "emotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emotionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    motivation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quoteCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    emotionIdId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quotes_emotions_emotionIdId",
                        column: x => x.emotionIdId,
                        principalTable: "emotions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_quotes_emotionIdId",
                table: "quotes",
                column: "emotionIdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "quotes");

            migrationBuilder.DropTable(
                name: "emotions");
        }
    }
}
