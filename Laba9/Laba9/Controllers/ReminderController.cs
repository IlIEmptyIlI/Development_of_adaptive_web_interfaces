using Laba9.Models;
using Laba9.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laba9.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private readonly IReminderService _reminderService;

        public ReminderController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reminder>>> GetReminders()
        {
            var Reminders = await _reminderService.GetReminders();
            return Ok(Reminders);
        }

        [HttpPost]
        public async Task<ActionResult<Reminder>> CreateReminder([FromBody] Reminder Reminder)
        {
            var createdReminder = await _reminderService.CreateReminder(Reminder);
            return Ok(createdReminder);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Reminder>> UpdateReminder(int id, [FromBody] Reminder reminder)
        {
            if (id != reminder.Id)
            {
                return BadRequest();
            }

            var updatedReminder = await _reminderService.UpdateReminder(reminder);
            if (updatedReminder == null)
            {
                return NotFound();
            }

            return Ok(updatedReminder);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteReminder(int id)
        {
            var result = await _reminderService.DeleteReminder(id);
            if (!result)
            {
                return NotFound();
            }

            return Ok(true);
        }
    }
}
