using System;
using System.IO;
using ClosedXML.Excel;
using Laba9.Models;

namespace Laba9.Services
{
    public class VersionService : IVersionService
    {
        public int GetIntValue()
        {
            return 42;
        }

        public string GetStringValue()
        {
            return "Hello, World!";
        }

        public ExcelFile GetExcelFile()
        {
            using (var stream = new MemoryStream())
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Sheet1");
                    worksheet.Cell("A1").Value = "Hello";
                    worksheet.Cell("A2").Value = "World";
                    workbook.SaveAs(stream);
                }

                return new ExcelFile
                {
                    Content = stream.ToArray(),
                    ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    FileName = $"Sample_{DateTime.Now:yyyyMMddHHmmss}.xlsx"
                };
            }
        }
    }
}
