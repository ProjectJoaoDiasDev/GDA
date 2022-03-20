using Microsoft.AspNetCore.Mvc;

namespace GDA.Web.Controllers
{
    public class Student : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
