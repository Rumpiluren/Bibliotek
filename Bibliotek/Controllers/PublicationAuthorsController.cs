using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bibliotek.Data;
using Bibliotek.Models;

namespace Bibliotek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationAuthorsController : Controller
    {
        private readonly LibraryContext _context;

        public PublicationAuthorsController(LibraryContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicationAuthor>>> GetPublicationAuthors()
        {
            return await _context.BookAuthors.ToListAsync();
        }

        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicationAuthor>> GetPublicationAuthor(int id)
        {
            var bookAuthor = await _context.BookAuthors.FindAsync(id);

            if (bookAuthor == null)
            {
                return NotFound();
            }

            return bookAuthor;
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicationAuthor(int id, PublicationAuthor publicationAuthor)
        {
            if (id != publicationAuthor.PublicationId)
            {
                return BadRequest();
            }

            _context.Entry(publicationAuthor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicationAuthorExists(id))
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

        // POST
        [HttpPost]
        public async Task<ActionResult<PublicationAuthor>> PostPublicationAuthor(PublicationAuthor publicationAuthor)
        {
            _context.BookAuthors.Add(publicationAuthor);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (PublicationAuthorExists(publicationAuthor.PublicationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPublicationAuthor", new { id = publicationAuthor.PublicationId }, publicationAuthor);

        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicationAuthor>> DeletePublicationAuthor(int id)
        {
            var publicationAuthor = await _context.BookAuthors.FindAsync(id);

            if (publicationAuthor == null)
            {
                return NotFound();
            }

            _context.BookAuthors.Remove(publicationAuthor);
            await _context.SaveChangesAsync();

            return publicationAuthor;
        }

        private bool PublicationAuthorExists(int id)
        {
            return _context.BookAuthors.Any(e => e.PublicationId == id);
        }
    }
}
