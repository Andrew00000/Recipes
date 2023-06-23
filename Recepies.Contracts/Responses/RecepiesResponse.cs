namespace Recepies.Contracts.Responses
{
    public class RecepiesResponse
    {
        public required IEnumerable<RecepiResponse> Items { get; init; } = Enumerable.Empty<RecepiResponse>();
    }
}
