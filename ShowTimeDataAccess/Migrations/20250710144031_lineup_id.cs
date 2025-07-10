using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShowTime.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class lineup_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Lineups",
                table: "Lineups");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Lineups",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lineups",
                table: "Lineups",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Lineups_FestivalId",
                table: "Lineups",
                column: "FestivalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Lineups",
                table: "Lineups");

            migrationBuilder.DropIndex(
                name: "IX_Lineups_FestivalId",
                table: "Lineups");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Lineups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lineups",
                table: "Lineups",
                columns: new[] { "FestivalId", "ArtistId" });
        }
    }
}
