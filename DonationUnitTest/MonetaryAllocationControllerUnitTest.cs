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
    public class MonetaryAllocationControllerUnitTest
    {
        private readonly ApplicationDbContext _context;

        [TestMethod]
        public async Task Index()
        {
            var controller = new Monetary_AllocationController(_context);
            var result = controller.Index();
            Assert.IsNotNull(result);

        }

    }
}
