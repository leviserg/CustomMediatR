using System.Collections.Concurrent;

namespace CustomMediatR.Repositories
{
    public class GamesRepository
    {
        private readonly List<string> _games = new List<string>
        {
            "The Legend of Blazor",
            "Entity Framework Odissey",
            "Clean Architecture 3D",
            "Dependency Injection Adventure",
            "Mediator Quest",
            "Vertical Slice of Life",
            "CQRS Chronicles"
        };

        public IEnumerable<string> GetAllGames() => _games.OrderBy(g => g);

        public void AddGame(string game) => _games.Add(game);

        public bool RemoveGame(string game)
        {
            if(_games.Contains(game))
            {
                _games.Remove(game);
                return true;
            }

            return false;
        }

        public bool UpdateGame(string oldGame, string newGame)
        {

            if (_games.Contains(oldGame))
            {
                _games.Remove(oldGame);
                _games.Add(newGame);
                return true;
            }

            return false;
        }
    }
}
