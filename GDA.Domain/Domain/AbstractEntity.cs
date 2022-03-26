namespace GDA.Domain.Domain
{
    /// <summary>
    /// The abstract entity.
    /// </summary>
    public class AbstractEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbsEntity"/> class.
        /// </summary>
        public AbstractEntity()
        {
            if (Id <= 0)
            {
                RegistrationDate = DateTime.Now;
            }
        }

        /// <summary>
        /// Chave primaria
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Data de cadastro
        /// </summary>
        public DateTime RegistrationDate { get; }
    }
}
