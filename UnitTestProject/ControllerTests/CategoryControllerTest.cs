using LoginSec.Areas.Identity.Data;
using LoginSec.Controllers;
using LoginSec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.ControllerTests
{
    [TestClass]
    public class CategoryControllerTest
    {
        //Testing the data returned by the category controller
        private readonly ApplicationDbContext _context;

        [TestMethod]
        public void AddOrEditTest_ReturnExpense()
        {
            var controller = new CategoryController(_context);
            var result = controller.AddOrEdit() as Microsoft.AspNetCore.Mvc.ViewResult;
            var product = (Category)result.ViewData.Model;
            Assert.AreEqual("Monetary", product.Type);
        }
    }
}
