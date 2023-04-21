using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookList_Backend.DataAccess.Migrations
{
    public partial class editgenreIdColGenreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Genres",
                newName: "genreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "genreId",
                table: "Genres",
                newName: "Id");
        }
    }
}
