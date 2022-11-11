using LoginSec.Areas.Identity.Data;
using LoginSec.Controllers;
using LoginSec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationUnitTest
{
    [TestClass]
    public class DisasterControllerUnitTest
    {
        private readonly ApplicationDbContext _context;

        //This will test that the data for th date field is entered
        [TestMethod]
        public void ControllerTest_ReturnDateValue()
        {
            var controller = new DisasterController(_context);
            var result = controller.AddOrEdit() as Microsoft.AspNetCore.Mvc.ViewResult;
            var product = (Disaster)result.ViewData.Model;
            Assert.IsNotNull(product.StartDate);
        }

        //This method will check wether the index method returns a view page
        [TestMethod]
        public async Task ControllerIndexPageTest_ReturnPage()
        {
            var controller = new DisasterController(_context);
            var result = controller.Index();
            Assert.IsNotNull(result);

        }
    }
}
