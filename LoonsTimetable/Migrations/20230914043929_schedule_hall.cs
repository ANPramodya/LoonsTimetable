using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoonsTimetable.Migrations
{
    public partial class schedule_hall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HallNo",
                table: "ExamSchedule",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HallNo",
                table: "ExamSchedule");
        }
    }
}
