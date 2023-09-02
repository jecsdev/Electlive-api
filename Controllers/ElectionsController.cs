using ElectLive_API.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectLive_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ElectionsController : Controller
    {   
        // Configuring dbcontext
        private readonly ApplicationDbContext _context;
        // Set class constructor
        public ElectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get elections
        [HttpGet]
        public async Task<IEnumerable<Election>> GetElections()
        {
            var elections = await _context.Elections.ToListAsync();
            return elections;
        } 
    }
}
