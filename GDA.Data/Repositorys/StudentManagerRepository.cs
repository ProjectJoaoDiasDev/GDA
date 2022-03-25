using GDA.Data.Contexts;
using GDA.Domain.Domain;

namespace GDA.Data.Repositorys
{
    /// <summary>
    /// The student manager repository.
    /// </summary>
    public class StudentManagerRepository : IStudentManagerRepository
    {
        public readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentManagerRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public StudentManagerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns>A List&lt;StudentManager&gt;? .</returns>
        public List<StudentManager>? GetAll() => _context.StudentManager?.ToList();

        /// <summary>
        /// Gets the by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>A StudentManager? .</returns>
        public StudentManager GetByEmail(string email)
        {
            return _context.StudentManager.FirstOrDefault(x => x.Email == email);
        }

        public StudentManager GetByName(string name)
        {
            return _context.StudentManager.FirstOrDefault(x => x.Name == name);
        }


        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A StudentManager? .</returns>
        public StudentManager? GetById(int id)
        {
            return _context.StudentManager.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Saves the.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Save(StudentManager entity)
        {
            _context.Add(entity);
        }

        /// <summary>
        /// Updates the.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(StudentManager entity)
        {
            _context.Update(entity);
        }
    }
}
