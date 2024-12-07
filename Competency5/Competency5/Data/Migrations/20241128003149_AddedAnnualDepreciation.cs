using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Competency5.Migrations
{
    /// <inheritdoc />
    public partial class AddedAnnualDepreciation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "annualDepreciation",
                table: "Assets",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "annualDepreciation",
                table: "Assets");
        }
    }
}
