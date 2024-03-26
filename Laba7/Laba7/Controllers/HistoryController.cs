using Laba7.Models;
using Laba7.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laba7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
           private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<History>>> GetHistory()
        {
            var History = await _historyService.GetHistory();
            return Ok(History);
        }

        [HttpPost]
        public async Task<ActionResult<History>> CreateHistory([FromBody] History History)
        {
            var createdHistory = await _historyService.CreateHistory(History);
            return Ok(createdHistory);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<History>> UpdateHistory(int id, [FromBody] History History)
        {
            if (id != History.Id)
            {
                return BadRequest();
            }

            var updatedHistory = await _historyService.UpdateHistory(History);
            if (updatedHistory == null)
            {
                return NotFound();
            }

            return Ok(updatedHistory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteHistory(int id)
        {
            var result = await _historyService.DeleteHistory(id);
            if (!result)
            {
                return NotFound();
            }

            return Ok(true);
        }
    }
}
