using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalJournal.MVCApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedByUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subsections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subsections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    MoodId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubsectionId1 = table.Column<int>(type: "int", nullable: true),
                    SubsectionText1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubsectionId2 = table.Column<int>(type: "int", nullable: true),
                    SubsectionText2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubsectionId3 = table.Column<int>(type: "int", nullable: true),
                    SubsectionText3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubsectionId4 = table.Column<int>(type: "int", nullable: true),
                    SubsectionText4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubsectionId5 = table.Column<int>(type: "int", nullable: true),
                    SubsectionText5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JournalEntries_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalEntries_Moods_MoodId",
                        column: x => x.MoodId,
                        principalTable: "Moods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalEntries_Subsections_SubsectionId1",
                        column: x => x.SubsectionId1,
                        principalTable: "Subsections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalEntries_Subsections_SubsectionId2",
                        column: x => x.SubsectionId2,
                        principalTable: "Subsections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalEntries_Subsections_SubsectionId3",
                        column: x => x.SubsectionId3,
                        principalTable: "Subsections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalEntries_Subsections_SubsectionId4",
                        column: x => x.SubsectionId4,
                        principalTable: "Subsections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalEntries_Subsections_SubsectionId5",
                        column: x => x.SubsectionId5,
                        principalTable: "Subsections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_CategoryId",
                table: "JournalEntries",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_MoodId",
                table: "JournalEntries",
                column: "MoodId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_SubsectionId1",
                table: "JournalEntries",
                column: "SubsectionId1");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_SubsectionId2",
                table: "JournalEntries",
                column: "SubsectionId2");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_SubsectionId3",
                table: "JournalEntries",
                column: "SubsectionId3");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_SubsectionId4",
                table: "JournalEntries",
                column: "SubsectionId4");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_SubsectionId5",
                table: "JournalEntries",
                column: "SubsectionId5");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalEntries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Moods");

            migrationBuilder.DropTable(
                name: "Subsections");
        }
    }
}
