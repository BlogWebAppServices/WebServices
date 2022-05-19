using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kulturDelisiWebAPI.Data;
using kulturDelisiWebAPI.Models.permissionModel;

namespace kulturDelisiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class permissionsController : ControllerBase
    {
        private readonly DataContext _context;

        public permissionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/permissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<permissions>>> GetPermissions()
        {
          if (_context.Permissions == null)
          {
              return NotFound();
          }
            return await _context.Permissions.ToListAsync();
        }

        // GET: api/permissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<permissions>> Getpermissions(int id)
        {
          if (_context.Permissions == null)
          {
              return NotFound();
          }
            var permissions = await _context.Permissions.FindAsync(id);

            if (permissions == null)
            {
                return NotFound();
            }

            return permissions;
        }

        // PUT: api/permissions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpermissions(int id, permissions permissions)
        {
            if (id != permissions.id)
            {
                return BadRequest();
            }

            _context.Entry(permissions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!permissionsExists(id))
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

        // POST: api/permissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<permissions>> Postpermissions(permissions permissions)
        {
          if (_context.Permissions == null)
          {
              return Problem("Entity set 'DataContext.Permissions'  is null.");
          }
            _context.Permissions.Add(permissions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpermissions", new { id = permissions.id }, permissions);
        }

        // DELETE: api/permissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepermissions(int id)
        {
            if (_context.Permissions == null)
            {
                return NotFound();
            }
            var permissions = await _context.Permissions.FindAsync(id);
            if (permissions == null)
            {
                return NotFound();
            }

            _context.Permissions.Remove(permissions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool permissionsExists(int id)
        {
            return (_context.Permissions?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
