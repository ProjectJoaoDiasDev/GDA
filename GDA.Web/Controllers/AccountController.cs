using GDA.Data.Identity;
using GDA.Domain;
using GDA.Domain.Interfaces.Account;
using GDA.Domain.ViewModel;
using GDA.Solution.Services.ServicesStudentManager;
using GDA.Solution.Utils;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Logins the view.
        /// </summary>
        /// <param name="loginVm">The login vm.</param>
        /// <returns>A Task.</returns>
        public async Task<IActionResult> LoginView(LoginViewModel loginVm)
        {
            return Ok(View(loginVm));
        }

        /// <summary>
        /// Logins the.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>A Task.</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (string.IsNullOrEmpty(model?.Login)) return View();

            var studentManager = _studentManagerServices.GetByName(model.Login);

            if (studentManager != null)
            {
                var user = _imanager.GetUserName(studentManager.Name);
                if (user == null)
                {
                    await _imanager.CreateAsync(studentManager.Name, studentManager.Name, studentManager.Email, "mudar", "StudentManager", studentManager);
                }
            }

            var result = await _authentication.Authenticate(model.Login, model.Password, model.Remember, false);
            if (result)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    return Redirect(model.ReturnUrl);
                else
                    return Redirect("/");
            }
            else
            {
                ModelState.AddModelError("Login", "Login Inválido");
                return View(model);
            }
        }

        /// <summary>
        /// Gets the view enviar email redefinir senha.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="token">The token.</param>
        /// <param name="suffix">The suffix.</param>
        /// <returns>A Task.</returns>
        [HttpGet("/account/redefinir-senha")]
        public async Task<IActionResult> GetViewEnviarEmailRedefinirSenha(string userId, string token, string suffix)
        {
            return View("../account/EnviarEmailResetSenha");
        }

        /// <summary>
        /// Obtains the token change password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>A Task.</returns>
        [HttpPost("/account/obter-token-alterar-senha")]
        [AllowAnonymous]
        public async Task<IActionResult> ObtainTokenChangePassword([FromBody] string email)
        {
            var user = (ApplicationUser)_imanager.GetUserByEmail(email);

            DomainException.When(user == null, "Usuário não encontrado");

            var cToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var cTokenLink = Url.Action("resetPassword", "account", new
            {
                userId = user.Id,
                token = cToken

            }, protocol: HttpContext.Request.Scheme);

            EmailServices.SendEmail("GDA - Recuperar senha",
                                    $"Clique no link para alterar sua senha de acesso\n\n{cTokenLink}",
                                    email);

            return Ok();
        }

        /// <summary>
        /// Gets the view alterar senha.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="token">The token.</param>
        /// <returns>A Task.</returns>
        [HttpGet("/account/resetPassword")]
        public async Task<IActionResult> GetViewAlterarSenha(string userId, string token)
        {
            return View("../account/alterarSenha");
        }

        /// <summary>
        /// Alterars the senha.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>A Task.</returns>
        [HttpPost("/account/alterar-senha")]
        [AllowAnonymous]
        public async Task<IActionResult> AlterarSenha([FromBody] NewPasswordViewModel data)
        {
            DomainException.When(string.IsNullOrEmpty(data.Senha), "Senha inválida");
            DomainException.When(string.IsNullOrEmpty(data.UserId), "Usuário não informado");

            var user = await _userManager.FindByIdAsync(data.UserId);

            var result = await _userManager.ResetPasswordAsync(user, data.Token, data.Senha);


            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Falha ao alterar senha");
            }
        }

        /// <summary>
        /// Logouts the.
        /// </summary>
        /// <returns>A Task.</returns>
        public async Task<IActionResult> Logout()
        {
            await _authentication.Logout();
            return Redirect("/");
        }

        /// <summary>
        /// Accesses the denied.
        /// </summary>
        /// <returns>An IActionResult.</returns>
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
