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
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext context;

        public MoviesController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<MoviesController>
        [HttpGet]
        public ActionResult getAllMovies()
        {
            try
            {
                return Ok(context.movies.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}", Name="GetMovie")]
        public ActionResult Get(string id)
        {
            try
            {
                var movie = context.movies.FirstOrDefault(movieElement => movieElement.Code == id);
                return Ok(movie);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
         
        }

        // POST api/<MoviesController>
        [HttpPost]
        public ActionResult Post([FromBody] Movie movie)
        {
            try
            {
                context.movies.Add(movie);
                context.SaveChanges();
                return CreatedAtRoute("GetMovie", new { id = movie.Code }, movie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Movie movie)
        {
            try
            {
                if (movie.Code == id)
                {
                    context.Entry(movie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetMovie", new { id = movie.Code }, movie);
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

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                var movie = context.movies.FirstOrDefault(movieElement => movieElement.Code == id);
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
