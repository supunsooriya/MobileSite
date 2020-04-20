using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileSite.Model;

namespace MobileSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileItemsController : ControllerBase
    {
        private readonly MobileItemContext _context;

        public MobileItemsController(MobileItemContext context)
        {
            _context = context;
        }

        // GET: api/MobileItems
        [HttpGet]
        public IEnumerable<MobileItem> GetMobileItem()
        {
            return _context.MobileItem;
        }

        // GET: api/MobileItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMobileItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mobileItem = await _context.MobileItem.FindAsync(id);

            if (mobileItem == null)
            {
                return NotFound();
            }

            return Ok(mobileItem);
        }

        // PUT: api/MobileItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMobileItem([FromRoute] int id, [FromBody] MobileItem mobileItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mobileItem.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(mobileItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MobileItemExists(id))
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

        // POST: api/MobileItems
        [HttpPost]
        public async Task<IActionResult> PostMobileItem([FromBody] MobileItem mobileItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MobileItem.Add(mobileItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMobileItem", new { id = mobileItem.ItemId }, mobileItem);
        }

        // DELETE: api/MobileItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMobileItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mobileItem = await _context.MobileItem.FindAsync(id);
            if (mobileItem == null)
            {
                return NotFound();
            }

            _context.MobileItem.Remove(mobileItem);
            await _context.SaveChangesAsync();

            return Ok(mobileItem);
        }

        private bool MobileItemExists(int id)
        {
            return _context.MobileItem.Any(e => e.ItemId == id);
        }
    }
}