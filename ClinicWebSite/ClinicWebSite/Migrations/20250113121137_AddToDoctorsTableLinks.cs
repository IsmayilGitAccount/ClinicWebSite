using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicWebSite.Migrations
{
    /// <inheritdoc />
    public partial class AddToDoctorsTableLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramLink",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterLink",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "InstagramLink",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "TwitterLink",
                table: "Doctors");
        }
    }
}
