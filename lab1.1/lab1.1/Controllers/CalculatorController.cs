using Microsoft.AspNetCore.Mvc;
using lab1._1.Models;

namespace lab1._1.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate(CalculatorModel model)
        {
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

            return View("Index", model);
        }
    }
}