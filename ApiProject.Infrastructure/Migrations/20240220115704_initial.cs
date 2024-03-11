using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlacesLeft = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeronalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MajorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "Id", "Name", "PaymentType", "PlacesLeft", "Type" },
                values: new object[,]
                {
                    { "000", "None", "None", 0, "None" },
                    { "003", "История", "Държавна поръчка", 2, "Редовно" },
                    { "004", "Археология", "Държавна поръчка", 3, "Задочно" },
                    { "005", "География", "Държавна поръчка", 4, "Редовно" },
                    { "007", "Етнология", "Държавна поръчка", 4, "Редовно" },
                    { "008", "Културен туризъм", "Държавна поръчка", 3, "Задочно" },
                    { "015", "Педагогика на обучението по български език и география", "Държавна поръчка", 1, "Редовно" },
                    { "018", "Българска филология", "Държавна поръчка", 2, "Задочно" },
                    { "044", "Балканистика", "Държавна поръчка", 5, "Редовно" },
                    { "045", "Германистика", "Държавна поръчка", 1, "Задочно" },
                    { "057", "Информационно брокерство и дигитални медии", "Държавна поръчка", 1, "Задочно" },
                    { "059", "Компютърни науки", "Държавна поръчка", 11, "Редовно" },
                    { "066", "Начална училищна педагогика и специална педагогика (Велико Търново)", "Държавна поръчка", 1, "Задочно" },
                    { "074", "Изящни изкуства – живопис", "Държавна поръчка", 1, "Редовно" },
                    { "075", "Изящни изкуства – рисуване и интермедия", "Държавна поръчка", 1, "Задочно" },
                    { "077", "Изящни изкуства – стенопис", "Държавна поръчка", 1, "Редовно" },
                    { "203", "История", "Държавна поръчка", 7603, "Задочно" },
                    { "215", "Педагогика на обучението по български език и география", "Държавна поръчка", 1, "Задочно" },
                    { "653", "Международни икономически отношения", "Платено обучение", 13, "Редовно" },
                    { "698", "Журналистика", "Платено обучение", 2, "Задочно" },
                    { "702", "Дипломация и международни отношения", "Платено обучение", 7, "Задочно" },
                    { "703", "Дипломация и международни отношения", "Платено обучение", 7, "Редовно" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_MajorId",
                table: "Users",
                column: "MajorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Majors");
        }
    }
}
