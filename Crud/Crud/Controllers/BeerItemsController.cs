using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crud.Models;

namespace Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerItemsController : ControllerBase
    {
        private readonly BeerContext _context;

        public BeerItemsController(BeerContext context)
        {
            _context = context;
        }

        // GET: api/BeerItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeerItem>>> GetBeerItems()
        {
            return await _context.BeerItems.ToListAsync();
        }

        // GET: api/BeerItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BeerItem>> GetBeerItem(long id)
        {
            var beerItem = await _context.BeerItems.FindAsync(id);

            if (beerItem == null)
            {
                return NotFound();
            }

            return beerItem;
        }

        // PUT: api/BeerItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeerItem(long id, BeerItem beerItem)
        {
            if (id != beerItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(beerItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeerItemExists(id))
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

        // POST: api/BeerItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BeerItem>> PostBeerItem(BeerItem beerItem)
        {
            _context.BeerItems.Add(beerItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeerItem", new { id = beerItem.Id }, beerItem);
        }

        // DELETE: api/BeerItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BeerItem>> DeleteBeerItem(long id)
        {
            var beerItem = await _context.BeerItems.FindAsync(id);
            if (beerItem == null)
            {
                return NotFound();
            }

            _context.BeerItems.Remove(beerItem);
            await _context.SaveChangesAsync();

            return beerItem;
        }

        private bool BeerItemExists(long id)
        {
            return _context.BeerItems.Any(e => e.Id == id);
        }
    }
}
