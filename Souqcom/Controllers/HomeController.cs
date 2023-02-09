using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Souqcom.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Souqcom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        EcommerceContext db = new EcommerceContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            ViewBag.Review = db.Reviews.ToList();
            ViewBag.product = db.Products.Take(8).ToList();
            ViewBag.category = db.Categories.Take(3).ToList();
                 
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Category()
        {
            var cat = db.Categories.ToList();
            return View(cat);
        }
        public IActionResult Product()
        {

            var prod = db.Products.ToList();
            return View(prod);
        }
        public IActionResult Productcat(int id)
        {
            var prod = db.Products.Where(x => x.Catid == id).ToList();
            return View(prod);
        }
        public IActionResult Productsearch(string xname)
        {
            var prod = db.Products.Where(x => x.Name.Contains(xname)).ToList();
            return View("Product", prod);
        }
        public IActionResult Review()
        {
            var rev = db.Reviews.ToList();
            return View(rev);
        }

        [HttpPost]
        public IActionResult Savereview(Review model)
        {

            db.Reviews.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Productdetails(int id)
        {
            ViewBag.product = db.Products.Where(x => x.Id == id).ToList();
            var pord = db.ProductImages.Where(x => x.ProductId == id).ToList();
            return View(pord);
        }
        public IActionResult Cart()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
