using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Watchlist.Models
{
    //A View model
    //This class doesn't represent a specific entity in the DB but rather a mixture of elements from different ones
    //Used to make the UserMovies table readable and user-friendly
    public class MovieViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public bool InWatchlist { get; set; }
        public bool Watched { get; set; }
        public int? Rating { get; set; }
    }
}
