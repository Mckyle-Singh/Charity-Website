using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoginSec.Areas.Identity.Data;
using LoginSec.Models;
using Microsoft.AspNetCore.Authorization;

namespace LoginSec.Controllers
{
    public class DisasterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DisasterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Disaster
        public async Task<IActionResult> Index()
        {
              return _context.Disasters != null ? 
                          View(await _context.Disasters.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Disasters'  is null.");
        }



        // GET: Disaster/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Disaster());
            else
                return View(_context.Disasters.Find(id));
        }



        // POST: Disaster/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("DisasterId,DisasterType,DisasterLocation,Description,RequiredAids,StartDate,EndDate")] Disaster disaster)
        {
            if (ModelState.IsValid)
            {
                if (disaster.DisasterId == 0)
                    _context.Add(disaster);
                else
                    _context.Update(disaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disaster);
        }




        // POST: Disaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Disasters == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Disasters'  is null.");
            }
            var disaster = await _context.Disasters.FindAsync(id);
            if (disaster != null)
            {
                _context.Disasters.Remove(disaster);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
