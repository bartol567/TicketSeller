using Microsoft.AspNetCore.Mvc;
using TicketSellerAPI.Data;
using TicketSellerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketSellerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccasionCategoriesController : ControllerBase
    {
        private readonly TicketSellerContext _context;

        public OccasionCategoriesController(TicketSellerContext context)
        {
            _context = context;
        }

        // GET: api/OccasionCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OccasionCategory>>> GetOccasionCategories()
        {
            return await _context.OccasionCategories.ToListAsync();
        }

        // GET: api/OccasionCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OccasionCategory>> GetOccasionCategory(int id)
        {
            var occasionCategory = await _context.OccasionCategories.FindAsync(id);

            if (occasionCategory == null)
            {
                return NotFound();
            }

            return occasionCategory;
        }

        // POST: api/OccasionCategories
        [HttpPost]
        public async Task<ActionResult<OccasionCategory>> PostOccasionCategory(OccasionCategory occasionCategory)
        {
            _context.OccasionCategories.Add(occasionCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOccasionCategory), new { id = occasionCategory.Id }, occasionCategory);
        }

        // PUT: api/OccasionCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOccasionCategory(int id, OccasionCategory occasionCategory)
        {
            if (id != occasionCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(occasionCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OccasionCategoryExists(id))
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

        // DELETE: api/OccasionCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOccasionCategory(int id)
        {
            var occasionCategory = await _context.OccasionCategories.FindAsync(id);
            if (occasionCategory == null)
            {
                return NotFound();
            }

            _context.OccasionCategories.Remove(occasionCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OccasionCategoryExists(int id)
        {
            return _context.OccasionCategories.Any(e => e.Id == id);
        }
    }
}