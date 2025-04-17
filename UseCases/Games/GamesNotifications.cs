using CustomMediatR.Mediator.Interfaces;

namespace CustomMediatR.UseCases.Games
{
    public record GameAddedNotification(string GameName) : INotification;
    public record GameRemovedNotification(string GameName) : INotification;
    public record GameUpdatedNotification(string OldGameName, string NewGameName) : INotification;

}
