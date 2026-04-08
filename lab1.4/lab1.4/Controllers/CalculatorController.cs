using Microsoft.AspNetCore.Mvc;
using lab1._4.Models;

namespace lab1._4.Controllers
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

            if (action == "clear")
            {
                ModelState.Clear();
                model.Operand1 = null;
                model.Operand2 = null;
                model.Operation = null;
                model.Result = 0;
                return View(model);
            }

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
                            ModelState.AddModelError("", "Division by zero not allowed");
                        }
                        break;
                }

                // Пункт 1: Сохраняем информацию об операции в сессию
                if (ModelState.IsValid)
                {
                    string operationRecord = $"{model.Operand1} {model.Operation} {model.Operand2} = {model.Result}";

                    // Получаем существующую историю из сессии
                    List<string> history = HttpContext.Session.GetObjectFromJson<List<string>>("CalculatorHistory") ?? new List<string>();

                    // Добавляем новую запись в начало списка (последняя операция сверху)
                    history.Insert(0, operationRecord);

                    // Ограничиваем историю последними 10 записями
                    if (history.Count > 10)
                    {
                        history = history.Take(10).ToList();
                    }

                    // Сохраняем обратно в сессию
                    HttpContext.Session.SetObjectAsJson("CalculatorHistory", history);
                }
            }

            return View(model);
        }
    }

    // Extension methods для работы с JSON в сессии
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, System.Text.Json.JsonSerializer.Serialize(value));
        }

        public static T? GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : System.Text.Json.JsonSerializer.Deserialize<T>(value);
        }
    }
}