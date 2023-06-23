using Recepies.Application.Repositories;
using Recepies.Application.Services;
using Recepies.Domain.Models;

namespace Recepies.Infrastructure.Service
{
    public class RecipeService : IRecepiService
    {
        private IRecepiRepository _recepiRepository;

        public RecipeService(IRecepiRepository recepiRepository)
        {
            _recepiRepository = recepiRepository;
        }

        public async Task<bool> CreateAsync(IRecepi recepi, CancellationToken token = default)
        {
            return await _recepiRepository.CreateAsync(recepi, token);
        }

        public async Task<IRecepi?> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            return await _recepiRepository.GetByIdAsync(id, token);
        }

        public async Task<IRecepi?> GetBySlugAsync(string slug, CancellationToken token = default)
        {
            return await _recepiRepository.GetBySlugAsync(slug, token);
        }

        public async Task<IEnumerable<IRecepi>> GetAllAsync(CancellationToken token = default)
        {
            return await _recepiRepository.GetAllAsync(token);
        }

        public async Task<IRecepi> UpdateAsync(IRecepi recepi, CancellationToken token = default)
        {
            return await _recepiRepository.UpdateAsync(recepi, token);
        }

        public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
        {
            return await _recepiRepository.DeleteByIdAsync(id, token);
        }
    }
}
