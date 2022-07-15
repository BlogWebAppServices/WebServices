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
    public class childCategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public childCategoriesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/childCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<childCategory>>> GetchildCategories()
        {
          if (_context.childCategories == null)
          {
              return NotFound();
          }
            return await _context.childCategories.ToListAsync();
        }

        // GET: api/childCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<childCategory>> GetchildCategory(int id)
        {
          if (_context.childCategories == null)
          {
              return NotFound();
          }
            var childCategory = await _context.childCategories.FindAsync(id);

            if (childCategory == null)
            {
                return NotFound();
            }

            return childCategory;
        }

        // PUT: api/childCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutchildCategory(int id, childCategory childCategory)
        {
            if (id != childCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(childCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!childCategoryExists(id))
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

        // POST: api/childCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<childCategory>> PostchildCategory(childCategory childCategory)
        {
          if (_context.childCategories == null)
          {
              return Problem("Entity set 'DataContext.childCategories'  is null.");
          }
            _context.childCategories.Add(childCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetchildCategory", new { id = childCategory.Id }, childCategory);
        }

        // DELETE: api/childCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletechildCategory(int id)
        {
            if (_context.childCategories == null)
            {
                return NotFound();
            }
            var childCategory = await _context.childCategories.FindAsync(id);
            if (childCategory == null)
            {
                return NotFound();
            }

            _context.childCategories.Remove(childCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool childCategoryExists(int id)
        {
            return (_context.childCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
