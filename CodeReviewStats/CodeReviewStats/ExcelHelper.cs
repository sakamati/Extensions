using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace CodeReviewStats
{
    public static class ExcelHelper
    {
        public static void GenerateExcelDocument(string fiileName, IEnumerable<CodeReviewResponse> codeReviewResponses)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fiileName, SpreadsheetDocumentType.Workbook))
            {
                // Add a WorkbookPart to the document.
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                // Add a WorksheetPart to the WorkbookPart.
                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Code Review" };
                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header
                Row row = new Row();

                row.Append(
                    ConstructCell("Id", CellValues.String),
                    ConstructCell("CreatedBy", CellValues.String),
                    ConstructCell("ReviewedBy", CellValues.String),
                    ConstructCell("Title", CellValues.String),
                    ConstructCell("CreatedDate", CellValues.String),
                    ConstructCell("ClosedDate", CellValues.String),
                    ConstructCell("ClosedStatus", CellValues.String),
                    ConstructCell("NumberOfComments", CellValues.String),
                    ConstructCell("CodeReviewRequest", CellValues.String));
                
                // Insert the header row to the Sheet Data
                sheetData.AppendChild(row);

                // Inserting each employee
                foreach (var codeReviewResponse in codeReviewResponses)
                {
                    row = new Row();

                    row.Append(
                        ConstructCell(codeReviewResponse.Id.ToString(), CellValues.Number),
                        ConstructCell(codeReviewResponse.CreatedBy, CellValues.String),
                        ConstructCell(codeReviewResponse.ReviewedBy, CellValues.String),
                        ConstructCell(codeReviewResponse.Title, CellValues.String),
                        ConstructCell(codeReviewResponse.CreatedDate, CellValues.String),
                        ConstructCell(codeReviewResponse.ClosedDate, CellValues.String),
                        ConstructCell(codeReviewResponse.ClosedStatus, CellValues.String),
                        ConstructCell(codeReviewResponse.CodeReviewCommentCount.ToString(), CellValues.Number),
                        ConstructCell(codeReviewResponse.CodeReviewRequestId.ToString(), CellValues.Number));
                    
                    sheetData.AppendChild(row);
                }

                worksheetPart.Worksheet.Save();                
            }
        }

        private static Cell ConstructCell(string value, CellValues dataType)
        {
            return new Cell()
            {
                CellValue = new CellValue(value),
                DataType = new EnumValue<CellValues>(dataType)
            };
        }
    }
}
