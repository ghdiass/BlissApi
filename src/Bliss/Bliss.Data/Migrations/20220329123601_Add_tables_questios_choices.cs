using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bliss.Data.Migrations
{
    public partial class Add_tables_questios_choices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumb_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Published_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Choice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Votes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choices_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Image_url", "Published_at", "Question", "Thumb_url", "Update_at" },
                values: new object[] { 1, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2022, 3, 29, 9, 36, 0, 858, DateTimeKind.Local).AddTicks(8981), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)", null });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "Choice", "QuestionId", "Votes" },
                values: new object[,]
                {
                    { 1, "Swift", 1, 0 },
                    { 2, "Python", 1, 0 },
                    { 3, "Objective-C", 1, 0 },
                    { 4, "Ruby", 1, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Choices_QuestionId",
                table: "Choices",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
