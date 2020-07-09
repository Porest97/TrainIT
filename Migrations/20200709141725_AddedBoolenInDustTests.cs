using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainIT.Migrations
{
    public partial class AddedBoolenInDustTests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "DustTest",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "DustTest");
        }
    }
}
