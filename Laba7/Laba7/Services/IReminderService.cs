using System.Collections.Generic;
using System.Threading.Tasks;
using Laba7.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laba7.Services
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
