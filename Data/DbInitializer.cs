using System;
using System.Linq;
using MvcMovie.Models;

namespace MvcMovie.Data;

public static class DbInitializer
{
    public static void Initialize(MvcMovieContext context)
    {
        try
        {
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }

            var movies = new Movie[]
            {
                new Movie{Title="The Shawshank Redemption", ReleaseDate=new DateTime(1994,9,23), Genre="Drama", Price=9.99M, Rating="R"},
                new Movie{Title="Inception", ReleaseDate=new DateTime(2010,7,16), Genre="Science Fiction", Price=12.99M, Rating="PG-13"},
                new Movie{Title="The Matrix", ReleaseDate=new DateTime(1999,3,31), Genre="Action", Price=8.99M, Rating="R"}
            };

            context.Movie.AddRange(movies);
            context.SaveChanges();
        }
        catch
        {
            // If database schema doesn't match the model (missing column), skip seeding.
        }
    }
}
