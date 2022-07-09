using DelTaX.Models;
using DelTaX.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelTaX.Entities
{
    public class MovieQueries: IMovieQueries
    {
        private Context context { get; set; }
        public MovieQueries()
        {
            this.context = new Context();
        }
        public List<MovieDetails> GetAllMovieDetails()
        {
            var movieDetails = new List<MovieDetails>();
            try
            {
                movieDetails = (from amv in context.ActorMovieMappings.AsNoTracking()
                                    join amm in context.Movie.AsNoTracking() on amv.MovieId equals amm.Id into tempAMM
                                    from success in tempAMM.DefaultIfEmpty()
                                    join ac in context.ActorDetails.AsNoTracking() on amv.ActorId equals ac.Id into tempActors
                                    from ActorData in tempActors.DefaultIfEmpty()
                                    join p in context.Producer.AsNoTracking() on success.ProducerId equals p.Id
                                    orderby amv.MovieId,success.MovieName
                                    select new MovieDetails{ MovieName=success.MovieName,
                                        ReleaseDate=success.ReleaseDate,
                                        ActorName=ActorData.ActorName,
                                        ProducerName=p.ProducerName
                                    }
                                   ).ToList();
            }
            catch (Exception ex)
            {
                Utilities.HandleException(ex);
            }
            return movieDetails;
        }

        public int AddMovieDetails(AddMovieDetails addMovieDetails)
        { 
            var AddedId = 0;
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    Entity.Producer producer = new Entity.Producer();
                    producer.ProducerName = addMovieDetails.ProducerName;
                    context.Producer.Add(producer);
                    context.SaveChanges();
                    Entity.Movie movie = new Entity.Movie();
                    movie.MovieName = addMovieDetails.MovieName;
                    movie.ProducerId = producer.Id;
                    movie.ReleaseDate = addMovieDetails.ReleaseDate;
                    context.Movie.Add(movie);
                    context.SaveChanges();
                    foreach (var actor in addMovieDetails.ActorNames)
                    {
                        Entity.Actor actorDetails = new Entity.Actor();
                        context.ActorDetails.Add(actorDetails);
                        context.SaveChanges();
                        Entity.ActorMovieMapping actorMovieMapping = new Entity.ActorMovieMapping();
                        actorMovieMapping.ActorId = actorDetails.Id;
                        actorMovieMapping.MovieId = movie.Id;
                        context.ActorMovieMappings.Add(actorMovieMapping);
                        context.SaveChanges();
                    }
                    AddedId = movie.Id;
                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                context.Database.RollbackTransaction();
                Utilities.HandleException(ex);
            }
            return AddedId;
        }

        public int EditMovieDetails(EditMovieDetails editMovieDetails)
        {
            int editedId = 0;
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    var producer = context.Producer.Where(a => a.Id == editMovieDetails.Producer.Id).FirstOrDefault();
                    Entity.Movie movie = new Entity.Movie();
                    movie.MovieName = editMovieDetails.MovieName;
                    movie.ProducerId = producer.Id;
                    context.Movie.Update(movie);
                    context.SaveChanges();
                    var actorDetails = context.ActorMovieMappings.Where(a => a.MovieId == editMovieDetails.MovieId);
                    foreach (var arc in actorDetails)
                    {
                        context.ActorMovieMappings.Remove(arc);
                        context.SaveChanges();
                    }
                    foreach (var actor in editMovieDetails.Actors)
                    {
                        Entity.ActorMovieMapping actorMovieMapping = new Entity.ActorMovieMapping();
                        actorMovieMapping.ActorId = actor.Id;
                        actorMovieMapping.MovieId = movie.Id;
                        context.ActorMovieMappings.Add(actorMovieMapping);
                        context.SaveChanges();
                    }
                    editedId = movie.Id;
                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                context.Database.RollbackTransaction();
                Utilities.HandleException(ex);
            }
            return editedId;
        }
    }
}
