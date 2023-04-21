using BookList_Backend.Models.Models;
using BookList_Backend.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList_Backend.DataAccess.Repository.IRepository
{
    public interface IBookRepository
    {
        Task<List<Books>> GetAllBooksAsync();
        Task<List<Books>> GetBooksInGenre(int genreId);
        Task<Books> GetBooksByIdAsync(int bookId);
        Task<Books> AddBookAsync(BookVM bookvm);
        Task<string> AddImage(IFormFile file);
        Task<bool> UpdateImage(int id, string ImageUrl);
        Task<bool> BookExistsAsync(int bookId);
        Task<bool> DeleteBookAsync(int bookId);
        Task<Books> UpdateBookAsync(int bookId, BookVM bookVM);
        
    }
}
