using Microsoft.AspNetCore.Mvc;
using lab1._3.Models;

namespace lab1._3.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new CalculatorModel();
            ViewBag.TargetValue = 42;
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(CalculatorModel model, string action)
        {
            ViewBag.TargetValue = 42;

            // Пункт 5: Проверка какая кнопка нажата
            if (action == "clear")
            {
                ModelState.Clear();
                model.Operand1 = null;
                model.Operand2 = null;
                model.Operation = null;
                model.Result = 0;
                return View(model);
            }

            // Пункт 2: Используем объект ModelState для проверки валидации
            if (ModelState.IsValid)
            {
                switch (model.Operation)
                {
                    case "+":
                        model.Result = (double)(model.Operand1 ?? 0) + (model.Operand2 ?? 0);
                        break;
                    case "-":
                        model.Result = (double)(model.Operand1 ?? 0) - (model.Operand2 ?? 0);
                        break;
                    case "*":
                        model.Result = (double)(model.Operand1 ?? 0) * (model.Operand2 ?? 0);
                        break;
                    case "/":
                        if (model.Operand2 != 0)
                        {
                            model.Result = (double)(model.Operand1 ?? 0) / (model.Operand2 ?? 0);
                        }
                        else
                        {
                            ModelState.AddModelError("", "Деление на ноль невозможно!");
                        }
                        break;
                }
            }

            return View(model);
        }
    }
}