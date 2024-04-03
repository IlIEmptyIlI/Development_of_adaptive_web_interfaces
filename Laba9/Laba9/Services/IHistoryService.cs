using System.Collections.Generic;
using System.Threading.Tasks;
using Laba9.Models;

namespace Laba9.Services
{
    public interface IHistoryService
    {
        Task<IEnumerable<History>> GetHistory();
        Task<History> CreateHistory(History history);
        Task<History> UpdateHistory(History history);
        Task<bool> DeleteHistory(int id);
    }
}