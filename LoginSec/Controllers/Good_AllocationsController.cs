 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoginSec.Areas.Identity.Data;
using LoginSec.Models;

namespace LoginSec.Controllers
{
    public class Good_AllocationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Good_AllocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Good_Allocations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Good_Allocations.Include(g => g.Disaster);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Good_Allocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Good_Allocations == null)
            {
                return NotFound();
            }

            var good_Allocation = await _context.Good_Allocations
                .Include(g => g.Disaster)
                .FirstOrDefaultAsync(m => m.GoodsAllocationId == id);
            if (good_Allocation == null)
            {
                return NotFound();
            }

            return View(good_Allocation);
        }

        // GET: Good_Allocations/Create
        public IActionResult Create()
        {
            ViewData["DisasterId"] = new SelectList(_context.Disasters, "DisasterId", "DisasterId");
            return View();
        }

        // POST: Good_Allocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GoodsAllocationId,GoodsId,DisasterId,NumItems,Date")] Good_Allocation good_Allocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(good_Allocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisasterId"] = new SelectList(_context.Disasters, "DisasterId", "DisasterId", good_Allocation.DisasterId);
            return View(good_Allocation);
        }

        // GET: Good_Allocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Good_Allocations == null)
            {
                return NotFound();
            }

            var good_Allocation = await _context.Good_Allocations.FindAsync(id);
            if (good_Allocation == null)
            {
                return NotFound();
            }
            ViewData["DisasterId"] = new SelectList(_context.Disasters, "DisasterId", "DisasterId", good_Allocation.DisasterId);
            return View(good_Allocation);
        }

        // POST: Good_Allocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GoodsAllocationId,GoodsId,DisasterId,NumItems,Date")] Good_Allocation good_Allocation)
        {
            if (id != good_Allocation.GoodsAllocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(good_Allocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Good_AllocationExists(good_Allocation.GoodsAllocationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisasterId"] = new SelectList(_context.Disasters, "DisasterId", "DisasterId", good_Allocation.DisasterId);
            return View(good_Allocation);
        }

        // GET: Good_Allocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Good_Allocations == null)
            {
                return NotFound();
            }

            var good_Allocation = await _context.Good_Allocations
                .Include(g => g.Disaster)
                .FirstOrDefaultAsync(m => m.GoodsAllocationId == id);
            if (good_Allocation == null)
            {
                return NotFound();
            }

            return View(good_Allocation);
        }

        // POST: Good_Allocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Good_Allocations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Good_Allocations'  is null.");
            }
            var good_Allocation = await _context.Good_Allocations.FindAsync(id);
            if (good_Allocation != null)
            {
                _context.Good_Allocations.Remove(good_Allocation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Good_AllocationExists(int id)
        {
          return _context.Good_Allocations.Any(e => e.GoodsAllocationId == id);
        }
    }
}
