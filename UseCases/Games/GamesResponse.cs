namespace CustomMediatR.UseCases.Games
{
    public record GamesResponse
    {
        public List<string> Games { get; init; } = new List<string>();
    }
}
