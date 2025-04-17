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
    }

}
