using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Watchlist.Data;
using Watchlist.Models;

namespace Watchlist.Controllers
{
    public class WatchlistController : Controller
    {


        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        //access the database context through ASP.NET's dependency injection
        //to get the currently logged-in user, invoke the UserManger service from .NET identity 
        public WatchlistController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //to get the user information (a private method to call the service)
        private Task<ApplicationUser> GetCurrentUserAsync() =>
            _userManager.GetUserAsync(HttpContext.User);


        //a public HTTP GET request to retrieve the user id
        [HttpGet]
        public async Task<string> GetCurrentUserId()
        {
            ApplicationUser user = await GetCurrentUserAsync();
            return user?.Id;
        }

        //changed the method signature from synchronous to asynchronous task (required to call methods from the UserManager service)
        public async Task<IActionResult> Index()
        {
            //retrieving data to contruct the view model for the watchlist
            var id = await GetCurrentUserId();
            //a LINQ query
            var userMovies = _context.UserMovies.Where(x => x.UserId == id);
            //contruct a list of MovieViewModel objects 
            var model = userMovies.Select(x => new MovieViewModel
            {
                MovieId = x.MovieId,
                Title = x.Movie.Title,
                Year = x.Movie.Year,
                Watched = x.Watched,
                InWatchlist = true,
                Rating = x.Rating

            }).ToList();
            //rencer the data in a dynamic HTML file
            return View(model);
        }
    }
}
