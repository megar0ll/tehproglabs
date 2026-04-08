using Microsoft.AspNetCore.Mvc;
using lab2_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2_1.Controllers
{
    public class CarController : Controller
    {
        private static List<Car> cars = new List<Car>();
        private static int nextId = 1;

        static CarController()
        {
            cars.Add(new Car { Id = nextId++, Brand = "Toyota", Model = "Camry", Year = 2023, Price = 3500000, Mileage = 0, FuelType = "Бензин", Description = "Новый автомобиль в отличной комплектации.", CreatedDate = DateTime.Now.AddDays(-5) });
            cars.Add(new Car { Id = nextId++, Brand = "BMW", Model = "X5", Year = 2022, Price = 7800000, Mileage = 15000, FuelType = "Дизель", Description = "Премиальный внедорожник с полным приводом.", CreatedDate = DateTime.Now.AddDays(-10) });
            cars.Add(new Car { Id = nextId++, Brand = "Tesla", Model = "Model 3", Year = 2024, Price = 5200000, Mileage = 5000, FuelType = "Электричество", Description = "Электромобиль с автопилотом.", CreatedDate = DateTime.Now.AddDays(-2) });
        }

        public IActionResult Index()
        {
            return View(cars.OrderByDescending(c => c.CreatedDate).ToList());
        }

        public IActionResult Details(int id)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
                return NotFound();
            return View(car);
        }

        public IActionResult Create()
        {
            var car = new Car { CreatedDate = DateTime.Now, Year = DateTime.Now.Year };
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                car.Id = nextId++;
                car.CreatedDate = DateTime.Now;
                cars.Add(car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        public IActionResult Edit(int id)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
                return NotFound();
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Car car)
        {
            if (id != car.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var existingCar = cars.FirstOrDefault(c => c.Id == car.Id);
                if (existingCar == null)
                    return NotFound();

                existingCar.Brand = car.Brand;
                existingCar.Model = car.Model;
                existingCar.Year = car.Year;
                existingCar.Price = car.Price;
                existingCar.Mileage = car.Mileage;
                existingCar.FuelType = car.FuelType;
                existingCar.Description = car.Description;

                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        public IActionResult Delete(int id)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
                return NotFound();
            return View(car);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car != null)
                cars.Remove(car);
            return RedirectToAction(nameof(Index));
        }
    }
}