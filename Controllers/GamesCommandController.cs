using CustomMediatR.UseCases.Games;
using Microsoft.AspNetCore.Mvc;

namespace CustomMediatR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesCommandController(
        GamesService service
    ) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddGameAsync([FromBody] string game, CancellationToken cancellationToken)
        {
            await service.AddGameAsync(game, cancellationToken);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveGameAsync([FromBody] string game, CancellationToken cancellationToken)
        {
            await service.RemoveGameAsync(game, cancellationToken);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGameAsync([FromQuery] string oldGame, [FromBody] string newGame, CancellationToken cancellationToken)
        {
            await service.UpdateGameAsync(oldGame, newGame, cancellationToken);
            return Ok();
        }
    }
}
