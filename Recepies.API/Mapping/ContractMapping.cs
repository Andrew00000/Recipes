using Recepies.Contracts.Requests;
using Recepies.Contracts.Responses;
using Recepies.Domain.Models;

namespace Recepies.API.Mapping
{
    public static class ContractMapping
    {
        public static IRecepi MapToRecepi(this CreateRecepiRequest request)
        {
            return new Recepi
            {
                Id = Guid.NewGuid(),
                RecepiName = request.RecepiName,
                Author = request.Author,
                DurationInMinutes = request.DurationInMinutes,
                Ingredients = request.Ingredients.ToList(),
                Steps = request.Steps.ToList()
            };
        }

        public static IRecepi MapToRecepi(this UpdateRecepiRequest request, Guid id)
        {
            return new Recepi
            {
                Id = id,
                RecepiName = request.RecepiName,
                Author = request.Author,
                DurationInMinutes = request.DurationInMinutes,
                Ingredients = request.Ingredients.ToList(),
                Steps = request.Steps.ToList()
            };
        }

        public static RecepiResponse MapToResponse(this IRecepi recepi)
        {
            return new RecepiResponse
            {
                Id = recepi.Id,
                RecepiName = recepi.RecepiName,
                Author = recepi.Author,
                Slug = recepi.Slug,
                DurationInMinutes = recepi.DurationInMinutes,
                Ingredients = recepi.Ingredients,
                Steps = recepi.Steps
            };
        }

        public static RecepiesResponse MapToResponse(this IEnumerable<IRecepi> recipes)
        {
            return new RecepiesResponse
            {
                Items = recipes.Select(MapToResponse)
            };
        }
    }
}
