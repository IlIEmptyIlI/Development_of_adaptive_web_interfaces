using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laba9.Models;

namespace Laba9.Services
{
    public class ReminderService : IReminderService
    {
        private readonly List<Reminder> _reminders;

        public ReminderService()
        {
            _reminders = new List<Reminder>
            {
                new Reminder { Id = 1, Title = "Reminder 1", Description = "Description 1", DueDate = DateTime.Today.AddDays(1) },
                new Reminder { Id = 2, Title = "Reminder 2", Description = "Description 2", DueDate = DateTime.Today.AddDays(2) }
            };
        }

        public async Task<IEnumerable<Reminder>> GetReminders()
        {
            return _reminders;
        }

        public async Task<Reminder> GetReminderById(int id)
        {
            return _reminders.FirstOrDefault(r => r.Id == id);
        }

        public async Task<Reminder> CreateReminder(Reminder reminder)
        {
            _reminders.Add(reminder);
            return reminder;
        }

        public async Task<Reminder> UpdateReminder(Reminder reminder)
        {
            var existingReminder = _reminders.FirstOrDefault(r => r.Id == reminder.Id);
            if (existingReminder != null)
            {
                existingReminder.Title = reminder.Title;
                existingReminder.Description = reminder.Description;
                existingReminder.DueDate = reminder.DueDate;
            }
            return existingReminder;
        }

        public async Task<bool> DeleteReminder(int id)
        {
            var reminderToDelete = _reminders.FirstOrDefault(r => r.Id == id);
            if (reminderToDelete != null)
            {
                _reminders.Remove(reminderToDelete);
                return true;
            }
            return false;
        }
    }
}
