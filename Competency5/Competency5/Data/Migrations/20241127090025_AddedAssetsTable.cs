using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Competency5.Migrations
{
    /// <inheritdoc />
    public partial class AddedAssetsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InitalCost = table.Column<double>(type: "float", nullable: false),
                    SalvageValue = table.Column<double>(type: "float", nullable: false),
                    AddedToInventory = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemovedFromInventory = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");
        }
    }
}
