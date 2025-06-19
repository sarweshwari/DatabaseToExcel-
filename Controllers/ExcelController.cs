using DatabaseToExcel.Data;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Reflection.Metadata.Ecma335;

namespace DatabaseToExcel.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly AppDbContext db;
      

        public ExcelController(AppDbContext db)
        {
            this.db = db;

        }

        [HttpGet("ExcelData")]

        public IActionResult ExportplayersToExcel()
        {
            ExcelPackage.LicenseContext=LicenseContext.NonCommercial;
            var playerlist=db.Players.ToList();
            
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Players");
                worksheet.Cells[1, 1].Value = "Id";
                worksheet.Cells[1, 2].Value = "Name";
                worksheet.Cells[1, 3].Value = "Sport";
                worksheet.Cells[1, 4].Value = "Country";
                worksheet.Cells[1, 5].Value = "Experience";
                worksheet.Cells[1, 6].Value = "IsPlaying";

                int row = 2;
                foreach (var player in playerlist)
                {
                    worksheet.Cells[row, 1].Value = player.Id;
                    worksheet.Cells[row, 2].Value = player.Name;
                    worksheet.Cells[row, 3].Value = player.Sport;
                    worksheet.Cells[row, 4].Value = player.Country;
                    worksheet.Cells[row, 5].Value = player.Experience;
                    worksheet.Cells[row, 6].Value = player.IsPlaying;
                    row++;
                }
                var stream=new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var filename = "playerlist.xlsx";
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                return File (stream , contentType, filename);
            }
        }


    }
}
