using System.Collections.Generic;
using System.Threading.Tasks;
using Laba9.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laba9.Services
{
    public interface IReminderService
    {
        Task<IEnumerable<Reminder>> GetReminders();
        Task<Reminder> GetReminderById(int id);
        Task<Reminder> CreateReminder(Reminder reminder);
        Task<Reminder> UpdateReminder(Reminder reminder);
        Task<bool> DeleteReminder(int id);
    }
}
