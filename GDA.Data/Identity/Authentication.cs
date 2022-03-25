using GDA.Domain.Interfaces.Account;
using Microsoft.AspNetCore.Identity;

namespace GDA.Data.Identity
{
    /// <summary>
    /// The authentication.
    /// </summary>
    public class Authentication : IAuthentication
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="Authentication"/> class.
        /// </summary>
        /// <param name="signInManager">The sign in manager.</param>
        public Authentication(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        /// <summary>
        /// Authenticates the.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <param name="relembre">If true, relembre.</param>
        /// <param name="lockOut">If true, lock out.</param>
        /// <returns>A Task.</returns>
        public async Task<bool> Authenticate(string user, string password, bool relembre, bool lockOut)
        {
            var result = await _signInManager.PasswordSignInAsync(user, password, relembre, lockoutOnFailure: lockOut);

            return result.Succeeded;
        }

        /// <summary>
        /// Logouts the.
        /// </summary>
        /// <returns>A Task.</returns>
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
