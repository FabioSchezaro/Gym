using Gym.Domain.Interfaces.IRepositories;
using Gym.Domain.Interfaces.IServices;
using Gym.Domain.Interfaces.IUnitOfWork;
using Gym.Infra.Data.Sql;
using Gym.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gym.IoC
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection service, IConfiguration configuration)
        {
            service.AddSingleton<IUnitOfWork>(s =>
                new UnitOfWork(configuration.GetConnectionString("GymConnectionString")));

            service.AddSingleton<IUserRepository, UserRepository>();
            service.AddSingleton<IUserService, UserService>();

            service.AddSingleton<IPeopleService, PeopleService>();
            service.AddSingleton<IPeopleRepository, PeopleRepository>();

            service.AddSingleton<ITelephoneService, TelephoneService>();
            service.AddSingleton<ITelephoneRepository, TelephoneRepository>();

            service.AddSingleton<IAddressService, AddressService>();
            service.AddSingleton<IAddressRepository, AddressRepository>();

            service.AddSingleton<IDiseaseService, DiseaseService>();
            service.AddSingleton<IDiseaseRepository, DiseaseRepository>();

            service.AddSingleton<IPlanService, PlanService>();
            service.AddSingleton<IPlanRepository, PlanRepository>();

            service.AddSingleton<IDueDayService, DueDayService>();
            service.AddSingleton<IDueDayRepository, DueDayRepository>();

            service.AddSingleton<IPhisicalAvaliationService, PhisicalAvaliationService>();
            service.AddSingleton<IPhisicalAvaliationRepository, PhisicalAvaliationRepository>();

            service.AddSingleton<IMetricsService, MetricsService>();
            service.AddSingleton<IMetricsRepository, MetricsRepository>();

            service.AddSingleton<IFullDataPeopleService, FullDataPeopleService>();
            service.AddSingleton<IClientRepository, ClientRepository>();
            service.AddSingleton<IPeopleDiseaseRepository, PeopleDiseaseRepository>();

            service.AddSingleton<IRoleService, RoleService>();
            service.AddSingleton<IRoleRepository, RoleRepository>();
        }
    }
}
