using BookList_Backend.DataAccess.Data;
using BookList_Backend.DataAccess.Repository.IRepository;
using BookList_Backend.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList_Backend.DataAccess.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        //Save
        public async Task<Genre> AddGenreAsync(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
            return genre;
        }
        //Delete
        public async Task<bool> DeleteGenreAsync(int genId)
        {
            var genFromDb = await GetGenreByIdAsync(genId);
            if (genFromDb != null)
            {
                _context.Genres.Remove(genFromDb);
            }
            return false;
        }
        //Exists
        public async Task<bool> GenreExistsAsync(int genId)
        {
            return await _context.Genres.AnyAsync(b => b.Id == genId);
        }
        //Display
        public async Task<List<Genre>> GetAllGenre()
        {
            return await _context.Genres.ToListAsync();
        }
        //FindOne
        public async Task<Genre> GetGenreByIdAsync(int genId)
        {
            return await _context.Genres.FindAsync(genId);
        }

    }
}
