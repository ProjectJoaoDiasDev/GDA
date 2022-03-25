using GDA.Domain.Domain;

namespace GDA.Domain.Interfaces.Account
{
    /// <summary>
    /// The user.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the normalized user name.
        /// </summary>
        public string NormalizedUserName { get; set; }
        /// <summary>
        /// Gets or sets the student manager.
        /// </summary>
        public StudentManager? StudentManager { get; set; }
    }
}
