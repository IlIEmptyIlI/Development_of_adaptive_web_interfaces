using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Laba8.Models;

namespace Laba8.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly List<History> _history;

        public HistoryService()
        {
            _history = new List<History>();
        }

        public async Task<IEnumerable<History>> GetHistory()
        {
            return _history;
        }

        public async Task<History> CreateHistory(History history)
        {
            _history.Add(history);
            return history;
        }

        public async Task<History> UpdateHistory(History history)
        {
            var existingHistory = _history.Find(n => n.Id == history.Id);
            if (existingHistory != null)
            {
                existingHistory.Action = history.Action;
                existingHistory.Timestamp = history.Timestamp;
            }
            return existingHistory;
        }

            public async Task<bool> DeleteHistory(int id)
        {
            var historyToRemove = _history.Find(n => n.Id == id);
            if (historyToRemove != null)
            {
                _history.Remove(historyToRemove);
                return true;
            }
            return false;
        }

    }
}
