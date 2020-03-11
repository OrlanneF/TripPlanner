using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UITripPlanner.Data;
using UITripPlanner.Models;
using Microsoft.AspNetCore.Identity;

namespace UITripPlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoyagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public VoyagesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Voyages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voyage>>> GetVoyage()
        {
            return await _context.Voyage.ToListAsync();
        }

        // GET: api/Voyages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voyage>> GetVoyage(string id)
        {
            var voyage = await _context.Voyage.FindAsync(id);
                //.Include(voyage => voyage.MyUser);

            if (voyage == null)
            {
                return NotFound();
            }

            return voyage;
        }

        // PUT: api/Voyages/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoyage(string id, Voyage voyage)
        {
            if (id != voyage.Id)
            {
                return BadRequest();
            }

            _context.Entry(voyage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoyageExists(id))
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

        // POST: api/Voyages
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Voyage>> PostVoyage(Voyage voyage)
        {
            ApplicationUser connectedUser = await _userManager.GetUserAsync(User);

            voyage.MyUser = connectedUser;

            _context.Voyage.Add(voyage);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VoyageExists(voyage.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVoyage", new { id = voyage.Id }, voyage);
        }

        // DELETE: api/Voyages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Voyage>> DeleteVoyage(string id)
        {
            var voyage = await _context.Voyage.FindAsync(id);
            if (voyage == null)
            {
                return NotFound();
            }

            _context.Voyage.Remove(voyage);
            await _context.SaveChangesAsync();

            return voyage;
        }

        private bool VoyageExists(string id)
        {
            return _context.Voyage.Any(e => e.Id == id);
        }
    }
}
