using Microsoft.AspNetCore.Mvc;

namespace TCCTrabalho3.Controllers
{
    public class MeusCursosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
