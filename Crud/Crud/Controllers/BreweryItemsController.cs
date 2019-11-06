using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crud.Models;

namespace Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweryItemsController : ControllerBase
    {
        private readonly DataContext _context;

        public BreweryItemsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BreweryItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BreweryItem>>> GetBreweryItems()
        {
            return await _context.BreweryItems.ToListAsync();
        }

        // GET: api/BreweryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BreweryItem>> GetBreweryItem(long id)
        {
            var breweryItem = await _context.BreweryItems.FindAsync(id);

            if (breweryItem == null)
            {
                return NotFound();
            }

            return breweryItem;
        }

        // PUT: api/BreweryItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBreweryItem(long id, BreweryItem breweryItem)
        {
            if (id != breweryItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(breweryItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreweryItemExists(id))
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

        // POST: api/BreweryItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BreweryItem>> PostBreweryItem(BreweryItem breweryItem)
        {
            _context.BreweryItems.Add(breweryItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBreweryItem", new { id = breweryItem.Id }, breweryItem);
        }

        // DELETE: api/BreweryItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BreweryItem>> DeleteBreweryItem(long id)
        {
            var breweryItem = await _context.BreweryItems.FindAsync(id);
            if (breweryItem == null)
            {
                return NotFound();
            }

            _context.BreweryItems.Remove(breweryItem);
            await _context.SaveChangesAsync();

            return breweryItem;
        }

        private bool BreweryItemExists(long id)
        {
            return _context.BreweryItems.Any(e => e.Id == id);
        }
    }
}
