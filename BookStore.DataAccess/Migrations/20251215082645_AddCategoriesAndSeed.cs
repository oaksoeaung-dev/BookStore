using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriesAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    RecordState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DisplayOrder", "ModifiedAt", "Name", "RecordState" },
                values: new object[,]
                {
                    { new Guid("019b211e-7d79-725c-b250-47d2dc3f9079"), new DateTime(2025, 12, 15, 8, 26, 44, 985, DateTimeKind.Utc).AddTicks(917), 1, null, "Action", "Active" },
                    { new Guid("019b211e-7d79-743b-ba1b-67c50cd3e00d"), new DateTime(2025, 12, 15, 8, 26, 44, 985, DateTimeKind.Utc).AddTicks(1370), 2, null, "Sci-fi", "Active" },
                    { new Guid("019b211e-7d79-7fc3-bbf8-1b8b29f3fce5"), new DateTime(2025, 12, 15, 8, 26, 44, 985, DateTimeKind.Utc).AddTicks(1372), 3, null, "History", "Active" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
