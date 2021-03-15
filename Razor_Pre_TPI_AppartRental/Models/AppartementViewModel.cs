using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Pre_TPI_AppartRental.Models
{
    public class AppartementViewModel
    {
        public int AppartementId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public bool InWishlist { get; set; }
        public int Surface { get; set; }
        public bool Visited { get; set; }
        public int? Rating { get; set; }
        
    }
}
