using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingsController : ControllerBase
    {
        private readonly ModelContext _context;

        public AccountingsController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Accountings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accounting>>> GetAccountings()
        {
            return await _context.Accountings.ToListAsync();
        }

        // GET: api/Accountings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accounting>> GetAccounting(int id)
        {
            var accounting = await _context.Accountings.FindAsync(id);

            if (accounting == null)
            {
                return NotFound();
            }

            return accounting;
        }

        // PUT: api/Accountings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccounting(int id, Accounting accounting)
        {
            if (id != accounting.AccountingId)
            {
                return BadRequest();
            }

            _context.Entry(accounting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountingExists(id))
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

        // POST: api/Accountings
        [HttpPost]
        public async Task<ActionResult<Accounting>> PostAccounting(Accounting accounting)
        {
            _context.Accountings.Add(accounting);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAccounting", new { id = accounting.AccountingId }, accounting);
        }

        // DELETE: api/Accountings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Accounting>> DeleteAccounting(int id)
        {
            var accounting = await _context.Accountings.FindAsync(id);
            if (accounting == null)
            {
                return NotFound();
            }

            _context.Accountings.Remove(accounting);
            await _context.SaveChangesAsync();

            return accounting;
        }
        //POST: api/Accountings/report
        [HttpPost("report")]
        public async Task<ActionResult<IEnumerable<GroupedReport>>> GetReport(Question question)
        {
            if (question.DateTimeStart == null || question.DateTimeEnd == null)
                return BadRequest();

            return _context.Accountings.AsEnumerable()
                       .Where(a => a.Date >= question.DateTimeStart && a.Date <= question.DateTimeEnd)
                       .GroupBy(a => new { C = question.GroupByCategoryId ? a.CategoryId : -1,
                                           M = question.GroupByMonthNum ? a.Date.Month : -1
                                         })
                       .Select(g => new GroupedReport(g.Key.C.ToString(), g.Key.M.ToString(), g.ToList())).ToList();
        }

        private bool AccountingExists(int id)
        {
            return _context.Accountings.Any(e => e.AccountingId == id);
        }
        
    }
}
