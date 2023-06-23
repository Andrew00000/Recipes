using Recepies.Application.Repositories;
using Recepies.Domain.Models;

namespace Recepies.Infrastructure.Repository
{
    public class RecepiRepository : IRecepiRepository
    {
        private readonly List<IRecepi> database = new();

        public Task<bool> CreateAsync(IRecepi recepi, CancellationToken token)
        {
            var originalCount = database.Count;
            database.Add(recepi);

            return Task.FromResult(originalCount < database.Count);
        }

        public Task<IRecepi?> GetByIdAsync(Guid id, CancellationToken token)
        {
            return Task.FromResult(database.Where(x => x.Id == id).FirstOrDefault());
        }

        public Task<IRecepi?> GetBySlugAsync(string slug, CancellationToken token)
        {
            return Task.FromResult(database.Where(x => x.Slug == slug).FirstOrDefault());
        }

        public Task<IEnumerable<IRecepi>> GetAllAsync(CancellationToken token)
        {
            return Task.FromResult((IEnumerable<IRecepi>)database);
        }

        public Task<IRecepi> UpdateAsync(IRecepi recepi, CancellationToken token)
        {
            var recepiToUpdate = database.Where(x => x.Id == recepi.Id).FirstOrDefault();

            if (recepiToUpdate is null)
            {
                database.Add(recepi);

                return Task.FromResult(recepi);
            }

            database.Remove(recepiToUpdate);
            database.Add(recepi);

            return Task.FromResult(recepi);
        }

        public Task<bool> DeleteByIdAsync(Guid id, CancellationToken token)
        {
            var originalCount = database.Count;
            var recepi = database.Where(x => x.Id == id).FirstOrDefault();

            if (recepi is null)
            {
                Task.FromResult(false);
            }

            database.Remove(recepi!);

            return Task.FromResult(originalCount > database.Count);
        }
    }
}
