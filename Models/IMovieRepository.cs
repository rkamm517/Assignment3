using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    //Repository meant to be inherited
    public interface IMovieRepository
    {
        IQueryable<MovieInfo> Movies { get; }
    }
}
