using System.ComponentModel.DataAnnotations.Schema;

namespace GDA.Domain.Domain
{
    /// <summary>
    /// The address.
    /// </summary>
    public class Address : AbstractEntity
    {
        /// <summary>
        /// Gets or sets the cep.
        /// </summary>
        [Column(TypeName = "VARCHAR(50)")]
        public string? CEP { get; set; }
        /// <summary>
        /// Gets or sets the district.
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        public string? District { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [Column(TypeName = "VARCHAR(150)")]
        public string? City { get; set; }
        /// <summary>
        /// Gets or sets the u f.
        /// </summary>
        [Column(TypeName = "VARCHAR(2)")]
        public string? UF { get; set; }
        /// <summary>
        /// Gets or sets the complemento.
        /// </summary>
        [Column(TypeName = "VARCHAR(200)")]
        public string? Complement { get; set; }
        /// <summary>
        /// Gets or sets the logradouro.
        /// </summary>
        [Column(TypeName = "VARCHAR(250)")]
        public string? PublicPlace { get; set; }
        /// <summary>
        /// Gets or sets the observacao.
        /// </summary>
        [Column(TypeName = "VARCHAR(250)")]
        public string? Observation { get; set; }
    }
}
