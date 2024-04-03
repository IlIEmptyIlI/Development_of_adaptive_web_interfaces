using Laba9.Models;

namespace Laba9.Services
{
    public interface IVersionService
    {
        int GetIntValue();
        string GetStringValue();
        ExcelFile GetExcelFile();
    }
}
