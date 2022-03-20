namespace GDA.Dominio.Interfaces
{
    /// <summary>
    /// The unit of work.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commits the.
        /// </summary>
        /// <returns>A Task.</returns>
        Task Commit();
        /// <summary>
        /// Commits the sync.
        /// </summary>
        void CommitSync();
    }
}
