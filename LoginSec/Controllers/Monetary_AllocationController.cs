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
    public class Monetary_AllocationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Monetary_AllocationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Monetary_Allocation
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Monetary_Allocations.Include(m => m.Disaster);
            return View(await applicationDbContext.ToListAsync());
        }



        // GET: Monetary_Allocation/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            PopulateDisasters();
            if (id == 0)
                return View(new Monetary_Allocation());
            else
                return View(_context.Monetary_Allocations.Find(id));
        }


        // POST: Monetary_Allocation/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("MonetaryId,DisasterId,Amount")] Monetary_Allocation monetary_Allocation)
        {
            if (ModelState.IsValid)
            {
                if (monetary_Allocation.MonetaryId == 0)
                    _context.Add(monetary_Allocation);
                else
                    _context.Update(monetary_Allocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDisasters();
            return View(monetary_Allocation);
        }




        // POST: Monetary_Allocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Monetary_Allocations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Monetary_Allocations'  is null.");
            }
            var monetary_Allocation = await _context.Monetary_Allocations.FindAsync(id);
            if (monetary_Allocation != null)
            {
                _context.Monetary_Allocations.Remove(monetary_Allocation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        //Non Action method to bind disaster data to dropdown list
        [NonAction]
        public void PopulateDisasters()
        {


            //var DisasterCollection = _context.Disasters.ToList();
            var DisasterCollection = _context.Disasters.Where(x => x.EndDate > DateTime.Today).ToList();

            Disaster DefaultDisaster = new Disaster()
            {
                DisasterId = 0,
                DisasterType = "Choose a Disaster"
            };

            DisasterCollection.Insert(0, DefaultDisaster);
            ViewBag.Disasters = DisasterCollection;
        }
    }
}
