using System.Text.RegularExpressions;

namespace Recepies.Domain.Models
{
    public partial class Recepi : IRecepi
    {
        public required Guid Id { get; init; }
        public required string RecepiName { get; set; }
        public required (string GivenName, string FamilyName) Author { get; set; }
        public string Slug => GenerateSlug();
        public required int DurationInMinutes { get; set; }
        public required List<string> Ingredients { get; set; } = new();
        public required List<string> Steps { get; set; } = new();

        private string GenerateSlug()
        {
            var sluggedRecepiName = SlugRegex().Replace(RecepiName, string.Empty).ToLower().Replace(" ", "-");
            var sluggedAuthor = SlugRegex().Replace($"{Author.GivenName} {Author.FamilyName}", string.Empty).ToLower().Replace(" ", "-");

            return $"{sluggedRecepiName}-{sluggedAuthor}";
        }

        [GeneratedRegex("[^A-Za-z _ -]", RegexOptions.NonBacktracking, 5)]
        private static partial Regex SlugRegex();
    }
}
