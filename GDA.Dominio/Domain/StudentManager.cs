using System.ComponentModel.DataAnnotations.Schema;

namespace GDA.Dominio.Domain
{
    /// <summary>
    /// The student manager.
    /// </summary>
    public class StudentManager : AbstractEntity
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Column(TypeName = "VARCHAR(150)")]
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the nome.
        /// </summary>
        [Column(TypeName = "VARCHAR(200)")]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the cpf.
        /// </summary>
    }
}
