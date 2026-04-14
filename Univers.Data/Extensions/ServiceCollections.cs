using Microsoft.Extensions.DependencyInjection;
using Univers.Data.Repositories;
using Univers.Domain.Repositories;

namespace Univers.Data.Extensions;
public static class ServiceCollections
{
    public static void EnregistrerRepositories(this IServiceCollection services)
    {
        services.AddTransient<IDistributionRepository, DistributionRepository>();
        services.AddTransient<IFilmRepository, FilmRepository>();
        services.AddTransient<IFranchiseRepository, FranchiseRepository>();
        services.AddTransient<IPersonnageRepository, PersonnageRepository>();
    }
}