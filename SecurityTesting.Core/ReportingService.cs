
using OfficeOpenXml;
using SecurityTestingAPI.Models;
using System.Collections.Generic;
using System.IO;

namespace SecurityTesting.Core
{
    public class ReportingService
    {
        public void GenerateReport(List<Vulnerability> vulnerabilities, string filePath)
        {
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Vulnerabilities");

            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Description";
            worksheet.Cells[1, 3].Value = "Severity";
            worksheet.Cells[1, 4].Value = "Status";

            for (int i = 0; i < vulnerabilities.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value = vulnerabilities[i].Id;
                worksheet.Cells[i + 2, 2].Value = vulnerabilities[i].Description;
                worksheet.Cells[i + 2, 3].Value = vulnerabilities[i].Severity;
                worksheet.Cells[i + 2, 4].Value = vulnerabilities[i].Status;
            }

            FileInfo fileInfo = new FileInfo(filePath);
            package.SaveAs(fileInfo);
        }
    }
}