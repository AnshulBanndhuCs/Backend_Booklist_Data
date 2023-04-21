using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookList_Backend.DataAccess.Migrations
{
    public partial class editGenreTableColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Genres",
                newName: "genreName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Genres",
                newName: "genreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "genreName",
                table: "Genres",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "genreId",
                table: "Genres",
                newName: "Id");
        }
    }
}
