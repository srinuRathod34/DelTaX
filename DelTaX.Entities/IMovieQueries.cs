using DelTaX.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelTaX.Entities
{
    public interface IMovieQueries
    {
        List<MovieDetails> GetAllMovieDetails();
        int AddMovieDetails(AddMovieDetails addEditMovieDetails);
        int EditMovieDetails(EditMovieDetails editMovieDetails);
    }
}
