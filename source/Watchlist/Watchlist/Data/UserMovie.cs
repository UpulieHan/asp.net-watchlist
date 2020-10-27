using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Watchlist.Data
{
    //A data model class (used to represent DB entitities)
    //This class is used to represent the many-to-many relationships (the join table) in the relational DB
    //figuratively sits between the 2 tables and contains records and PKs of both
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
