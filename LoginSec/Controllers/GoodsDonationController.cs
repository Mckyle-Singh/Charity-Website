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
    public class GoodsDonationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoodsDonationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: GoodsDonation
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GoodsDonations.Include(g => g.Category);
            return View(await applicationDbContext.ToListAsync());
        }



        // GET: GoodsDonation/AddOrEdit
        public IActionResult AddOrEdit(int id=0)
        {
            PopulateCategories();
            if (id == 0)
                return View(new GoodsDonation());
            else
                return View(_context.GoodsDonations.Find(id));
        }


        // POST: GoodsDonation/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("GoodsId,CategoryId,NumItems,Name,ItemDescription,Date")] GoodsDonation goodsDonation)
        {
            if (ModelState.IsValid)
            {
                if (goodsDonation.GoodsId == 0)
                    _context.Add(goodsDonation);
                else
                    _context.Update(goodsDonation);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(AddOrEdit));
            }
            PopulateCategories();
            return View(goodsDonation);
        }


     
        // POST: GoodsDonation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GoodsDonations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GoodsDonations'  is null.");
            }
            var goodsDonation = await _context.GoodsDonations.FindAsync(id);
            if (goodsDonation != null)
            {
                _context.GoodsDonations.Remove(goodsDonation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        //Non Action method to bind data to dropdown list
        [NonAction]
        public void PopulateCategories()
        {
            var CategoryCollection = _context.Categories.ToList();
            Category DefaultCategory = new Category()
            {
                CategoryId = 0,
                Title = "Choose category"
            };

            CategoryCollection.Insert(0, DefaultCategory);
            ViewBag.Categories = CategoryCollection;
        }

    }
}
