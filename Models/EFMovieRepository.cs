using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    //Inherits from the repo interface
    public class EFMovieRepository : IMovieRepository
    {
        private MovieDbContext _context;

        //Constructor
        public EFMovieRepository(MovieDbContext context)
        {
            _context = context;
        }
        public IQueryable<MovieInfo> Movies => _context.Movies;
    }
}
