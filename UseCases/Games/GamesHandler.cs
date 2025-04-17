using CustomMediatR.Mediator.Interfaces;

namespace CustomMediatR.UseCases.Games
{
    public class GamesHandler : IRequestHandler<GamesRequest, GamesResponse>
    {

        private readonly List<string> GAMES = new List<string>
        {
            "The Legend of Blazor",
            "Entity Framework Odissey",
            "Clean Architecture 3D",
            "Dependency Injection Adventure",
            "Mediator Quest",
            "Vertical Slice of Life",
            "CQRS Chronicles"
        };

        public async Task<GamesResponse> HandleAsync(GamesRequest request, CancellationToken cancellationToken)
        {

            var result = string.IsNullOrEmpty(request.SearchText) ? GAMES : GAMES
                .Where(g => g.Contains(request.SearchText, StringComparison.OrdinalIgnoreCase))
                .ToList();

            var response = new GamesResponse
            {
                Games = result
            };

            return await Task.FromResult(response);
        }
    }

}
