using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index() => View();
        public IActionResult About() => View();
        public IActionResult Predict() => View();
        public IActionResult Cart() => View();
        public IActionResult Login() => View();
        public IActionResult Profile() => View();
        public IActionResult Goods() => View();
        public IActionResult Services() => View();
    }
}