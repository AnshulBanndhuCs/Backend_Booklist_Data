using BookList_Backend.Models.Models;
using BookList_Backend.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList_Backend.DataAccess.Repository.IRepository
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAllGenre();
        Task<Genre> GetGenreByIdAsync(int genId);
        Task<Genre> AddGenreAsync(Genre genre);
        Task<bool> GenreExistsAsync(int genId);
        Task<bool> DeleteGenreAsync(int genId);

    }
}
