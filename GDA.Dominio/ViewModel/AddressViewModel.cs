namespace GDA.Dominio.ViewModel
{
    /// <summary>
    /// The address view model.
    /// </summary>
    public class AddressViewModel
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the c e p.
        /// </summary>
        public string? CEP { get; set; }
        /// <summary>
        /// Gets or sets the district.
        /// </summary>
        public string? District { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string? City { get; set; }
        /// <summary>
        /// Gets or sets the u f.
        /// </summary>
        public string? UF { get; set; }
        /// <summary>
        /// Gets or sets the complemento.
        /// </summary>
        public string? Complement { get; set; }
        /// <summary>
        /// Gets or sets the logradouro.
        /// </summary>
        public string? PublicPlace { get; set; }
        /// <summary>
        /// Gets or sets the observacao.
        /// </summary>
        public string? Observation { get; set; }
    }
}
