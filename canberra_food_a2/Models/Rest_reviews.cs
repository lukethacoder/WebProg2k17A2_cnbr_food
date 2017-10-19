using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace canberra_food_a2.Models
{
    public class Rest_reviews
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public string Heading { get; set; }
        public string Comment { get; set; }
        public string Restaurant { get; set; }
        public int Rating { get; set; }
    }
}
