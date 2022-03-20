using GDA.Dados.Identity;
using GDA.Dominio.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GDA.Dados.Contexts
{
    /// <summary>
    /// The application db context.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// Gets or sets the student.
        /// </summary>
        public DbSet<Student> Student { get; set; }
        /// <summary>
        /// Gets or sets the student manager.
        /// </summary>
        public DbSet<StudentManager> StudentManager { get; set; }
    }


}
