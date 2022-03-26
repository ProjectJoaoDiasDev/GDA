using GDA.Data.Contexts;
using GDA.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace GDA.Data.Repositorys
{
    /// <summary>
    /// The student repository.
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
        public readonly ApplicationDbContext Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public StudentRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <param name="studentManagerId">The student manager id.</param>
        /// <returns>A List of Student? .</returns>
        public List<Student> GetAllByIdStudentManager(int studentManagerId)
        {
            if (!Context.Student.Any()) return null;
            return Context.Student
                .Include(e => e.Address)
                .Where(x => x.StudentManager.Id == studentManagerId)?.ToList();
        }

        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns>A list of Students.</returns>
        public List<Student> GetAll()
        {
            return Context.Student
                .Include(e => e.StudentManager)
                .Include(e => e.Address)
                .ToList();
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Student? .</returns>
        public Student GetById(int id)
        {
            return Context.Student
                .Include(e => e.StudentManager)
                .Include(e => e.Address)
                .FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Gets the by ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>A List of Student? .</returns>
        public List<Student> GetByIds(int[] ids)
        {
            if (ids.Length == 0) return null;

            return Context.Student.Where(x => ids.Any(a => a == x.Id))?.ToList();
        }

        /// <summary>
        /// Saves the.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Save(Student entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Context.Add(entity);
        }
        /// <summary>
        /// Updates the.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(Student entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Context.Update(entity);
        }
    }
}
