using AutoMapper;
using GDA.Data.Repositorys;
using GDA.Domain;
using GDA.Domain.Domain;
using GDA.Domain.Interfaces.Account;
using GDA.Domain.ViewModel;
using Microsoft.AspNetCore.Http;

namespace GDA.Solution.Services.ServicesStudentManager
{
    /// <summary>
    /// The student manager services.
    /// </summary>
    public class StudentManagerServices
    {
        private readonly StudentManagerRepository _repositoryStudentManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IManager _imanager;
        private readonly IMapper _mapper;
        /// <summary>
        /// Gets the user.
        /// </summary>
        private IUser _user => _imanager.GetUserName(userName: _httpContextAccessor?.HttpContext?.User?.Identity?.Name);

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentManagerServices"/> class.
        /// </summary>
        /// <param name="studentManagerRepository">The student manager repository.</param>
        /// <param name="httpContextAccessor">The http context accessor.</param>
        /// <param name="imanager">The imanager.</param>
        /// <param name="mapper">The mapper.</param>
        public StudentManagerServices(StudentManagerRepository studentManagerRepository, IHttpContextAccessor httpContextAccessor, IManager imanager, IMapper mapper)
        {
            _repositoryStudentManager = studentManagerRepository;
            _httpContextAccessor = httpContextAccessor;
            _imanager = imanager;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates the.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Create(StudentManagerViewModel data)
        {
            ValidarDados(data);

            if (data.Id == 0)
            {
                var stdManager = StudentManagerViewModelToStudentManager(data);
                _repositoryStudentManager.Save(stdManager);
            }
            else
            {
                var stdManager = _repositoryStudentManager.GetById(data.Id);
                stdManager.Name = data.Name;
                stdManager.Email = data.Email;


                _repositoryStudentManager.Update(stdManager);
            }

        }

        public StudentManager GetById(int id)
        {
            return _repositoryStudentManager.GetById(id);
        }

        public StudentManager GetSessionUser()
        {
            return _user.StudentManager;
        }

        public List<StudentManager> GetAll()
        {
            return _repositoryStudentManager.GetAll();
        }

        /// <summary>
        /// Validars the dados.
        /// </summary>
        /// <param name="data">The data.</param>
        private static void ValidarDados(StudentManagerViewModel data)
        {
            DomainException.When(string.IsNullOrEmpty(data.Name), "Nome Invalido");
            DomainException.When(string.IsNullOrEmpty(data.Email), "Email Invalido");
        }

        /// <summary>
        /// Students the manager view model to student manager.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>A StudentManager.</returns>
        private StudentManager StudentManagerViewModelToStudentManager(StudentManagerViewModel data)
        {
            return new StudentManager()
            {
                Id = data.Id,
                Email = data.Email,
                Name = data.Name
            };
        }

        /// <summary>
        /// Empresas the to view model.
        /// </summary>
        /// <param name="studentManager">The studentManager.</param>
        /// <returns>A StudentManagerViewModel? .</returns>
        public StudentManagerViewModel? StudentManagerToStudentManagerViewModel(StudentManager studentManager)
        {
            if (studentManager == null) return null;
            var stdManager = _mapper.Map<StudentManagerViewModel>(studentManager);
            stdManager.Email = studentManager.Email;
            stdManager.Name = studentManager.Name;
            return stdManager;
        }
    }
}