using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Oodit.Models;
using System.Diagnostics;
using System.Linq;

namespace Oodit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(InputForm form)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = TrimSquareBraces(form.Value)
                .Split(',')
                .Select(int.Parse)
                .GroupBy(x => x)
                .Where(y => y.Count() >= 3)
                .Select(x => x.Key)
                .OrderByDescending(x => x);

            ViewData["Result"] = JsonConvert.SerializeObject(result);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string TrimSquareBraces(string value)
            => value.TrimStart('[')
            .TrimEnd(']');
    }
}
