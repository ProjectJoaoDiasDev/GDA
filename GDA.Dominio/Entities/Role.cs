using GDA.Dominio.Interfaces.Account;

namespace GDA.Dominio.Entities
{
    /// <summary>
    /// The role.
    /// </summary>
    public class Role : IRole
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
    }
}
