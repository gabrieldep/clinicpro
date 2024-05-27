using Microsoft.Extensions.DependencyInjection;
using Person.Application;

namespace CrossCutting.DependencyInjection;

internal static class PersonModule
{
    public static void AddPersonModule(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(PersonInfo).Assembly);
        });
    }
}