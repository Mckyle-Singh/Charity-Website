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
    public class Good_AllocationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Good_AllocationsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]

        // GET: Good_Allocations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Good_Allocations.Include(s=>s.GoodsDonation)
                .Include(g => g.Disaster);
            return View(await applicationDbContext.ToListAsync());
        }




        // GET: Good_Allocations/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            PopulateDisasters();
            PopulateGoods();
            if (id == 0)
                return View(new Good_Allocation());
            else
                return View(_context.Good_Allocations.Find(id));
        }
         


        // POST: Good_Allocations/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("GoodsAllocationId,GoodsId,DisasterId,NumItems,Date")] Good_Allocation good_Allocation)
        {
            if(ModelState.IsValid)
            {
                if (good_Allocation.GoodsAllocationId == 0)
                    _context.Add(good_Allocation);
                else
                    _context.Update(good_Allocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateDisasters();
            PopulateGoods();
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

       


        //Non Action method to bind disaster data to dropdown list
        [NonAction]
        public void PopulateDisasters()
        {


            //var DisasterCollection = _context.Disasters.ToList();
            var DisasterCollection = _context.Disasters.Where(x => x.EndDate > DateTime.Today && x.StartDate <=DateTime.Today).ToList();

            Disaster DefaultDisaster = new Disaster()
            {
                DisasterId = 0,
                DisasterType = "Choose a Disaster"
            };

            DisasterCollection.Insert(0, DefaultDisaster);
            ViewBag.Disasters = DisasterCollection;
        }



        //Non Action method to bind GoodsDonation data to dropdown list
        [NonAction]
        public void PopulateGoods()
        {


            //var DisasterCollection = _context.Disasters.ToList();
            var GoodsCollection = _context.GoodsDonations.ToList();

            GoodsDonation DefaultGoodsType = new GoodsDonation()
            {
                GoodsId = 0,
                ItemDescription = "Choose the Type of goods"
            };

            GoodsCollection.Insert(0, DefaultGoodsType);
            ViewBag.GoodsToAllocate = GoodsCollection;
        }
    }
}


//Build an Expense Tracker with Asp.Net Core MVC. 2022. YouTube video, added by CodeAffection. [Online]. Available at: 
//https://youtu.be/zQ5eijfpuu8 [Accessed 10 October 2022]