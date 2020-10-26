using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Watchlist.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //As many-to-many relationship has no ability to auto-migrate we have to yse the Fluent API
        //Fluent API is used to give EF instructions on building,modifying the DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //to map keys
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserMovie>()
                .HasKey(t => new { t.UserId, t.MovieId });
        }

        //Adding DbSet objects for Movies and UserMovies classes
        //Didn't add ApplicationUser class because it's already an AspNetUsers table in the database (anything you add to ApplicationUser will automatically translated to AspNetUsers table in the database)
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserMovie> UserMovies { get; set; }
    }
}
