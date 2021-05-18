using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cinemaback.Models
{
    public class Bookedmovies
    {
        [Key]
        public string BookingCode { get; set; }
        public string SalaCode { get; set; }
        public string SalaName { get; set; }
        public string Schedule { get; set; }
        public string MovieCode { get; set; }
        public string MovieName { get; set; }
        public int Ranking { get; set; }
    }
}
