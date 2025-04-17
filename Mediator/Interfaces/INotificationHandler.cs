namespace CustomMediatR.Mediator.Interfaces
{
    public interface INotificationHandler<TNotification> where TNotification : INotification
    {
        Task NotifyAsync(TNotification notification, CancellationToken cancellationToken);
    }
}
