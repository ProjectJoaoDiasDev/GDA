namespace GDA.Domain.ViewModel
{
    /// <summary>
    /// The student view model.
    /// </summary>
    public class StudentViewModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the school class.
        /// </summary>
        public string? SchoolClass { get; set; }
        /// <summary>
        /// Gets or sets the contact number main.
        /// </summary>
        public string ContactNumberMain { get; set; }
        /// <summary>
        /// Gets or sets the responsible.
        /// </summary>
        public string? Responsible { get; set; }
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        public string? Comments { get; set; }
        /// <summary>
        /// Gets or sets the contact number secondary.
        ///</summary>
        public string? ContactNumberSecondary { get; set; }
        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        public DateTime? BirthDate { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Gets or sets the cpf.
        /// </summary>
        public string? CPF { get; set; }
        /// <summary>
        /// Gets or sets the rg.
        /// </summary>
        public string? RG { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether active.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public AddressViewModel Address { get; set; }
    }
}
