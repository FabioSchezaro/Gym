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

            service.AddSingleton<IFullDataPeopleService, FullDataPeopleService>();
            service.AddSingleton<IPeopleRepository, PeopleRepository>();
        }
    }
}
