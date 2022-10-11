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
    public class PurchaseGoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseGoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseGoods
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PurchaseGoods.Include(p => p.Disaster);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PurchaseGoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PurchaseGoods == null)
            {
                return NotFound();
            }

            var purchaseGoods = await _context.PurchaseGoods
                .Include(p => p.Disaster)
                .FirstOrDefaultAsync(m => m.PurchaseId == id);
            if (purchaseGoods == null)
            {
                return NotFound();
            }

            return View(purchaseGoods);
        }

        // GET: PurchaseGoods/Create
        public IActionResult Create()
        {
            ViewData["DisasterId"] = new SelectList(_context.Disasters, "DisasterId", "DisasterId");
            return View();
        }

        // POST: PurchaseGoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseId,ItemDescription,PurchaseAmount,Type,DisasterId,Date")] PurchaseGoods purchaseGoods)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseGoods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisasterId"] = new SelectList(_context.Disasters, "DisasterId", "DisasterId", purchaseGoods.DisasterId);
            return View(purchaseGoods);
        }

        // GET: PurchaseGoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PurchaseGoods == null)
            {
                return NotFound();
            }

            var purchaseGoods = await _context.PurchaseGoods.FindAsync(id);
            if (purchaseGoods == null)
            {
                return NotFound();
            }
            ViewData["DisasterId"] = new SelectList(_context.Disasters, "DisasterId", "DisasterId", purchaseGoods.DisasterId);
            return View(purchaseGoods);
        }

        // POST: PurchaseGoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseId,ItemDescription,PurchaseAmount,Type,DisasterId,Date")] PurchaseGoods purchaseGoods)
        {
            if (id != purchaseGoods.PurchaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseGoods);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseGoodsExists(purchaseGoods.PurchaseId))
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
            ViewData["DisasterId"] = new SelectList(_context.Disasters, "DisasterId", "DisasterId", purchaseGoods.DisasterId);
            return View(purchaseGoods);
        }

        // GET: PurchaseGoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PurchaseGoods == null)
            {
                return NotFound();
            }

            var purchaseGoods = await _context.PurchaseGoods
                .Include(p => p.Disaster)
                .FirstOrDefaultAsync(m => m.PurchaseId == id);
            if (purchaseGoods == null)
            {
                return NotFound();
            }

            return View(purchaseGoods);
        }

        // POST: PurchaseGoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PurchaseGoods == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PurchaseGoods'  is null.");
            }
            var purchaseGoods = await _context.PurchaseGoods.FindAsync(id);
            if (purchaseGoods != null)
            {
                _context.PurchaseGoods.Remove(purchaseGoods);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseGoodsExists(int id)
        {
          return _context.PurchaseGoods.Any(e => e.PurchaseId == id);
        }
    }
}
