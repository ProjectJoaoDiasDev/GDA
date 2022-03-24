using GDA.Dominio.ViewModel;
using GDA.Solution.Services.ServicesStudent;
using Microsoft.AspNetCore.Mvc;

namespace GDA.Web.Controllers
{
    /// <summary>
    /// The student.
    /// </summary>
    public class Student : Controller
    {
        private readonly StudentServices _studentServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="studentServices">The student services.</param>
        public Student(StudentServices studentServices)
        {
            _studentServices = studentServices;
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
        /// Edits the.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>An IActionResult.</returns>
        public IActionResult Edit(int id)
        {
            var student = _studentServices.GetById(id);
            return View("New", _studentServices.StudentToViewModel(student));
        }

        /// <summary>
        /// News the.
        /// </summary>
        /// <param name="studentViewModel">The student view model.</param>
        /// <param name="returnUrl">The return url.</param>
        /// <returns>An IActionResult.</returns>
        [HttpPost]
        public IActionResult New(StudentViewModel studentViewModel, string returnUrl)
        {
            _studentServices.Create(studentViewModel);
            return Redirect(returnUrl);
        }

        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns>An IActionResult.</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var student = _studentServices?.GetAllByIdStudentManager()?.Select(std => _studentServices.StudentToViewModel(std))?.ToList();
            return Json(student);
        }
    }
}
