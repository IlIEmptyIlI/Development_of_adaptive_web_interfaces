using System.Collections.Generic;
using System.Threading.Tasks;
using Laba8.Models;

namespace Laba8.Services
{
    public interface IHistoryService
    {
        Task<IEnumerable<History>> GetHistory();
        Task<History> CreateHistory(History history);
        Task<History> UpdateHistory(History history);
        Task<bool> DeleteHistory(int id);
    }
}