using Microsoft.AspNetCore.Mvc;
using lab2_2.Models;
using lab2_2.Services;

namespace lab2_2.Controllers
{
    public class CarController : Controller
    {
        private int GetNextId()
        {
            int? lastId = HttpContext.Session.GetInt32("LastId");
            int maxId = CarStorage.GetMaxId();

            if (lastId == null || lastId < maxId)
                lastId = maxId;

            int nextId = lastId.Value + 1;
            HttpContext.Session.SetInt32("LastId", nextId);
            return nextId;
        }

        private void SaveCurrentIndex(int id)
        {
            var cars = CarStorage.GetAllCars();
            for (int i = 0; i < cars.Length; i++)
            {
                if (cars[i].Id == id)
                {
                    HttpContext.Session.SetInt32("CurrentIndex", i);
                    break;
                }
            }
        }

        public IActionResult Index() => View();

        public IActionResult ViewAll()
        {
            var cars = CarStorage.GetAllCars();
            ViewBag.Count = CarStorage.GetCount();
            ViewBag.MaxId = CarStorage.GetMaxId();

            int? lastId = HttpContext.Session.GetInt32("LastId");
            ViewBag.NextId = (lastId ?? CarStorage.GetMaxId()) + 1;

            return View(cars);
        }

        public IActionResult Details(int id)
        {
            var car = CarStorage.GetCarById(id);
            if (car == null) return NotFound();
            SaveCurrentIndex(id);
            return View(car);
        }

        public IActionResult Create()
        {
            return View(new Car { Year = DateTime.Now.Year, CreatedDate = DateTime.Now });
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                car.Id = GetNextId();
                car.CreatedDate = DateTime.Now;
                CarStorage.AddCar(car);
                return RedirectToAction("ViewAll");
            }
            return View(car);
        }

        public IActionResult Edit(int id)
        {
            var car = CarStorage.GetCarById(id);
            if (car == null) return NotFound();
            SaveCurrentIndex(id);
            return View(car);
        }

        [HttpPost]
        public IActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                var oldCar = CarStorage.GetCarById(car.Id);
                if (oldCar != null) car.CreatedDate = oldCar.CreatedDate;
                CarStorage.UpdateCar(car);
                return RedirectToAction("ViewAll");
            }
            return View(car);
        }

        public IActionResult Delete(int id)
        {
            var car = CarStorage.GetCarById(id);
            if (car == null) return NotFound();
            SaveCurrentIndex(id);
            return View(car);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            CarStorage.DeleteCar(id);
            return RedirectToAction("ViewAll");
        }

        public IActionResult Current()
        {
            int? index = HttpContext.Session.GetInt32("CurrentIndex");
            if (index != null)
            {
                var cars = CarStorage.GetAllCars();
                if (index >= 0 && index < cars.Length)
                    return View("Details", cars[index.Value]);
            }
            return RedirectToAction("ViewAll");
        }
    }
}