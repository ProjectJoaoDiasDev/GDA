using GDA.Dominio.Domain;

namespace GDA.Dados.Repositorys
{
    /// <summary>
    /// The student manager repository.
    /// </summary>
    public interface IStudentManagerRepository
    {
        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns>A List of StudentManager? .</returns>
        List<StudentManager>? GetAll();
        /// <summary>
        /// Gets the by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>A         StudentManager? .</returns>
        StudentManager? GetByEmail(string email);
        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A         StudentManager? .</returns>
        StudentManager? GetById(int id);
        /// <summary>
        /// Saves the.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Save(StudentManager entity);
        /// <summary>
        /// Updates the.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(StudentManager entity);
    }
}