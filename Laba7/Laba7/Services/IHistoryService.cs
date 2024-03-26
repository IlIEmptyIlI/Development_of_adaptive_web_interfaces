using System.Collections.Generic;
using System.Threading.Tasks;
using Laba7.Models;

namespace Laba7.Services
{
    public interface IHistoryService
    {
        Task<IEnumerable<History>> GetHistory();
        Task<History> CreateHistory(History history);
        Task<History> UpdateHistory(History history);
        Task<bool> DeleteHistory(int id);
    }
}