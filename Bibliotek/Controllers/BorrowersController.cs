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
    public class BorrowersController : Controller
    {
        private readonly LibraryContext _context;

        public BorrowersController(LibraryContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Borrower>>> GetBorrowers()
        {
            return await _context.Borrowers.ToListAsync();
        }

        // GET
        public async Task<ActionResult<Borrower>> GetBorrower(int id)
        {
            var borrower = await _context.Borrowers.FindAsync(id);

            if (borrower == null)
            {
                return NotFound();
            }

            return borrower;
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBorrower(int id, Borrower borrower)
        {
            if (id != borrower.Card)
            {
                return BadRequest();
            }

            _context.Entry(borrower).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowerExists(id))
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
        public async Task<ActionResult<Borrower>> PostBorrower(Borrower borrower)
        {
            _context.Borrowers.Add(borrower);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBorrower", new { id = borrower.Card }, borrower);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<Borrower>> DeleteBorrower(int id)
        {
            var borrower = await _context.Borrowers.FindAsync(id);
            if (borrower == null)
            {
                return NotFound();
            }

            _context.Borrowers.Remove(borrower);
            await _context.SaveChangesAsync();

            return borrower;
        }

        // POST
        [HttpPost("{borrowerId}/borrowBook/{publicationId}")]
        public async Task<ActionResult<Borrower>> BorrowBook(int borrowerId, int publicationId)
        {
            var borrower = await _context.Borrowers.SingleOrDefaultAsync(b => b.Card == borrowerId);
            
            if (borrower == null)
            {
                return BadRequest("Borrower does not exist!");
            }

            var books = await _context.Books.Include(i => i.Publication)
                .Include(i => i.Rents)
                .Where(i => i.PublicationId == publicationId)
                .ToListAsync();

            var availableBooks = books.FirstOrDefault(i => !i.Rented);

            if (availableBooks == null)
            {
                return BadRequest("Book does not exist in library");
            }

            var rent = new Rent()
            {
                LibraryKard = borrowerId,
                BookId = availableBooks.BookId,
                RentDate = DateTime.Now,
                Returned = false
            };

            _context.Rents.Add(rent);
            if (borrower.Rents == null)
            {
                borrower.Rents = new List<Rent>();
            }
            borrower.Rents.Add(rent);
            await _context.SaveChangesAsync();

            return Ok($"Borrower {borrower.FirstName} loaned {availableBooks.Publication.Title} at {rent.RentDate}");
        }

        // POST
        [HttpPost("{borrowerId}/returnBook/{publicationId}")]
        public async Task<ActionResult<Borrower>> ReturnBook(int borrowerId, int publicationId)
        {
            var borrower = await _context.Borrowers.Include(b => b.Rents).ThenInclude(r => r.Book).ThenInclude(i => i.Publication).SingleOrDefaultAsync(b => b.Card == borrowerId);

            if(borrower == null)
            {
                return BadRequest("Borrower does not exist!");
            }

            if (borrower.Rents == null || borrower.Rents.Count == 0)
            {
                return BadRequest("Borrower does not have any loans!");
            }

            var rent = borrower.Rents.FirstOrDefault(b => b.Book.Publication.PublicationId == publicationId && !b.Returned);

            if (rent == null)
            {
                return BadRequest("Borrower has not loaned this book!");
            }
            _context.Entry(rent).State = EntityState.Modified;
            rent.Returned = true;

            await _context.SaveChangesAsync();

            return Ok($"Borrower {borrower.FirstName} returned the book {rent.Book.Publication.Title} at {rent.ReturnDate}");
        }

        private bool BorrowerExists(int id)
        {
            return _context.Borrowers.Any(e => e.Card == id);
        }
    }
}
