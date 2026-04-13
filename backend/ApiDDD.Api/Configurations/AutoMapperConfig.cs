using Microsoft.Extensions.DependencyInjection;
using ApiDDD.Application.Profiles;

namespace ApiDDD.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
            => services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfiles>());
    }
}