using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriesTableAndSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { new Guid("019b1764-de89-7041-9480-e929bce37644"), new DateTime(2025, 12, 13, 11, 7, 25, 193, DateTimeKind.Utc).AddTicks(6483), 1, null, "Action", "Active" },
                    { new Guid("019b1764-de89-72f4-8f68-2cc968d1cdb2"), new DateTime(2025, 12, 13, 11, 7, 25, 193, DateTimeKind.Utc).AddTicks(6888), 3, null, "History", "Active" },
                    { new Guid("019b1764-de89-7e46-83f2-b22fabd14427"), new DateTime(2025, 12, 13, 11, 7, 25, 193, DateTimeKind.Utc).AddTicks(6886), 2, null, "Sci-fi", "Active" }
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
