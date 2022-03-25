using GDA.Domain.Domain;

namespace GDA.Domain.Interfaces.Account
{
    /// <summary>
    /// The manager.
    /// </summary>
    public interface IManager
    {
        /// <summary>
        /// Creates the async.
        /// </summary>
        /// <param name="nome">The nome.</param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="roles">The roles.</param>
        /// <returns>A Task.</returns>
        public Task<bool> CreateAsync(string nomecompleto, string usuario, string email, string password, string roles, StudentManager studentManager);
        /// <summary>
        /// Updates the async.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="roles">The roles.</param>
        /// <returns>A Task.</returns>
        public Task<bool> UpdateAsync(string id, string username, string email, string password, string[] roles);
        /// <summary>
        /// Gets the role id.
        /// </summary>
        /// <param name="Id">The id.</param>
        /// <returns>An array of string.</returns>
        public string[] GetRoleId(string Id);
        /// <summary>
        /// Lists the all role.
        /// </summary>
        /// <returns>A list of IRoles.</returns>
        public List<IRole> ListAllRole();
        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        public Task<List<string>> GetRoles(string id);
        /// <summary>
        /// Lists the all.
        /// </summary>
        /// <returns>A list of IUsers.</returns>
        public List<IUser> ListAll();
        /// <summary>
        /// Gets the user name.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>An IUser.</returns>
        public IUser GetUserName(string userName);
        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>An IUser.</returns>
        public IUser GetUserByEmail(string email);
    }
}
