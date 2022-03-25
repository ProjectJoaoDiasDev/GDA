using GDA.Domain.Domain;
using GDA.Domain.Interfaces.Account;
using Microsoft.AspNetCore.Identity;

namespace GDA.Data.Identity
{
    /// <summary>
    /// The application user.
    /// </summary>
    public class ApplicationUser : IdentityUser, IUser
    {
        /// <summary>
        /// Gets or sets the manager.
        /// </summary>
        public StudentManager? StudentManager { get; set; }
    }
}
