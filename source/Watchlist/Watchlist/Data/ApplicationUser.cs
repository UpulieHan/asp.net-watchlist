using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Watchlist.Data
{
    //ASP.NET Identity already has an object called User that is reserved for accessing the currently logged in user account.So you don’t want to name your user entity class User
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {
            //a collection or list of UserMovie objects (all the UserMovie objects containing the user's Id)
            this.Watchlist = new HashSet<UserMovie>();
        }

        public string FirstName { get; set; }
        public virtual ICollection<UserMovie> Watchlist { get; set; }
    }
}
