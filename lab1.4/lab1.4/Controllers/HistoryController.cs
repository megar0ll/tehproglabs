using Microsoft.AspNetCore.Mvc;

namespace lab1._4.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            // Получаем историю из сессии
            List<string> history = HttpContext.Session.GetObjectFromJson<List<string>>("CalculatorHistory") ?? new List<string>();

            // Пункт 2: Обработка строк - замена оператора на словесный аналог
            List<string> processedHistory = new List<string>();

            foreach (var record in history)
            {
                string processed = ProcessOperationString(record);
                processedHistory.Add(processed);
            }

            ViewBag.ProcessedHistory = processedHistory;
            ViewBag.RawHistory = history;

            return View();
        }

        // Пункт 2: Метод для обработки строки операции
        private string ProcessOperationString(string operation)
        {
            // Пример входной строки: "10 + 5 = 15"
            // Нужно заменить +, -, *, / на словесные аналоги

            string result = operation;

            // Находим позицию оператора
            int plusIndex = result.IndexOf(" + ");
            int minusIndex = result.IndexOf(" - ");
            int multiplyIndex = result.IndexOf(" * ");
            int divideIndex = result.IndexOf(" / ");

            if (plusIndex != -1)
            {
                // Замена + на "plus"
                result = result.Remove(plusIndex, 3);
                result = result.Insert(plusIndex, " plus ");
            }
            else if (minusIndex != -1)
            {
                // Замена - на "minus"
                result = result.Remove(minusIndex, 3);
                result = result.Insert(minusIndex, " minus ");
            }
            else if (multiplyIndex != -1)
            {
                // Замена * на "multiplied by"
                result = result.Remove(multiplyIndex, 3);
                result = result.Insert(multiplyIndex, " multiplied by ");
            }
            else if (divideIndex != -1)
            {
                // Замена / на "divided by"
                result = result.Remove(divideIndex, 3);
                result = result.Insert(divideIndex, " divided by ");
            }

            return result;
        }
    }
}