using HealthCareDataMangement.Services;
using HealthCareDataMangement.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace HealthCareDataMangement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RemoveExpiredDataController : ControllerBase
    {
        private readonly RemoveExpiredDataService _removeExpiredDataService;
        private readonly ILogger<RemoveExpiredDataController> _logger;

        public RemoveExpiredDataController(RemoveExpiredDataService removeExpiredDataService, ILogger<RemoveExpiredDataController> logger)
        {
            _removeExpiredDataService = removeExpiredDataService;
            _logger = logger;
        }

        // POST: api/RemoveExpiredData
        [HttpPost("remove-expired-data")]
        public async Task<IActionResult> RemoveExpiredData([FromBody] int monthsToExp)
        {
            try
            {
                _logger.LogInformation("Removing expired data for products that expire within {monthsToExp} months.", monthsToExp);

                var expiredData = await _removeExpiredDataService.RemoveExpData(monthsToExp);

                if (expiredData == null || expiredData.Count == 0)
                {
                    return NotFound("No expired data found.");
                }

                return Ok(expiredData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while removing expired data.");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
