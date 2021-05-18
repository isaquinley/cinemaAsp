using cinemaback.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinemaback.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext>options): base(options)
        {

        }

        public DbSet<Movie> movies { get; set; }
        public DbSet<Salas> salas { get; set; }
        public DbSet<Bookedmovies> bookedmovies { get; set; }
        public DbSet<Users> users { get; set; }
    }
}
