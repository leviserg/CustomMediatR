using CustomMediatR.Mediator.Interfaces;
using CustomMediatR.UseCases.Games;
using Microsoft.AspNetCore.Mvc;

namespace CustomMediatR.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    // public class GamesController(ISender sender) : ControllerBase
    public class GamesController(IRequestHandler<GamesRequest, GamesResponse> handler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetGamesAsync([FromQuery]string? searchText, CancellationToken cancellationToken)
        {
            var request = new GamesRequest(searchText);
            //var games = await sender.SendAsync<GamesResponse>(request, cancellationToken);
            var games = await handler.HandleAsync(request, cancellationToken);
            return Ok(games);
        }
    }
}
