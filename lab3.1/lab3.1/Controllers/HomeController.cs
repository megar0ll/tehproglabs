using Microsoft.AspNetCore.Mvc;

namespace lab3._1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string carId, string brand, string model, int year, bool isAvailable, string fuelType)
        {
            if (!string.IsNullOrEmpty(carId))
            {
                ViewBag.CarId = carId;
                ViewBag.Brand = brand;
                ViewBag.Model = model;
                ViewBag.Year = year;
                ViewBag.IsAvailable = isAvailable;
                ViewBag.FuelType = fuelType;

                return View("Result");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}