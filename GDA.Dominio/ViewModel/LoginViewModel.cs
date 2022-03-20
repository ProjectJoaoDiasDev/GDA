using System.ComponentModel.DataAnnotations;

namespace GDA.Dominio.ViewModel
{
    /// <summary>
    /// The login view model.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Endereço de Email")]
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the senha.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the return url.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether relembre.
        /// </summary>
        public bool Remember { get; set; }
    }
}
