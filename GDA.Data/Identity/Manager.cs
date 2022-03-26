using GDA.Data.Contexts;
using GDA.Domain.Domain;
using GDA.Domain.Entities;
using GDA.Domain.Interfaces.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GDA.Data.Identity
{
    /// <summary>
    /// The manager.
    /// </summary>
    public class Manager : IManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;

        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        /// <param name="dbContext">The db context.</param>
        /// <param name="passwordHasher">The password hasher.</param>
        public Manager(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext dbContext,
            IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// Creates the async.
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="roles">The roles.</param>
        /// <returns>A Task.</returns>
        public async Task<bool> CreateAsync(string nome, string usuario, string email, string password, string roles, StudentManager studentManager)
        {
            var user = new ApplicationUser { UserName = nome, Email = email, NormalizedEmail = email, NormalizedUserName = nome, StudentManager = studentManager };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, roles);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Updates the async.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="roles">The roles.</param>
        /// <returns>A Task.</returns>
        public async Task<bool> UpdateAsync(string id, string username, string email, string password, string[] roles)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                if (!string.IsNullOrEmpty(username))
                {
                    user.UserName = username;
                }

                if (!string.IsNullOrEmpty(email))
                {
                    user.Email = email;
                }

                if (!string.IsNullOrEmpty(password))
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user, password);
                }


                var result = await _userManager.UpdateAsync(user);


                if (result.Succeeded)
                {
                    if (roles.Length > 0)
                    {
                        var rolesAntes = await GetRoles(user.Id);

                        await _userManager.RemoveFromRolesAsync(user, rolesAntes);

                        await _userManager.AddToRolesAsync(user, roles);
                    }


                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// Gets the role id.
        /// </summary>
        /// <param name="Id">The id.</param>
        /// <returns>An array of string.</returns>
        public string[] GetRoleId(string Id)
        {
            var userRole = _dbContext.UserRoles.AsQueryable().Where(p => p.UserId == Id).ToList();

            return userRole.Select(n => n.RoleId).ToArray();
        }

        /// <summary>
        /// Ifs the not exist role add.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="role">The role.</param>
        /// <returns>A Task.</returns>
        private async Task<bool> IfNotExistRoleAdd(ApplicationUser user, string role)
        {
            var roles = await _userManager.GetRolesAsync(user);

            bool found = roles.Contains(role);

            if (!found)
            {
                await _userManager.AddToRoleAsync(user, role);
            }
            return false;
        }

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        public async Task<List<string>> GetRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var ret = await _userManager.GetRolesAsync(user);

            return ret.ToList();
        }

        /// <summary>
        /// Gets the user name.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns>An IUser? .</returns>
        public IUser? GetUserName(string userName)
        {
            if (!_dbContext.Users.Any()) return null;
            return _dbContext.Users.Include(st => st.StudentManager).FirstOrDefault(us => us.UserName.Equals(userName));
        }

        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>An IUser.</returns>
        public IUser GetUserByEmail(string email)
        {
            if (!_dbContext.Users.Any()) return null;

            return _dbContext.Users.Where(u => u.Email == email || u.UserName == email).FirstOrDefault();
        }

        /// <summary>
        /// Lists the all role.
        /// </summary>
        /// <returns>A list of IRoles.</returns>
        public List<IRole> ListAllRole()
        {
            var roles = _dbContext.Roles;

            List<IRole> ListRole = new List<IRole>();

            foreach (var item in roles)
            {
                ListRole.Add(new Role() { Id = item.Id, Name = item.Name });
            }

            return ListRole;
        }

        /// <summary>
        /// Lists the all.
        /// </summary>
        /// <returns>A list of IUsers.</returns>
        public List<IUser> ListAll()
        {
            var users = _dbContext.Users
               .Include(std => std.StudentManager);

            return users.Any() ? users.Select(u => (IUser)u).ToList() : new List<IUser>();
        }
    }
}