using CoreBackend.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace CoreBackend.API.Controllers
{
    public class LuvviesController : ODataController
    {
        private readonly AppDbContext _context;
        public LuvviesController(AppDbContext context)
        {
            _context = context;
        }

        // odata/movies
        [EnableQuery(PageSize = 10)]
        public IActionResult Get()
        {
            return Ok(_context.Actresses.AsQueryable());
        }

        // odata/movies(2)
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_context.Actresses.Where(x => x.Id == key));
        }

        [HttpPost]
        public async Task<IActionResult> PostMovie([FromBody] Actress actress)
        {
            await _context.Actresses.AddAsync(actress);
            await _context.SaveChangesAsync();
            return Ok(actress);
        }

        // odata/movies(4)
        [HttpPut]
        public async Task<IActionResult> PutMovie([FromODataUri] int key, [FromBody] Actress actress)
        {
            actress.Id = key;
            _context.Entry(actress).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(actress);
        }

        // odata/movies(3)
        [HttpDelete]
        public async Task<IActionResult> DeleteMovie([FromODataUri] int key)
        {
            var actress = await _context.Actresses.FindAsync(key);
            if (actress == null)
                return NotFound();

            _context.Actresses.Remove(actress);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
