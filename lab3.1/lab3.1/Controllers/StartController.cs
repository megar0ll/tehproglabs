using Microsoft.AspNetCore.Mvc;

namespace lab3._1.Controllers
{
    public class StartController : Controller
    {
        public IActionResult Start(int id)
        {
            string fullUrl = $"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}";

            if (id == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Ошибка: Неверные параметры запроса.";
                ViewBag.FullUrl = fullUrl;
                return View("Error");
            }
        }
    }
}