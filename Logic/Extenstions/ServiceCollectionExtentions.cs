using Logic.Interfaces.Repositories;
using Logic.Interfaces.Services;
using Logic.Repositories;
using Logic.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Extenstions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddLogicServises(this IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IPhysicalMetricsRepository, PhysicalMetricsRepository>();
            services.AddSingleton<IPhysicalMetricsService, PhysicalMetricsService>();
        }
    }
}
