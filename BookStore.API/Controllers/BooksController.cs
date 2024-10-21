using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.API.Data.Models;
using BookStore.API.Data.DTOs;
using BookStore.API.Data.DTOs.BookDTOs;
using BookStore.API.Data.Contexts;
using BookStore.API.Static;


namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly ILogger<BooksController> _logger;

        public BooksController(BookStoreDbContext context, ILogger<BooksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookListItemDTO>>> GetBooks()
        {
            _logger.LogInformation($"GET request made to {nameof(GetBooks)}");
            try
            {
                var books = await _context.Books.Include(q => q.Author).ToListAsync();
                var bookDTOs = books.Select(book => new BookListItemDTO
                {
                    Id = book.Id,
                    Title = book.Title,
                    Image = book.Image,
                    Price = book.Price,
                    AuthorId = book.Author?.Id,
                    AuthorName = book.Author?.FirstName

                }).ToList();
                return Ok(bookDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing GET in {nameof(GetBooks)}");
                return StatusCode(500, Messages.Error500Message);
            }
            
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {
            _logger.LogInformation($"GET request made to {nameof(GetBook)}");
            try
            {
                var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
                if (book == null)
                {
                    return NotFound();
                }

                var bookDto = new BookDTO
                {
                    Id = book.Id,
                    Title = book.Title,
                    Year = book.Year,
                    Isbn = book.Isbn,
                    Summary = book.Summary,
                    Image = book.Image,
                    Price = book.Price,
                };

                return bookDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing GET in {nameof(GetBook)}");
                return StatusCode(500, Messages.Error500Message);
            }
            
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookDTO bookDTO)
        {
            _logger.LogInformation($"PUT request made to {nameof(PutBook)}");
            if (id != bookDTO.Id)
            {
                _logger.LogWarning($"Update ID is invalid in {nameof(PutBook)} - ID: {id}");
                return BadRequest();
            }

            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                _logger.LogWarning($"{nameof(BookModel)} record not found in {nameof(PutBook)} - ID: {id}");
                return NotFound();
            }

            book.Title = bookDTO.Title;
            book.Year = bookDTO.Year;
            book.Isbn = bookDTO.Isbn;
            book.Summary = bookDTO.Summary;
            book.Image = bookDTO.Image;
            book.Price = bookDTO.Price;


            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ex, $"Error performing GET in {nameof(PutBook)}");
                    return StatusCode(500, Messages.Error500Message); ;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookDTO>> PostBook(BookDTO bookDTO)
        {
            _logger.LogInformation($"POST request made to {nameof(PostBook)}");
            try
            {
                var book = new BookModel
                {
                    Title = bookDTO.Title,
                    Year = bookDTO.Year,
                    Isbn = bookDTO.Isbn,
                    Summary = bookDTO.Summary,
                    Image = bookDTO.Image,
                    Price = bookDTO.Price,
                };

                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBook", new { id = book.Id }, book);
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing POST in {nameof(PostBook)} - {bookDTO}");
                return StatusCode(500, Messages.Error500Message);
            }
            
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            _logger.LogInformation($"DELETE request made to {nameof(DeleteBook)}");
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book == null)
                {
                    return NotFound();
                }

                _context.Books.Remove(book);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing DELETE in {nameof(DeleteBook)}");
                return StatusCode(500, Messages.Error500Message);
            }            
        }

        private async Task<bool> BookExists(int id)
        {
            return await _context.Books.AnyAsync(e => e.Id == id);
        }
    }
}
