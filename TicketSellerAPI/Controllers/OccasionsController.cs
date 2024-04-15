using Microsoft.AspNetCore.Mvc;
using TicketSellerAPI.Data;
using TicketSellerAPI.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TicketSellerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccasionsController : ControllerBase
    {
        private readonly TicketSellerContext _context;

        public OccasionsController(TicketSellerContext context)
        {
            _context = context;
        }

        // GET: api/Occasions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Occasion>>> GetAll()
        {
            return await _context.Occasions.ToListAsync();
        }

        // GET: api/Occasions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Occasion>> Get(int id)
        {
            var occasion = await _context.Occasions.FindAsync(id);
            if (occasion == null)
            {
                return NotFound();
            }
            return occasion;
        }

        // POST: api/Occasions
        [HttpPost]
        public async Task<ActionResult<Occasion>> Post(Occasion occasion)
        {
            _context.Occasions.Add(occasion);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = occasion.Id }, occasion);
        }

        // Other CRUD actions (PUT for update, DELETE, etc.) go here...
    }
}