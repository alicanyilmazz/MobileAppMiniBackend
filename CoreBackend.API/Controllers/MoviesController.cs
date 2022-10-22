using CoreBackend.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace CoreBackend.API.Controllers
{
    [Authorize]
    public class MoviesController : ODataController
    {
        private readonly AppDbContext _context;
        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        // odata/movies
        [EnableQuery(PageSize = 10)]
        public IActionResult Get()
        {
            return Ok(_context.Movies.AsQueryable());
        }

        // odata/movies(2)
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_context.Movies.Where(x => x.Id == key));
        }

        [HttpPost]
        public async Task<IActionResult> PostMovie([FromBody] Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return Ok(movie);
        }

        // odata/movies(4)
        [HttpPut]
        public async Task<IActionResult> PutMovie([FromODataUri] int key, [FromBody] Movie movie)
        {
            movie.Id = key;
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(movie);
        }

        // odata/movies(3)
        [HttpDelete]
        public async Task<IActionResult> DeleteMovie([FromODataUri] int key)
        {
            var movie = await _context.Movies.FindAsync(key);
            if (movie == null)
                return NotFound();
            
            _context.Movies.Remove(movie);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
