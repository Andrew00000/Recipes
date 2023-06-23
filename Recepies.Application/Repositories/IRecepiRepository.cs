using Recepies.Domain.Models;

namespace Recepies.Application.Repositories
{
    public interface IRecepiRepository
    {
        public Task<bool> CreateAsync(IRecepi recipe, CancellationToken token = default);
        public Task<IRecepi?> GetByIdAsync(Guid id, CancellationToken token = default);
        public Task<IRecepi?> GetBySlugAsync(string slug, CancellationToken token = default);
        public Task<IEnumerable<IRecepi>> GetAllAsync(CancellationToken token = default);
        public Task<IRecepi> UpdateAsync(IRecepi recepi, CancellationToken token = default);
        public Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
    }
}
