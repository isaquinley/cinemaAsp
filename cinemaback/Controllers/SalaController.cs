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
    public class SalaController : ControllerBase
    {
        private readonly AppDbContext context;

        public SalaController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<SalaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.salas.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<SalaController>/5
        [HttpGet("{id}", Name = "GetSala")]
        public ActionResult Get(string id)
        {
            try
            {
                var sala = context.salas.FirstOrDefault(salaElement => salaElement.Code == id);
                return Ok(sala);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<SalaController>
        [HttpPost]
        public ActionResult Post([FromBody] Salas sala)
        {
            try
            {
                context.salas.Add(sala);
                context.SaveChanges();
                return CreatedAtRoute("GetSala", new { id = sala.Code }, sala);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<SalaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Salas sala)
        {
            try
            {
                if (sala.Code == id)
                {
                    context.Entry(sala).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetSala", new { id = sala.Code }, sala);
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

        // DELETE api/<SalaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                var sala = context.movies.FirstOrDefault(salaElement => salaElement.Code == id);
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
