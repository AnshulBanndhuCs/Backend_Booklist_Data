using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookList_Backend.DataAccess.Migrations
{
    public partial class changeIdColNameinGenreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Genres",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Genres",
                newName: "GenreId");
        }
    }
}
