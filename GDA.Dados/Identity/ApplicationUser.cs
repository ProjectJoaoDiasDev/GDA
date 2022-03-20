using GDA.Dominio.Domain;
using GDA.Dominio.Interfaces.Account;
using Microsoft.AspNetCore.Identity;

namespace GDA.Dados.Identity
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
