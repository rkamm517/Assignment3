using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    //Temp Storage to hold data while app is running
    public static class TempStorage
    {
        //create movie list
        private static List<MovieInfo> movies = new List<MovieInfo>();

        public static IEnumerable<MovieInfo> Movies => movies;

        //Append movie list with new movie
        public static void AddMovie(MovieInfo movie)
        {
            movies.Add(movie);
        }
    }
}
