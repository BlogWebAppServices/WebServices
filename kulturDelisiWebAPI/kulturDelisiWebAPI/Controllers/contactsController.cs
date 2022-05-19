using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kulturDelisiWebAPI.Data;
using kulturDelisiWebAPI.Models.contactModel;

namespace kulturDelisiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class contactsController : ControllerBase
    {
        private readonly DataContext _context;

        public contactsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<contact>>> GetContacts()
        {
          if (_context.Contacts == null)
          {
              return NotFound();
          }
            return await _context.Contacts.ToListAsync();
        }

        // GET: api/contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<contact>> Getcontact(int id)
        {
          if (_context.Contacts == null)
          {
              return NotFound();
          }
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // PUT: api/contacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcontact(int id, contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!contactExists(id))
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

        // POST: api/contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<contact>> Postcontact(contact contact)
        {
          if (_context.Contacts == null)
          {
              return Problem("Entity set 'DataContext.Contacts'  is null.");
          }
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcontact", new { id = contact.Id }, contact);
        }

        // DELETE: api/contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecontact(int id)
        {
            if (_context.Contacts == null)
            {
                return NotFound();
            }
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool contactExists(int id)
        {
            return (_context.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
