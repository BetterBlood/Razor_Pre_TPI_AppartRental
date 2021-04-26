using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Pre_TPI_AppartRental.Data
{
    public class ApplicationUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public virtual ICollection<UserAppartement> WishList { get; set; }
        public string FirstName { get; set; }
        public virtual ICollection<RatingInfo> RatingInfo { get; set; }

        public ApplicationUser() : base()
        {
            this.WishList = new HashSet<UserAppartement>();
            this.RatingInfo = new HashSet<RatingInfo>();
        }
    }
}
