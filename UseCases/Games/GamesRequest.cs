using CustomMediatR.Mediator.Interfaces;

namespace CustomMediatR.UseCases.Games
{
    public record GamesRequest(string? SearchText) : IRequest<GamesResponse>;
}
