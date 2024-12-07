using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Competency5.Migrations
{
    /// <inheritdoc />
    public partial class IDontNeedAnnualDep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "annualDepreciation",
                table: "Assets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "annualDepreciation",
                table: "Assets",
                type: "float",
                nullable: true);
        }
    }
}
