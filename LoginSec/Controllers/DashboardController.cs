﻿using LoginSec.Areas.Identity.Data;
using LoginSec.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace LoginSec.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]

        public async Task<ActionResult> Index()
        {

            //Last 7 days Monetary Donations
            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;

            List<MonetaryDonation> SelectedDonations = await _context.MonetaryDonations
              .Include(x => x.Category)
              .ToListAsync();

            List<PurchaseGoods> SelectedExpenses = await _context.PurchaseGoods
              .ToListAsync();


            //Total Income(Donations)
            int TotalIncome = SelectedDonations
                .Where(i => i.Category.Title == "Money")
                .Sum(j => j.Amount);
            ViewBag.TotalIncome = TotalIncome.ToString("C0");


            //Total Expense(Allocatiing donations to disaster )

            int TotalExpense = SelectedExpenses
                .Where(i => i.Type == "Expense")
                .Sum(j => j.PurchaseAmount);
            ViewBag.TotalExpense = TotalExpense.ToString("C0");


            //Balancee(Balence after Allocatiing donations to disaster )
            int Balance = TotalIncome - TotalExpense;

            //sets negative balance
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            culture.NumberFormat.CurrencyNegativePattern = 1;
            ViewBag.Balance = String.Format(culture, "{0:C0}", Balance);


            //Doughnut Chart - Expense By Category

            ViewBag.DoughnutChartData = SelectedDonations
                .Where(i => i.Category.Title == "Money")
                .GroupBy(j => j.Category.CategoryId)
                .Select(k => new
                {
                    categoryTitleWithIcon = k.First().Category.Icon + " " + k.First().Category.Title,
                    amount = k.Sum(j => j.Amount),
                    formattedAmount = k.Sum(j => j.Amount).ToString("C0"),
                })
                .OrderByDescending(l => l.amount)
                .ToList();


            //Spline Chart - Income vs Expense

            //Income
            List<SplineChartData> IncomeSummary = SelectedDonations
                .Where(i => i.Category.Title == "Money")
                .GroupBy(j => j.Date)
                .Select(k => new SplineChartData()
                {
                    day = k.First().Date.ToString("dd-MMM"),
                    income = k.Sum(l => l.Amount)
                })
                .ToList();

            //Expense
            List<SplineChartData> ExpenseSummary = SelectedExpenses
                .Where(i => i.Type == "Expense")
                .GroupBy(j => j.Date)
                .Select(k => new SplineChartData()
                {
                    day = k.First().Date.ToString("dd-MMM"),
                    expense = k.Sum(l => l.PurchaseAmount)
                })
                .ToList();

            //Combine Income & Expense
            string[] Last7Days = Enumerable.Range(0, 7)
                .Select(i => StartDate.AddDays(i).ToString("dd-MMM"))
                .ToArray();

            ViewBag.SplineChartData = from day in Last7Days
                                      join income in IncomeSummary on day equals income.day into dayIncomeJoined
                                      from income in dayIncomeJoined.DefaultIfEmpty()
                                      join expense in ExpenseSummary on day equals expense.day into expenseJoined
                                      from expense in expenseJoined.DefaultIfEmpty()
                                      select new
                                      {
                                          day = day,
                                          income = income == null ? 0 : income.income,
                                          expense = expense == null ? 0 : expense.expense,
                                      };

            ViewBag.RecentTransactions = await _context.Monetary_Allocations
               .Include(i => i.Disaster)
                .Take(5)
               .ToListAsync();

            ViewBag.ActiveDisasters = await _context.Disasters
               .ToListAsync();

            return View();

           
        }
    }
    //Added data to be used in splinchart 

    public class SplineChartData
    {
        public string day;
        public int income;
        public int expense;

    }

}
//Build an Expense Tracker with Asp.Net Core MVC. 2022. YouTube video, added by CodeAffection. [Online]. Available at: 
//https://youtu.be/zQ5eijfpuu8 [Accessed 10 October 2022]