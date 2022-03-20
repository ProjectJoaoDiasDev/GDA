using Microsoft.AspNetCore.Mvc;

namespace GDA.Web.Controllers
{
    public class StudentManager : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
