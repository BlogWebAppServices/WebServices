using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kulturDelisiWebAPI.Data;
using kulturDelisiWebAPI.Models.articleModel;

namespace kulturDelisiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class articlesController : ControllerBase
    {
        private readonly DataContext _context;

        public articlesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/articles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<article>>> GetArticles()
        {
          if (_context.Articles == null)
          {
              return NotFound();
          }
            return await _context.Articles.ToListAsync();
        }

        // GET: api/articles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<article>> Getarticle(int id)
        {
          if (_context.Articles == null)
          {
              return NotFound();
          }
            var article = await _context.Articles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return article;
        }

        // PUT: api/articles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putarticle(int id, article article)
        {
            if (id != article.id)
            {
                return BadRequest();
            }

            _context.Entry(article).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!articleExists(id))
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

        // POST: api/articles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<article>> Postarticle(article article)
        {
          if (_context.Articles == null)
          {
              return Problem("Entity set 'DataContext.Articles'  is null.");
          }
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getarticle", new { id = article.id }, article);
        }

        // DELETE: api/articles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletearticle(int id)
        {
            if (_context.Articles == null)
            {
                return NotFound();
            }
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool articleExists(int id)
        {
            return (_context.Articles?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
