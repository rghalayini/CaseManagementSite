using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaseManagementAPI.Models;

namespace CaseManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseWorkersController : ControllerBase
    {
        private readonly ApiContext _context;

        public CaseWorkersController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/CaseWorkers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseWorker>>> GetCaseWorkers()
        {
            return await _context.CaseWorkers.ToListAsync();
        }

        // GET: api/CaseWorkers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseWorker>> GetCaseWorker(int id)
        {
            var caseWorker = await _context.CaseWorkers.FindAsync(id);

            if (caseWorker == null)
            {
                return NotFound();
            }

            return caseWorker;
        }

        // PUT: api/CaseWorkers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseWorker(int id, CaseWorker caseWorker)
        {
            if (id != caseWorker.Id)
            {
                return BadRequest();
            }

            _context.Entry(caseWorker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseWorkerExists(id))
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

        // POST: api/CaseWorkers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CaseWorker>> PostCaseWorker(CaseWorker caseWorker)
        {
            _context.CaseWorkers.Add(caseWorker);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CaseWorkerExists(caseWorker.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCaseWorker", new { id = caseWorker.Id }, caseWorker);
        }

        // DELETE: api/CaseWorkers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CaseWorker>> DeleteCaseWorker(int id)
        {
            var caseWorker = await _context.CaseWorkers.FindAsync(id);
            if (caseWorker == null)
            {
                return NotFound();
            }

            _context.CaseWorkers.Remove(caseWorker);
            await _context.SaveChangesAsync();

            return caseWorker;
        }

        private bool CaseWorkerExists(int id)
        {
            return _context.CaseWorkers.Any(e => e.Id == id);
        }
    }
}
