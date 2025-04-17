using CustomMediatR.Mediator.Interfaces;

namespace CustomMediatR.UseCases.Games
{
    public class GamesRequestHandler(GamesService service) : IRequestHandler<GamesRequest, GamesResponse>
    {

        public async Task<GamesResponse> HandleAsync(GamesRequest request, CancellationToken cancellationToken)
        {
            var games = string.IsNullOrEmpty(request.SearchText)
                ? service.GetAllGames()
                : service.GetAllGames()
                    .Where(g => g.Contains(request.SearchText, StringComparison.OrdinalIgnoreCase));

            var response = new GamesResponse
            {
                Games = games.ToList()
            };

            return await Task.FromResult(response);
        }

    }

}
