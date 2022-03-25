using GDA.Data.Contexts;
using GDA.Domain.Interfaces;

namespace GDA.Data
{
    /// <summary>
    /// The unit of work.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Commits the.
        /// </summary>
        /// <returns>A Task.</returns>
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Commits the sync.
        /// </summary>
        public void CommitSync()
        {
            _context.SaveChanges();
        }
    }
}
