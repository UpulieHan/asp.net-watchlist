using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Watchlist.Data
{
    public class UserMovie
    {
        //UserId and MovieId are composite keys
        public string UserId { get; set; }
        public int MovieId { get; set; }

        public bool Watched { get; set; }
        public int Rating { get; set; }

        //virtual properties represent the relationship between the UserMovie object and the ApplicationUser and Movie objects
        public virtual ApplicationUser User { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
