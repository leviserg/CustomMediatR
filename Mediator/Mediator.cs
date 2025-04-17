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

            RegisterRequestHandlers(services, assembly);

            RegisterNotificationHandlers(services, assembly);

            return services;
        }

        private static void RegisterRequestHandlers(IServiceCollection services, Assembly assembly)
        {
            var requestHandlerInterfaceType = typeof(IRequestHandler<,>);
            var requestHandlerTypes = assembly.GetTypes()
                .Where(type => !type.IsInterface && !type.IsAbstract)
                .SelectMany(
                    type => type.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == requestHandlerInterfaceType)
                    .Select(i => new { Interface = i, Implementation = type })
                );

            foreach (var handlerType in requestHandlerTypes)
            {
                services.AddScoped(handlerType.Interface, handlerType.Implementation);
            }
        }

        private static void RegisterNotificationHandlers(IServiceCollection services, Assembly assembly)
        {
            var notificationHandlerInterfaceType = typeof(INotificationHandler<>);
            var notificationHandlerTypes = assembly.GetTypes()
                .Where(type => !type.IsInterface && !type.IsAbstract)
                .SelectMany(
                    type => type.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == notificationHandlerInterfaceType)
                    .Select(i => new { Interface = i, Implementation = type })
                );

            foreach (var handlerType in notificationHandlerTypes)
            {
                services.AddScoped(handlerType.Interface, handlerType.Implementation);
            }
        }
    }
}
