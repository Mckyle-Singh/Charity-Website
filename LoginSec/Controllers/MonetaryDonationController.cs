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
    public class MonetaryDonationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonetaryDonationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]

        // GET: MonetaryDonation
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MonetaryDonations.Include(m => m.Category);
            return View(await applicationDbContext.ToListAsync());
        }



        // GET: MonetaryDonation/AddOrEdit
        public IActionResult AddOrEdit(int id=0)
        {
            PopulateCategories();
            if (id == 0)
                return View(new MonetaryDonation());
            else
                return View(_context.MonetaryDonations.Find(id));
        }



        // POST: MonetaryDonation/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("MonetaryId,CategoryId,Amount,Name,Date")] MonetaryDonation monetaryDonation)
        {
            if (ModelState.IsValid)
            {
                if (monetaryDonation.MonetaryId == 0)
                    _context.Add(monetaryDonation);
                else
                _context.Update(monetaryDonation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AddOrEdit));
            }
            PopulateCategories();
            return View(monetaryDonation);
        }




        // POST: MonetaryDonation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MonetaryDonations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MonetaryDonations'  is null.");
            }
            var monetaryDonation = await _context.MonetaryDonations.FindAsync(id);
            if (monetaryDonation != null)
            {
                _context.MonetaryDonations.Remove(monetaryDonation);
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
