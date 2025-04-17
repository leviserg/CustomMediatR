namespace CustomMediatR.Mediator.Interfaces
{
    public interface ISender
    {
        Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    }
}
