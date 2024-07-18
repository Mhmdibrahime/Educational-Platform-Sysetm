using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationalPlatform1._0.Migrations
{
    /// <inheritdoc />
    public partial class version21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuizTitle",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuizTitle",
                table: "Grades");
        }
    }
}
