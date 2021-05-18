using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cinemaback.Models
{
    public class Users
    {
        [Key]
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Boolean isAdmin { get; set; }

    }
}
