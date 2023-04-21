using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookList_Backend.DataAccess.Migrations
{
    public partial class editDescriptionColInBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_GenreId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Books",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Books",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Books",
                newName: "genreId");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Books",
                newName: "author");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Books",
                newName: "description");

            migrationBuilder.RenameIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                newName: "IX_Books_genreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_genreId",
                table: "Books",
                column: "genreId",
                principalTable: "Genres",
                principalColumn: "genreId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_genreId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Books",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "Books",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "genreId",
                table: "Books",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "author",
                table: "Books",
                newName: "Author");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Books",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Books",
                newName: "description");

            migrationBuilder.RenameIndex(
                name: "IX_Books_genreId",
                table: "Books",
                newName: "IX_Books_GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_GenreId",
                table: "Books",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "genreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
