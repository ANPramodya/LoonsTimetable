using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoonsTimetable.Migrations
{
    public partial class exam_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExamName",
                table: "ExamSchedule",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamName",
                table: "ExamSchedule");
        }
    }
}
