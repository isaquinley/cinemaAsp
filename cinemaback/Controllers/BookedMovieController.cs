using cinemaback.Context;
using cinemaback.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cinemaback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookedMovieController : ControllerBase
    {
        private readonly AppDbContext context;

        public BookedMovieController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<BookedMovieController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.bookedmovies.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<BookedMovieController>/5
        [HttpGet("{id}", Name ="GetBookedMovie")]
        public ActionResult Get(string id)
        {
            try
            {
                var bookedMovie = context.bookedmovies.FirstOrDefault(bookedmoviesElement => bookedmoviesElement.BookingCode == id);
                return Ok(bookedMovie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<BookedMovieController>
        [HttpPost]
        public ActionResult Post([FromBody] Bookedmovies bookedmovie)
        {
            try
            {
                context.bookedmovies.Add(bookedmovie);
                context.SaveChanges();
                return CreatedAtRoute("GetBookedMovie", new { id = bookedmovie.BookingCode }, bookedmovie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<BookedMovieController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Bookedmovies bookedmovie)
        {
            try
            {
                if (bookedmovie.BookingCode == id)
                {
                    context.Entry(bookedmovie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetMovie", new { id = bookedmovie.BookingCode }, bookedmovie);
                }
                else
                {

                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<BookedMovieController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                var bookedmovie = context.bookedmovies.FirstOrDefault(bookedmovieElement => bookedmovieElement.BookingCode == id);
                context.SaveChanges();
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
