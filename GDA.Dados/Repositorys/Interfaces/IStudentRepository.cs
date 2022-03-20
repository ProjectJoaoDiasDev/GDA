using GDA.Dominio.Domain;

namespace GDA.Dados.Repositorys
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
        /// Gets the by studentCode.
        /// </summary>
        /// <param name="studentManagerId">The student manager id.</param>
        /// <param name="studentCode">The studentCode.</param>
        /// <returns>A Student.</returns>
        Student GetByStudentCode(int studentManagerId, long studentCode);
        List<Student>? GetAll();
    }
}