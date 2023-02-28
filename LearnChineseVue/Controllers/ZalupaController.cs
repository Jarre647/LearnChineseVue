using Microsoft.AspNetCore.Mvc;

namespace LearnChineseVue.Controllers
{
    [Route("[controller]")]
    [Controller]
    public class ZalupaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
