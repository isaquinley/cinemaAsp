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
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext context;

        public UsersController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.users.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}", Name ="GetUser")]
        public ActionResult Get(int id)
        {
            try
            {
                var movie = context.users.FirstOrDefault(userElement => userElement.Cedula == id);
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] Users user)
        {
            try
            {
                context.users.Add(user);
                context.SaveChanges();
                return CreatedAtRoute("GetUser", new { id = user.Cedula }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Users user)
        {
            try
            {
                if (user.Cedula == id)
                {
                    context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetUser", new { id = user.Cedula }, user);
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

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var user = context.users.FirstOrDefault(userElement => userElement.Cedula == id);
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
