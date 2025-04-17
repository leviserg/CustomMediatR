using CustomMediatR.Mediator.Interfaces;

namespace CustomMediatR.Mediator
{
    public class Sender(IServiceProvider serviceProvider) : ISender
    {
        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));

            dynamic handler = serviceProvider.GetRequiredService(handlerType);

            return await handler.HandleAsync((dynamic)request, cancellationToken);
        }

        public async Task PublishAsync<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            var handlerType = typeof(INotificationHandler<>).MakeGenericType(notification.GetType());
            var handlers = serviceProvider.GetServices(handlerType);

            foreach (dynamic? handler in handlers ?? Enumerable.Empty<object>())
            {
                if (handler is INotificationHandler<TNotification> notificationHandler)
                {
                    await notificationHandler.NotifyAsync(notification, cancellationToken);
                }
            }
        }
    }

}
