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
                    { new Guid("019b27c4-40b0-70c7-8762-3ff661b5ac90"), new DateTime(2025, 12, 16, 15, 25, 31, 696, DateTimeKind.Utc).AddTicks(4911), 1, null, "Action", "Active" },
                    { new Guid("019b27c4-40b0-73ef-b033-4f48ee3c444f"), new DateTime(2025, 12, 16, 15, 25, 31, 696, DateTimeKind.Utc).AddTicks(5317), 3, null, "History", "Active" },
                    { new Guid("019b27c4-40b0-77a2-b4f5-85bf2ccc57d3"), new DateTime(2025, 12, 16, 15, 25, 31, 696, DateTimeKind.Utc).AddTicks(5315), 2, null, "Sci-fi", "Active" }
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
