namespace GDA.Dominio
{
    /// <summary>
    /// The domain exception.
    /// </summary>
    public class DomainException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainException"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        public DomainException(string error) : base(error)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainException"/> class.
        /// </summary>
        public DomainException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public DomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Whens the.
        /// </summary>
        /// <param name="hasError">If true, has error.</param>
        /// <param name="error">The error.</param>
        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainException(error);
        }
    }

}
