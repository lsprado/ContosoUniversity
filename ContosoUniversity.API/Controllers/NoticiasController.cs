using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.API.Data;
using ContosoUniversity.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiasController : ControllerBase
    {
        private readonly ContosoUniversityAPIContext _context;

        public NoticiasController(ContosoUniversityAPIContext context)
        {
            _context = context;
        }

        // GET: api/Noticias
        [HttpGet]
        public IActionResult GetNoticia()
        {
            var noticias = _context.Noticia;

            //Transform to DTO
            var result = new DTO.NoticiaResult()
            {
                Noticias = noticias.Select(c => new DTO.Noticia()
                {
                    ID = c.ID,
                    Title = c.Title,
                    Texto = System.Net.WebUtility.HtmlDecode(c.Texto)
                }).ToList()
            };

            return Ok(result);

        }

        // GET: api/Noticias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoticia([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var noticia = await _context.Noticia.FindAsync(id);

            if (noticia == null)
            {
                return NotFound();
            }

            //Transform to DTO
            var result = new DTO.Noticia()
            {
                ID = noticia.ID,
                Title = noticia.Title,
                Texto = noticia.Texto
            };

            return Ok(result);
        }

        // PUT: api/Noticias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoticia([FromRoute] int id, [FromBody] Noticia noticia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != noticia.ID)
            {
                return BadRequest();
            }

            _context.Entry(noticia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticiaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Noticias
        [HttpPost]
        public async Task<IActionResult> PostNoticia([FromBody] Noticia noticia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Noticia.Add(noticia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNoticia", new { id = noticia.ID }, noticia);
        }

        // DELETE: api/Noticias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoticia([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var noticia = await _context.Noticia.FindAsync(id);
            if (noticia == null)
            {
                return NotFound();
            }

            _context.Noticia.Remove(noticia);
            await _context.SaveChangesAsync();

            return Ok(noticia);
        }

        private bool NoticiaExists(int id)
        {
            return _context.Noticia.Any(e => e.ID == id);
        }
    }
}