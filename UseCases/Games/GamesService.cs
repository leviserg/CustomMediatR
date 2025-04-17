using CustomMediatR.Mediator.Interfaces;
using CustomMediatR.Repositories;

namespace CustomMediatR.UseCases.Games
{
    public class GamesService(GamesRepository repository, ISender sender, ILogger<GamesService> logger)
    {
        public async Task AddGameAsync(string game, CancellationToken cancellationToken)
        {
            repository.AddGame(game);
            await sender.PublishAsync(new GameAddedNotification(game), cancellationToken);
        }

        public async Task RemoveGameAsync(string game, CancellationToken cancellationToken)
        {
            if (repository.RemoveGame(game))
            {
                await sender.PublishAsync(new GameRemovedNotification(game), cancellationToken);
            }
            else
            {
                logger.LogError("Game '{OldGame}' not found for delete.", game);
            }
        }

        public async Task UpdateGameAsync(string oldGame, string newGame, CancellationToken cancellationToken)
        {
            if (repository.UpdateGame(oldGame, newGame))
            {
                await sender.PublishAsync(new GameUpdatedNotification(oldGame, newGame), cancellationToken);
            }
            else
            {
                logger.LogError("Game '{OldGame}' not found for update.", oldGame);
            }
        }

        public IEnumerable<string> GetAllGames() => repository.GetAllGames();
    }
}
