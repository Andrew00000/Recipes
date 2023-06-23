namespace Recepies.Domain.Models
{
    public interface IRecepi
    {
        Guid Id { get; init; }
        string RecepiName { get; set; }
        (string GivenName, string FamilyName) Author { get; set; }
        string Slug { get; }
        int DurationInMinutes { get; set; }
        List<string> Ingredients { get; set; }
        List<string> Steps { get; set; }

    }
}