using CustomMediatR.Mediator.Interfaces;
using CustomMediatR.UseCases.Games;
using Microsoft.AspNetCore.Mvc;

namespace CustomMediatR.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GamesController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetGamesAsync([FromQuery]string searchText, CancellationToken cancellationToken)
        {
            var request = new GamesRequest(searchText);
            var games = await sender.SendAsync<GamesResponse>(request, cancellationToken);
            return Ok(games);
        }
    }
}
