using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizgame.Migrations
{
    /// <inheritdoc />
    public partial class updateddatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "quizgames");

            migrationBuilder.DropColumn(
                name: "Options",
                table: "quizgames");

            migrationBuilder.DropColumn(
                name: "Questions",
                table: "quizgames");

            migrationBuilder.AddColumn<int>(
                name: "CorrectOptionId",
                table: "quizgames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "quizgames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "quizoptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuizId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quizoptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quizoptions_quizgames_QuizId",
                        column: x => x.QuizId,
                        principalTable: "quizgames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_quizoptions_QuizId",
                table: "quizoptions",
                column: "QuizId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "quizoptions");

            migrationBuilder.DropColumn(
                name: "CorrectOptionId",
                table: "quizgames");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "quizgames");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "quizgames",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Options",
                table: "quizgames",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Questions",
                table: "quizgames",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
