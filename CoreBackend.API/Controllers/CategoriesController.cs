using CoreBackend.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace CoreBackend.API.Controllers
{
    [Authorize]
    public class CategoriesController : ODataController
    {
        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // odata/categories
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_context.Categories.AsQueryable());
        }
    }
}
