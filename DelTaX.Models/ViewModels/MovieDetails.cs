using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelTaX.Models.ViewModels
{
    public class MovieDetails
    {
        
        [DisplayName("Movie Name")]
        public string MovieName { get; set; } = null!;
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("Producer Name")]
        public string ProducerName { get; set; } = null!;
        [DisplayName("Actor")]
        public string ActorName { get; set; } = null;
    }

    public class AddMovieDetails
    {
        public AddMovieDetails()
        {
            this.ActorNames = new List<string>();
        }
        [DisplayName("Movie Id")]
        public int MovieId { get; set; }
        [DisplayName("Movie Name")]
        public string MovieName { get; set; } = null!;
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("Producer Name")]
        public string ProducerName { get; set; } = null!;
        [DisplayName("Actors Names")]
        public List<string> ActorNames { get; set; } = null!;
    }

    public class EditMovieDetails
    {
        public EditMovieDetails()
        {
            this.Actors = new List<Models.EntityModels.Actor>();
        }
        [DisplayName("Movie Id")]
        public int MovieId { get; set; }
        [DisplayName("Movie Name")]
        public string MovieName { get; set; } = null!;
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("Producer Name")]
        public Models.EntityModels.Producer Producer { get; set; } = null!;
        [DisplayName("Actors Names")]
        public List<Models.EntityModels.Actor> Actors { get; set; } = null!;
    }
}
