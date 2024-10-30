using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using BookStore.API.Static;
using BookStore.API.Data.DTOs;
using BookStore.API.Data.Models;
using BookStore.API.Data.Contexts;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(BookStoreDbContext context, ILogger<AuthorsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
        {
            _logger.LogInformation($"GET request made to {nameof(GetAuthors)}");
            try
            {
                var authors = await _context.Authors.ToListAsync();
                var authorsDTO = authors.Select(a => new AuthorDTO
                {
                    Id = a.Id,
                    FirstName = a.FirstName ?? string.Empty,
                    LastName = a.LastName ?? string.Empty,
                    Bio = a.Bio ?? string.Empty
                }).ToList();
                return Ok(authorsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing GET in {nameof(GetAuthors)}");
                return StatusCode(500, Messages.Error500Message);
            }
            
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthor(int id)
        {
            _logger.LogInformation($"GET request made to {nameof(GetAuthor)}");
            try
            {
                var author = await _context.Authors
                    .Include(q => q.Books)
                    .FirstOrDefaultAsync(q => q.Id == id);
                if (author == null)
                {
                    _logger.LogWarning($"Record not found: {nameof(GetAuthor)} - ID: {id}");
                    return NotFound();
                }

                var authorDTO = new AuthorDTO
                {
                    Id = author.Id,
                    FirstName = author.FirstName ?? string.Empty,
                    LastName = author.LastName ?? string.Empty,
                    Bio = author.Bio ?? string.Empty,
                    Books = author.Books.Select(book => new BookListItemDTO
                    {
                        Id = book.Id,
                        Title = book.Title ?? string.Empty,
                        Image = book.Image ?? string.Empty,
                        Price = book.Price

                    }).ToList(),
                };

                return Ok(authorDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing GET in {nameof(GetAuthor)}");
                return StatusCode(500, Messages.Error500Message);
            }
            
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PutAuthor(int id, AuthorDTO authorDTO)
        {
            _logger.LogInformation($"PUT request made to {nameof(PutAuthor)}");
            if (id != authorDTO.Id)
            {
                _logger.LogWarning($"Update ID is invalid in {nameof(PutAuthor)} - ID: {id}");
                return BadRequest();
            }

            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                _logger.LogWarning($"{nameof(AuthorModel)} record not found in {nameof(PutAuthor)} - ID: {id}");
                return NotFound();
            }

            author.FirstName = authorDTO.FirstName ?? string.Empty;
            author.LastName = authorDTO.LastName ?? string.Empty;
            author.Bio = authorDTO.Bio ?? string.Empty;
            author.Books = null;
            

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ex, $"Error performing GET in {nameof(PutAuthor)}");
                    return StatusCode(500, Messages.Error500Message);
                }
            }

            return NoContent();
        }

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<AuthorDTO>> PostAuthor(AuthorDTO authorDTO)
        {
            _logger.LogInformation($"POST request made to {nameof(PostAuthor)}");
            try
            {
                var author = new AuthorModel
                {
                    FirstName = authorDTO.FirstName,
                    LastName = authorDTO.LastName,
                    Bio = authorDTO.Bio,
                    Books = null
                };
                await _context.Authors.AddAsync(author);
                await _context.SaveChangesAsync();

                return Ok(CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing POST in {nameof(PostAuthor)} - {authorDTO}");
                return StatusCode(500, Messages.Error500Message);
            }
            
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            _logger.LogInformation($"DELETE request made to {nameof(DeleteAuthor)}");
            try
            {
                var author = await _context.Authors.FindAsync(id);
                if (author == null)
                {
                    return NotFound();
                }

                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, $"Error performing DELETE in {nameof(DeleteAuthor)}");
                return StatusCode(500, Messages.Error500Message);
            }            
        }

        private async Task<bool> AuthorExists(int id)
        {
            return await _context.Authors.AnyAsync(e => e.Id == id);
        }
    }
}
