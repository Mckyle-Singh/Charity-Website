using LoginSec.Areas.Identity.Data;
using LoginSec.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationUnitTest
{
    [TestClass]
    public class MonetaryDonationsControllerUnitTest
    {
        private readonly ApplicationDbContext _context;

        [TestMethod]
        public async Task Index()
        {
            var controller = new MonetaryDonationController(_context);
            var result = controller.Index();
            Assert.IsNotNull(result);

        }
    }
}
