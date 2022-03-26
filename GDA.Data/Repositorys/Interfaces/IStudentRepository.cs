using GDA.Domain.Domain;

namespace GDA.Data.Repositorys
{
    /// <summary>
    /// The student repository.
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// Updates the.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(Student entity);
        /// <summary>
        /// Saves the.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Save(Student entity);
        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns>A         List&lt;Student&gt;? .</returns>
        List<Student>? GetAll();
    }
}