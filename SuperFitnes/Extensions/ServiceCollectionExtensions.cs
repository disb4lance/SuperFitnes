using SuperFitnes.Features.Interfaces;
using Logic.Extenstions;
using Microsoft.AspNetCore.Identity;
using SuperFitnes.Features.Managers;
namespace SuperFitnes.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWebServices(this IServiceCollection services)
        {
            services.AddLogicServises();

            services.AddTransient<IUserManager, UserManager>();
        }
    }
}
