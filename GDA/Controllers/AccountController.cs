using GDA.Dados.Identity;
using GDA.Dominio.Interfaces.Account;
using GDA.Dominio.ViewModel;
using GDA.Solution.Services.ServicesStudentManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GDA.Web.Controllers
{
    /// <summary>
    /// The account controller.
    /// </summary>
    public class AccountController : Controller
    {
        private readonly IAuthentication _authentication;
        private readonly IManager _imanager;
        private StudentManagerServices _studentManagerServices;
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="authentication">The authentication.</param>
        /// <param name="imanager">The imanager.</param>
        /// <param name="studentManagerServices">The student manager services.</param>
        /// <param name="userManager">The user manager.</param>
        public AccountController(IAuthentication authentication, IManager imanager, StudentManagerServices studentManagerServices, UserManager<ApplicationUser> userManager)
        {
            _authentication = authentication;
            _imanager = imanager;
            _studentManagerServices = studentManagerServices;
            _userManager = userManager;
        }

        /// <summary>
        /// Logins the.
        /// </summary>
        /// <param name="ReturnUrl">The return url.</param>
        /// <returns>An IActionResult.</returns>
        public IActionResult Login(string ReturnUrl)
        {
            var ret = new LoginViewModel()
            {
                Login = "",
                Remember = false,
                ReturnUrl = ReturnUrl,
                Password = ""
            };

            return View(ret);
        }
    }
}
