using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookList_Backend.Models.Models;


namespace BookList_Backend.DataAccess.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {   
        }
        public DbSet<Books> Books  { get; set; }
        public DbSet<Genre> Genres  { get; set; }
    }
}
