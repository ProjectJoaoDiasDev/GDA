using GDA.Dominio.Interfaces.Account;
using GDA.Dominio.ViewModel;
using GDA.Solution.Services.ServicesStudentManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GDA.Web.Controllers
{
    public class StudentManager : Controller
    {
        private readonly StudentManagerServices _studentManagerServices;
        private readonly IManager _imanager;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentManager"/> class.
        /// </summary>
        /// <param name="studentManagerServices">The student manager services.</param>
        /// <param name="imanager">The imanager.</param>
        public StudentManager(StudentManagerServices studentManagerServices, IManager imanager)
        {
            _studentManagerServices = studentManagerServices;
            _imanager = imanager;
        }

        /// <summary>
        /// Indices the.
        /// </summary>
        /// <returns>An IActionResult.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// News the.
        /// </summary>
        /// <returns>An IActionResult.</returns>
        public IActionResult New()
        {
            return View();
        }

        /// <summary>
        /// Editars the.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>An IActionResult.</returns>
        public IActionResult Edit(int id)
        {
            var studentManager = _studentManagerServices.GetById(id);
            return View("New", _studentManagerServices.StudentManagerToStudentManagerViewModel(studentManager));
        }

        /// <summary>
        /// Gets the logado.
        /// </summary>
        /// <returns>An IActionResult.</returns>
        [AllowAnonymous]
        public IActionResult GetLogado()
        {
            var empresas = _studentManagerServices.StudentManagerToStudentManagerViewModel(_studentManagerServices.GetSessionUser());
            return Ok(empresas);
        }

        /// <summary>
        /// News the.
        /// </summary>
        /// <param name="studentManagerViewModel">The student manager view model.</param>
        /// <param name="returnUrl">The return url.</param>
        /// <returns>An IActionResult.</returns>
        [HttpPost]
        public IActionResult New(StudentManagerViewModel studentManagerViewModel, string returnUrl)
        {
            _studentManagerServices.Create(studentManagerViewModel);

            return Redirect(returnUrl);
        }
    }
}
