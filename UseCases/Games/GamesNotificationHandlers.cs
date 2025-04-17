using CustomMediatR.Mediator.Interfaces;

namespace CustomMediatR.UseCases.Games
{
    public class GameAddedNotificationHandler(ILogger<GameAddedNotificationHandler> logger) : INotificationHandler<GameAddedNotification>
    {
        public Task NotifyAsync(GameAddedNotification notification, CancellationToken cancellationToken)
        {
            logger.LogWarning("Game Added: {Game}", notification.GameName);
            return Task.CompletedTask;
        }
    }

    public class GameRemovedNotificationHandler(ILogger<GameRemovedNotificationHandler> logger) : INotificationHandler<GameRemovedNotification>
    {
        public Task NotifyAsync(GameRemovedNotification notification, CancellationToken cancellationToken)
        {
            logger.LogWarning("Game Removed: {Game}", notification.GameName);
            return Task.CompletedTask;
        }
    }

    public class GameUpdatedNotificationHandler(ILogger<GameUpdatedNotificationHandler> logger) : INotificationHandler<GameUpdatedNotification>
    {
        public Task NotifyAsync(GameUpdatedNotification notification, CancellationToken cancellationToken)
        {
            logger.LogWarning("Game Updated: {OldGame} => {NewGame}:", notification.OldGameName, notification.NewGameName);
            return Task.CompletedTask;
        }
    }
}
