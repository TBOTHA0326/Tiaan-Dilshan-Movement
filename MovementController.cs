using MiniProjectDHL.Models;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using OfficeOpenXml;
using DocumentFormat.OpenXml.Spreadsheet;

namespace MiniProjectDHL.Controllers
{
    public class MovementController : Controller
    {
        // Action method to render the view
        public ActionResult Index()
        {
            return View();
        }

        // Action method to process the form submission
        [HttpPost]
        public ActionResult Execute(MovementModel model)
        {
            if (ModelState.IsValid)
            {
                byte[] excelData = GenerateExcelData(model);
                // Add backend logic here to process the request and generate the result

                // Simulate a delay to show the cooldown period
                System.Threading.Thread.Sleep(10000); // 10 seconds

                // Generate Excel data and return it for download


                return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MovementTest.xlsx");
            }


            // If model state is not valid, return to the form
            return View("Index", model);

        }

        // Implement Excel generation logic
        private byte[] GenerateExcelData(MovementModel model)
        {
            using (var package = new ExcelPackage())
            {
                var workbook = package.Workbook;

                var worksheet = workbook.Worksheets.Add("Movement Data");


                //Adding Headers
                worksheet.Cells["A1"].Value = "Movement Origin";
                worksheet.Cells["B1"].Value = "Movement Destination";
                worksheet.Cells["C1"].Value = "Movement Name";
                worksheet.Cells["D1"].Value = "Movement Date";


                //Filling in data from the model
                worksheet.Cells["A2"].Value = model.OriginStation;
                worksheet.Cells["B2"].Value = model.DestinationStation;
                worksheet.Cells["C2"].Value = model.MovementName;
                worksheet.Cells["D2"].Value = model.MovementDate.ToString("yyyy-MM-dd");

                //Save the excel package to byte array
                using (var stream = new MemoryStream())
                {
                    package.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}