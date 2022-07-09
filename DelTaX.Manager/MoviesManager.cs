using DelTaX.Entities;
using DelTaX.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelTaX.Manager
{
    public class MoviesManager
    {
        private IMovieQueries movieQueries { get; set; }
        public MoviesManager()
        {
            this.movieQueries= new MovieQueries();
        }
        public List<MovieDetails> GetAllMovieDetails()
        {
            return movieQueries.GetAllMovieDetails();
        }

        public int AddMovieDetails(AddMovieDetails addEditMovieDetails)
        {
            return movieQueries.AddMovieDetails(addEditMovieDetails);
        }

        public int EditMovieDetails(EditMovieDetails editMovieDetails)
        {
            return movieQueries.EditMovieDetails(editMovieDetails);
        }

    }
}
