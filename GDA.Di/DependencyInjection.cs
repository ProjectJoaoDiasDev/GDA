using AutoMapper;
using GDA.Data;
using GDA.Data.Contexts;
using GDA.Data.Identity;
using GDA.Data.Repositorys;
using GDA.Domain.Domain;
using GDA.Domain.Interfaces;
using GDA.Domain.Interfaces.Account;
using GDA.Domain.ViewModel;
using GDA.Solution.Services.ServicesStudent;
using GDA.Solution.Services.ServicesStudentManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GDA.Di
{
    /// <summary>
    /// The dependency injection.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Configures the.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="conection">The conection.</param>
        public static void Configure(IServiceCollection services, string conection)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(conection, ServerVersion.AutoDetect(conection));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequiredLength = 3;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                config.Lockout.MaxFailedAccessAttempts = 5;
                config.Lockout.AllowedForNewUsers = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(7);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddTransient(typeof(IAuthentication), typeof(Authentication));
            services.AddTransient(typeof(IManager), typeof(Manager));
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddScoped<StudentManagerServices>();
            services.AddScoped<StudentManagerRepository>();

            services.AddScoped<StudentServices>();
            services.AddScoped<StudentRepository>();

            AutoMapping(services);
        }

        /// <summary>
        /// Autos the mapping.
        /// </summary>
        /// <param name="services">The services.</param>
        private static void AutoMapping(IServiceCollection services)
        {
            var _mapConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentViewModel>().ReverseMap();
                cfg.CreateMap<StudentManager, StudentManagerViewModel>().ReverseMap();
                cfg.CreateMap<Address, AddressViewModel>().ReverseMap();
            });
            IMapper mapper = _mapConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
