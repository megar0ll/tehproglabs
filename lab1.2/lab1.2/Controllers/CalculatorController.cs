using Microsoft.AspNetCore.Mvc;
using lab1._2.Models;

namespace lab1._2.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate(CalculatorModel model, string submitButton)
        {
            if (submitButton == "clear")
            {
                model.Operand1 = 0;
                model.Operand2 = 0;
                model.Operation = null;
                model.Result = 0;

                ViewBag.Message = "Поля очищены. Введите новые значения.";
                return View("Index", model);
            }

            if (ModelState.IsValid)
            {
                switch (model.Operation)
                {
                    case "+":
                        model.Result = model.Operand1 + model.Operand2;
                        break;
                    case "-":
                        model.Result = model.Operand1 - model.Operand2;
                        break;
                    case "*":
                        model.Result = model.Operand1 * model.Operand2;
                        break;
                    case "/":
                        if (model.Operand2 != 0)
                        {
                            model.Result = model.Operand1 / model.Operand2;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Деление на ноль невозможно.");
                        }
                        break;
                    default:
                        ModelState.AddModelError("", "Не выбрана операция.");
                        break;
                }
            }
            ViewBag.TargetValue = 100;

            return View("Index", model);
        }
    }
}