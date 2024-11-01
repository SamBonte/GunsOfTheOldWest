using Microsoft.AspNetCore.Mvc;
using GunsOfTheOldWest.Ui.Mvc.Models;

namespace GunsOfTheOldWest.Ui.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private static Random _random = new Random();

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Bullets") == null)
            {
                HttpContext.Session.SetInt32("Bullets", 12);
            }

            int bullets = HttpContext.Session.GetInt32("Bullets") ?? 12;
            ViewBag.Bullets = bullets;
            ViewBag.Message = $"Nog {bullets} kogels";
            return View();
        }

        [HttpPost]
        public IActionResult Shoot()
        {
            int bullets = HttpContext.Session.GetInt32("Bullets") ?? 12;

            if (bullets > 0)
            {
                bullets--;
                HttpContext.Session.SetInt32("Bullets", bullets);

                int randomNumber = _random.Next(0, 12);

                // 0-11 = 12 mogelijkheden. 0=1..1=2..2=3...
                if (randomNumber <= 2) 
                {
                    return RedirectToAction("WinnerForm");
                }

                ViewBag.Message = $"Nog {bullets} kogels";
            }
            else
            {
                return RedirectToAction("Reload");
            }

            HttpContext.Session.SetInt32("Bullets", bullets);
            ViewBag.Bullets = bullets;
            return View("Index");
        }

        public IActionResult WinnerForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WinnerForm(UserModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Summary", model);
            }

            return View(model);
        }

        public IActionResult Summary(UserModel model)
        {
            ViewBag.SubmitDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View(model);
        }

        public IActionResult Reload()
        {
            return View();
        }

        public IActionResult BuyBullets(int amount)
        {
            // Krijg huidig aantal kogels uit de sessie
            int bullets = HttpContext.Session.GetInt32("Bullets") ?? 0;

            // Voeg het aantal gekochte kogels toe
            bullets += amount;
            HttpContext.Session.SetInt32("Bullets", bullets);

            // Ga terug naar het startscherm
            return RedirectToAction("Index");
        }
    }
}

