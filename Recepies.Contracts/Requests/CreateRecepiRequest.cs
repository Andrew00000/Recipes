namespace Recepies.Contracts.Requests
{
    public class CreateRecepiRequest
    {
        public required string RecepiName { get; init; }
        public required (string GivenName, string FamilyName) Author { get; init; }
        public required int DurationInMinutes { get; init; }
        public required IEnumerable<string> Ingredients { get; init; } = Enumerable.Empty<string>();
        public required IEnumerable<string> Steps { get; init; } = Enumerable.Empty<string>();
    }
}
