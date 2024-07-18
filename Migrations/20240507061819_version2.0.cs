using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationalPlatform1._0.Migrations
{
    /// <inheritdoc />
    public partial class version20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grades",
                table: "Grades");

            migrationBuilder.AddColumn<int>(
                name: "Percentage",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WrongAnswers",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "WrongAnswers",
                table: "Grades");

            migrationBuilder.AddColumn<string>(
                name: "Grades",
                table: "Grades",
                type: "varchar",
                nullable: false,
                defaultValue: "");
        }
    }
}
