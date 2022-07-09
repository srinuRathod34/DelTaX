using DelTaX.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelTaX.Entities
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DBSetUp.DelTaXDB);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovieMapping>()
                .HasKey(a => new { a.ActorId, a.MovieId });
        }
        public DbSet<Actor> ActorDetails { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Producer> Producer { get; set; }
        public DbSet<ActorMovieMapping> ActorMovieMappings { get; set; }
    }
}
