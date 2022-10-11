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




        // GET: PurchaseGoods/AddorEdit
        public IActionResult AddorEdit(int id = 0)
        {
            PopulateDisasters();
            if (id == 0)
                return View(new PurchaseGoods());
            else
                return View(_context.PurchaseGoods.Find(id));
        }




        // POST: PurchaseGoods/AddorEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("PurchaseId,ItemDescription,PurchaseAmount,Type,DisasterId,Date")] PurchaseGoods purchaseGoods)
        {
            if (ModelState.IsValid)
            {
                if (purchaseGoods.PurchaseId == 0)
                    _context.Add(purchaseGoods);
                else
                    _context.Update(purchaseGoods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDisasters();
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


        //Non Action method to bind data to dropdown list
        [NonAction]
        public void PopulateDisasters()
        {


            var DisasterCollection = _context.Disasters.ToList();
            // var DisasterCollection = _context.Disasters.Where(x => x.EndDate > DateTime.Today).ToList();

            Disaster DefaultDisaster = new Disaster()
            {
                DisasterId = 0,
                DisasterType = "Choose a Diaster"
            };

            DisasterCollection.Insert(0, DefaultDisaster);
            ViewBag.Disasters = DisasterCollection;
        }

    }
}
