using Microsoft.Extensions.DependencyInjection;
using Univers.Application.UseCases.Implementations;
using Univers.Application.UseCases;
using FluentValidation;
using Univers.Application.Dtos.Validateurs;

namespace Univers.Application.Extensions;
public static class ServiceCollections
{
    public static void EnregistrerUseCases(this IServiceCollection services) 
    {
        services.AddTransient<IAjouterPersonnage, AjouterPersonnage>();
        services.AddTransient<ISupprimerPersonnage, SupprimerPersonnage>();
        services.AddTransient<IVenteFranchise, VenteFranchise>();
        services.AddTransient<IObtenirPersonnage, ObtenirPersonnage>();
    }

    public static void EnregistrerValidations(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreerPersonnageDtoValidateur>();
    }
}