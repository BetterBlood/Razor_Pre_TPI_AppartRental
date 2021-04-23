using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Pre_TPI_AppartRental.Data
{
    public class UserAppartement
    {
        public string UserId { get; set; }
        public int AppartementId { get; set; }
        public bool Visited { get; set; }
        public int Rating { get; set; }
        public bool Rated { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Appartement Appartement { get; set; }
    }
}
