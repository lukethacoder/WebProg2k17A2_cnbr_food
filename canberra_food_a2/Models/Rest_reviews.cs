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
        public string Name { get; set; }
        public string Heading { get; set; }
        public string Comment { get; set; }
        public string Restaurant { get; set; }
        public int Rating { get; set; }
        public int Agree { get; set; }
        /* public bool IsClicked { get; set; } */
        public int Disagree { get; set; }
    }
}
