using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "BirthDate", "BirthPlace", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { new Guid("93cce6cd-69ae-4550-a6cd-8b815e87267b"), new DateOnly(2003, 3, 6), "Ba Vi", "Thanh", 1, "Tu" },
                    { new Guid("c98b23a4-d206-4b19-acb8-a361979a2d6c"), new DateOnly(2003, 4, 15), "Ba Vi", "Tai", 0, "Tue" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
