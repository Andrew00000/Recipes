using Microsoft.AspNetCore.Mvc;
using Recepies.Contracts.Requests;
using Recepies.API.Mapping;
using Recepies.Application.Services;

namespace Recepies.API.Controllers
{
    [ApiController]
    public class RecepiesControllers : ControllerBase
    {
        private readonly IRecepiService _recepiService;

        public RecepiesControllers(IRecepiService recepiService)
        {
            _recepiService = recepiService;
        }

        [HttpPost(ApiEndpoints.Recepies.Create)]
        public async Task<IActionResult> Create([FromBody]CreateRecepiRequest request, CancellationToken token)
        {
            var recipe = request.MapToRecepi();

            await _recepiService.CreateAsync(recipe, token);
            return CreatedAtAction(nameof(Get), new { idOrSlug = recipe.Id }, recipe.MapToResponse());
        }

        [HttpGet(ApiEndpoints.Recepies.Get)]
        public async Task<IActionResult> Get([FromRoute] string idOrSlug, CancellationToken token)
        {
            var recepi = Guid.TryParse(idOrSlug, out var id)
                ? await _recepiService.GetByIdAsync(id, token)
                : await _recepiService.GetBySlugAsync(idOrSlug, token);

            if (recepi is null)
            {
                return NotFound();
            }

            return Ok(recepi.MapToResponse());
        }

        [HttpGet(ApiEndpoints.Recepies.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var recepies = await _recepiService.GetAllAsync(token);

            return Ok(recepies.MapToResponse());
        }

        [HttpPut(ApiEndpoints.Recepies.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRecepiRequest request, CancellationToken token)
        {
            var recepi = request.MapToRecepi(id);

            var updatedRecepi = await _recepiService.UpdateAsync(recepi, token);

            if (updatedRecepi is null)
            {
                return NotFound();
            }

            return Ok(updatedRecepi.MapToResponse());
        }

        [HttpDelete(ApiEndpoints.Recepies.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var deleted = await _recepiService.DeleteByIdAsync(id, token);

            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }

    }
}
