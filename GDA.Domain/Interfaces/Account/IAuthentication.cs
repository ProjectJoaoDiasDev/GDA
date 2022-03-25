namespace GDA.Domain.Interfaces.Account
{
    /// <summary>
    /// The authentication.
    /// </summary>
    public interface IAuthentication
    {
        /// <summary>
        /// Authenticates the.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <param name="remember">If true, remember.</param>
        /// <param name="lockOut">If true, lock out.</param>
        /// <returns>A Task.</returns>
        Task<bool> Authenticate(string user, string password, bool remember, bool lockOut);
        /// <summary>
        /// Logouts the.
        /// </summary>
        /// <returns>A Task.</returns>
        Task<bool> Logout();
    }
}
