using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kulturDelisiWebAPI.Data;
using kulturDelisiWebAPI.Models.categoryModel;

namespace kulturDelisiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public categoriesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<category>>> GetCategories()
        {
          if (_context.Categories == null)
          {
              return NotFound();
          }
            return await _context.Categories.Where(x => x.isActive && !x.isDeleted).ToListAsync();
        }

        // GET: api/categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<category>> Getcategory(int id)
        {
          if (_context.Categories == null)
          {
              return NotFound();
          }
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcategory(int id, category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!categoryExists(id))
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

        // POST: api/categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
      
        public async Task<ActionResult<category>> Postcategory(category category)
        {
          if (_context.Categories == null)
          {
              return Problem("Entity set 'DataContext.Categories'  is null.");
          }
       

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcategory", new { id = category.Id }, category);
        }

        // DELETE: api/categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecategory(int id)
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool categoryExists(int id)
        {
            return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
