using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_AngularJS.Migrations
{
    public partial class n2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "People",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "People");
        }
    }
}
