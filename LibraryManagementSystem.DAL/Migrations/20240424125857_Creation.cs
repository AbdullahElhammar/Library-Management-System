using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationYear = table.Column<int>(type: "int", nullable: false),
                    BookISBN = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patron",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patron", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookPatron",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    PatronsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPatron", x => new { x.BooksId, x.PatronsId });
                    table.ForeignKey(
                        name: "FK_BookPatron_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookPatron_Patron_PatronsId",
                        column: x => x.PatronsId,
                        principalTable: "Patron",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowingRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    PatronId = table.Column<int>(type: "int", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowingRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowingRecord_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowingRecord_Patron_PatronId",
                        column: x => x.PatronId,
                        principalTable: "Patron",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Author", "BookISBN", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { 1, "Ibn Alqim", 1, 2000, "Aldaa w Aldwaa" },
                    { 2, "Albokhary", 2, 1200, "Albokhary" },
                    { 3, "Ahmed Khalil", 3, 2010, "Mindset Of Solution" },
                    { 4, "Ibn Alqim", 4, 2002, "Benefits" }
                });

            migrationBuilder.InsertData(
                table: "Patron",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "cairo", "ahmed" },
                    { 2, "alex", "ali" },
                    { 3, "Mansoura", "abdullah" },
                    { 4, "minia", "khalid" }
                });

            migrationBuilder.InsertData(
                table: "BorrowingRecord",
                columns: new[] { "Id", "BookId", "BorrowDate", "PatronId", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2024, 4, 24, 14, 58, 53, 927, DateTimeKind.Local).AddTicks(4000) },
                    { 2, 1, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2024, 4, 24, 14, 58, 53, 927, DateTimeKind.Local).AddTicks(3961) },
                    { 3, 2, new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2024, 4, 24, 14, 58, 53, 927, DateTimeKind.Local).AddTicks(3995) },
                    { 4, 1, new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2024, 4, 24, 14, 58, 53, 927, DateTimeKind.Local).AddTicks(4005) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookPatron_PatronsId",
                table: "BookPatron",
                column: "PatronsId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingRecord_BookId",
                table: "BorrowingRecord",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingRecord_PatronId",
                table: "BorrowingRecord",
                column: "PatronId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookPatron");

            migrationBuilder.DropTable(
                name: "BorrowingRecord");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Patron");
        }
    }
}
