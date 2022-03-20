namespace GDA.Dominio.ViewModel
{
    /// <summary>
    /// The filter students view model.
    /// </summary>
    public class FilterStudentsViewModel
    {
        /// <summary>
        /// Gets or sets the student.
        /// </summary>
        public string Student { get; set; }
        /// <summary>
        /// Gets or sets the birth date init.
        /// </summary>
        public DateTime? BirthDateInit { get; set; }
        /// <summary>
        /// Gets or sets the birth date final.
        /// </summary>
        public DateTime? BirthDateFinal { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether active.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// Gets or sets the school class.
        /// </summary>
        public string SchoolClass { get; set; }
    }
}
