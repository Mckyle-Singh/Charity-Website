using LoginSec.Areas.Identity.Data;
using LoginSec.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginSec.Controllers
{
    public class StatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            List<MonetaryDonation> SelectedDonations = await _context.MonetaryDonations
             .Include(x => x.Category)
             .ToListAsync();

            List<GoodsDonation> SelectedGoodDonations = await _context.GoodsDonations
              .Include(x => x.Category)
              .ToListAsync();

            List<Disaster> SelectedDisasters = await _context.Disasters.Where(x => x.EndDate > DateTime.Today && x.StartDate <= DateTime.Today)
              .ToListAsync();



            //Total Income(Donations)
            int TotalIncome = SelectedDonations
                .Where(i => i.Category.Title == "Money")
                .Sum(j => j.Amount);
            ViewBag.TotalIncome = TotalIncome.ToString("C0");


            //Total Number of Goods(Donations)
            int TotalGoods = SelectedGoodDonations
                .Where(i => i.Category.Title != "Money")
                .Sum(j => j.NumItems);
            ViewBag.TotalGoods = TotalGoods.ToString();

            //Total Number of Disasters(Active)
            int TotalDisasters = SelectedDisasters
                .Count();
            ViewBag.TotalDisasters = TotalDisasters.ToString();

            return View();
        }
    }
}
