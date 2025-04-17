using CustomMediatR.Mediator.Interfaces;
using System.Reflection;

namespace CustomMediatR.Mediator
{
    public static class Mediator
    {
        public static IServiceCollection AddMediator(this IServiceCollection services, Assembly? assembly = null)
        {
            assembly ??= Assembly.GetCallingAssembly();

            services.AddScoped<ISender, Sender>();

            var handlerInerfaceType = typeof(IRequestHandler<,>);

            var handlerTypes = assembly.GetTypes()
                .Where(type => !type.IsInterface && !type.IsAbstract)
                .SelectMany(
                    type => type.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInerfaceType)
                    .Select(i => new { Interface = i, Implementation = type })
                 );

            foreach (var handlerType in handlerTypes)
            {
                services.AddScoped(handlerType.Interface, handlerType.Implementation);
            }

            return services;
        }
    }
}
