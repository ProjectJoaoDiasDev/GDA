using System.ComponentModel.DataAnnotations.Schema;

namespace GDA.Dominio.Domain
{
    /// <summary>
    /// The student.
    /// </summary>
    public class Student : AbstractEntity
    {
        /// <summary>
        /// Gets or sets the student code.
        /// </summary>
        public long StudentCode { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Column(TypeName = "VARCHAR(250)")]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the school class.
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        public string? SchoolClass { get; set; }
        /// <summary>
        /// Gets or sets the contact number main.
        /// </summary>
        [Column(TypeName = "VARCHAR(50)")]
        public string ContactNumberMain { get; set; }
        /// <summary>
        /// Gets or sets the responsible.
        /// </summary>
        public string? Responsible { get; set; }
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        [Column(TypeName = "VARCHAR(MAX)")]
        public string? Comments { get; set; }
        /// <summary>
        /// Gets or sets the contact number secondary.
        ///</summary>
        [Column(TypeName = "VARCHAR(50)")]
        public string? ContactNumberSecondary { get; set; }
        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        public DateTime? BirthDate { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        public string? Email { get; set; }
        /// <summary>
        /// Gets or sets the cpf.
        /// </summary>
        [Column(TypeName = "VARCHAR(50)")]
        public string? CPF { get; set; }
        /// <summary>
        /// Gets or sets the rg.
        /// </summary>
        [Column(TypeName = "VARCHAR(50)")]
        public string? RG { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether active.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public Address Address { get; set; }
        /// <summary>
        /// Gets or sets the student manager.
        /// </summary>
        public virtual StudentManager StudentManager { get; set; }
    }
}
