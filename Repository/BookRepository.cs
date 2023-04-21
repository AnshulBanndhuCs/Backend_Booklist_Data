using BookList_Backend.DataAccess.Data;
using BookList_Backend.DataAccess.Repository.IRepository;
using BookList_Backend.Models.Models;
using BookList_Backend.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookList_Backend.DataAccess.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        //Save
        public async Task<Books> AddBookAsync([FromBody] BookVM bookvm)
        {
            if (bookvm != null)
            {
                Books books = new();
                books.title = bookvm.title;
                books.description = bookvm.description;
                books.author = bookvm.author;
                books.image = bookvm.image;
                //books.GenreId = bookvm.Genre.Id;
                books.genreId = bookvm.GenreId;
                await _context.Books.AddAsync(books);
                await _context.SaveChangesAsync();
                return books;
            }
            return null;
        }
        public async Task<string> AddImage(IFormFile file)
        {
            var GuidId = Guid.NewGuid().ToString();
            var filename = GuidId + "_" + file.FileName;
            var fileUploadPath = Path.Combine(Directory.GetCurrentDirectory(), @"Images\BookImages", filename);
            using (FileStream fileStream = new FileStream(fileUploadPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return Path.Combine(@"Images\BookImages", filename);
        }
        public async Task<bool> UpdateImage(int id, string ImageUrl)
        {
            var bookInDb = await GetBooksByIdAsync(id);
            if (bookInDb != null)
            {
                if (bookInDb.image == null)
                    bookInDb.image = ImageUrl;
                else
                {
                    var oldImgPath = Path.Combine(Directory.GetCurrentDirectory(), bookInDb.image.TrimStart('\\'));
                    if (oldImgPath != null)
                    {
                        if (File.Exists(oldImgPath))
                        {
                            File.Delete(oldImgPath);
                        }
                    }
                    bookInDb.image = ImageUrl;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        //Find
        public async Task<bool> BookExistsAsync(int bookId)
        {
            return await _context.Books.AnyAsync(b => b.id == bookId);
        }
        //Delete
        public async Task<bool> DeleteBookAsync(int bookId)
        {
            var bookFromDb = await GetBooksByIdAsync(bookId);
            if (bookFromDb != null)
            {
                _context.Books.Remove(bookFromDb);
                if (bookFromDb.image != null)
                {

                    var oldImgPath = Path.Combine(Directory.GetCurrentDirectory(), bookFromDb.image.TrimStart('\\'));
                    if (oldImgPath != null)
                    {
                        if (File.Exists(oldImgPath))
                        {
                            File.Delete(oldImgPath);
                        }
                    }
                }
                _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        //Display
        public async Task<List<Books>> GetAllBooksAsync()
        {
            //return await _context.Books.ToListAsync();
            return await _context.Books.Include(nameof(Genre)).ToListAsync();
        }
        //Find
        public async Task<Books> GetBooksByIdAsync(int bookId)
        {
            return await _context.Books.FindAsync(bookId);
            //return await _context.Books.include(t => t.genre).where(t => t.genreid == bookid).tolist();

        }

        public Task<List<Books>> GetBooksInGenre(int genreId)
        {
            throw new NotImplementedException();
        }

        //Update
        public async Task<Books> UpdateBookAsync(int bookId, BookVM bookVM)
        {
            var bookInDb = await _context.Books.FindAsync(bookId);
            if (bookInDb != null)
            {
                bookInDb.title = bookVM.title;
                bookInDb.description = bookVM.description;
                bookInDb.author = bookVM.author;
                bookInDb.image = bookVM.image;
                bookInDb.genreId = bookVM.GenreId;
                //bookInDb.GenreId = bookVM.Genre.Id;
                //bookInDb.Genre.Name = bookVM.Genre.Name;
                //bookInDb.Genre.Name = bookVM.Books.Genre.Name;
                await _context.SaveChangesAsync();
                return bookInDb;
            }
            return null;
        }

    }
}
