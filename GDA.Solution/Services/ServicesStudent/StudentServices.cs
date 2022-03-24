using AutoMapper;
using GDA.Dados.Repositorys;
using GDA.Dominio;
using GDA.Dominio.Domain;
using GDA.Dominio.Interfaces.Account;
using GDA.Dominio.ViewModel;
using GDA.Solution.Services.ServicesStudentManager;
using Microsoft.AspNetCore.Http;

namespace GDA.Solution.Services.ServicesStudent
{
    /// <summary>
    /// The student services.
    /// </summary>
    public class StudentServices
    {
        private readonly IManager _imanager;
        private StudentRepository _repositoryStudent;
        private StudentManagerServices _servicesStudentManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// Gets the user.
        /// </summary>
        private IUser _user => _imanager.GetUserName(userName: _httpContextAccessor.HttpContext.User.Identity.Name);
        /// <summary>
        /// Initializes a new instance of the <see cref="ClienteServices"/> class.
        /// </summary>
        /// <param name="imanager">The imanager.</param>
        /// <param name="studentRepository">The student repository.</param>
        /// <param name="studentManagerServices">The student manager services.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="httpContextAccessor">The http context accessor.</param>
        public StudentServices(IManager imanager, StudentRepository studentRepository, StudentManagerServices studentManagerServices, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _imanager = imanager;
            _repositoryStudent = studentRepository;
            _servicesStudentManager = studentManagerServices;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Creates the.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Create(StudentViewModel data)
        {
            ValidarDados(data);

            if (data.Id == 0)
            {
                var student = StudentViewtoStudent(data, _user.StudentManager);
                _repositoryStudent.Save(student);
            }
            else
            {
                var student = _repositoryStudent.GetById(data.Id);
                student.Name = data.Name;
                student.RG = data.RG;
                student.Email = data.Email;
                student.CPF = data.CPF;

                student.Address.PublicPlace = data.Address.PublicPlace;
                student.Address.Observation = data.Address.Observation;
                student.Address.UF = data.Address.UF;
                student.Address.Complement = data.Address.Complement;
                student.Address.District = data.Address.District;
                student.Address.CEP = data.Address.CEP;
                student.Address.City = data.Address.City;

                _repositoryStudent.Update(student);
            }
        }

        /// <summary>
        /// Gets the all by id student manager.
        /// </summary>
        /// <returns>A list of Students.</returns>
        public List<Student> GetAllByIdStudentManager()
        {
            return _repositoryStudent.GetAllByIdStudentManager(_user?.StudentManager?.Id ?? 0);
        }
        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns>A list of Students.</returns>
        public List<Student> GetAll()
        {
            return _repositoryStudent.GetAll();
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Student.</returns>
        public Student GetById(int id)
        {
            return _repositoryStudent.GetById(id);
        }

        /// <summary>
        /// Validars the dados.
        /// </summary>
        /// <param name="dadosCliente">The dados cliente.</param>
        private static void ValidarDados(StudentViewModel dadosCliente)
        {
            DomainException.When(string.IsNullOrEmpty(dadosCliente?.CPF), "CPF Inválido");
            DomainException.When(string.IsNullOrEmpty(dadosCliente?.Address?.City), "Cidade Inválida");
            DomainException.When(string.IsNullOrEmpty(dadosCliente?.Address?.District), "Bairro Inválido");
            DomainException.When(string.IsNullOrEmpty(dadosCliente?.Address?.CEP), "CEP Inválido");
            DomainException.When(string.IsNullOrEmpty(dadosCliente?.Address?.PublicPlace), "Endereço Inválido");
        }

        /// <summary>
        /// Students the viewto student.
        /// </summary>
        /// <param name="dadosCliente">The dados cliente.</param>
        /// <param name="studentManager">The student manager.</param>
        /// <returns>A Student.</returns>
        private static Student StudentViewtoStudent(StudentViewModel dadosCliente, StudentManager studentManager)
        {
            return new Student()
            {
                CPF = dadosCliente.CPF,
                Name = dadosCliente.Name,
                Address = new Address()
                {
                    District = dadosCliente.Address.District,
                    Complement = dadosCliente.Address.Complement,
                    CEP = dadosCliente.Address.CEP,
                    City = dadosCliente.Address.City,
                    PublicPlace = dadosCliente.Address.PublicPlace,
                    Observation = dadosCliente.Address.Observation,
                    UF = dadosCliente.Address.UF
                },
                RG = dadosCliente.RG,
                StudentManager = studentManager,
                Email = dadosCliente.Email
            };
        }

        /// <summary>
        /// Students the to view model.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns>A StudentViewModel? .</returns>
        public StudentViewModel? StudentToViewModel(Student student)
        {
            if (student == null) return null;

            var std = _mapper.Map<StudentViewModel>(student);
            std.Address = _mapper.Map<AddressViewModel>(std.Address);
            return std;
        }

    }
}
