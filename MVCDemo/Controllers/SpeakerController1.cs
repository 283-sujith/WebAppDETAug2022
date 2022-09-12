using Microsoft.AspNetCore.Mvc;

namespace MVCDemo.Controllers
{
    public class SpeakerController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
