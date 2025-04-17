using CustomMediatR.Mediator.Interfaces;
using CustomMediatR.UseCases.Games;
using Microsoft.AspNetCore.Mvc;

namespace CustomMediatR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesQueryController(
        IRequestHandler<GamesRequest, GamesResponse> handler
    ) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetGamesAsync([FromQuery] string? searchText, CancellationToken cancellationToken)
        {
            var request = new GamesRequest(searchText);
            var games = await handler.HandleAsync(request, cancellationToken);
            return Ok(games);
        }
    }


}
