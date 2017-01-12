using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcel
{
    public class ExcelUtility
    {
        public static void GenerateExcel(IEnumerable<IExcelRecord> records)
        {
            if (records.Any())
            {
                var firstRecord = records.First();
                Type recordType = firstRecord.GetType();
                var props = recordType.GetProperties();

                string fileName = "TestExcelFile.XLSX";

                using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
                {
                    // Add a WorkbookPart to the document.
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    // Add a WorksheetPart to the WorkbookPart.
                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    worksheetPart.Worksheet = new Worksheet();

                    Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                    Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Tab1" };
                    sheets.Append(sheet);

                    workbookPart.Workbook.Save();

                    SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                    // Constructing header
                    Row row = new Row();

                    foreach (var item in props)
                    {
                        var propattr = item.GetCustomAttributes(false);

                        object attr = (from attribute in propattr where attribute.GetType() == typeof(ExcelColumnAttribute) select attribute).FirstOrDefault();
                        if (attr == null)
                            continue;

                        ExcelColumnAttribute excelColumnAttribute = (ExcelColumnAttribute)attr;

                        row.Append(ConstructCell(excelColumnAttribute.DisplayName, CellValues.String));
                    }

                    // Insert the header row to the Sheet Data
                    sheetData.AppendChild(row);

                    // Inserting each record
                    foreach (var record in records)
                    {
                        var dataRow = new Row();

                        foreach (var property in props)
                        {
                            var propattr = property.GetCustomAttributes(false);

                            object attr = (from attribute in propattr where attribute.GetType() == typeof(ExcelColumnAttribute) select attribute).FirstOrDefault();
                            if (attr == null)
                                continue;

                            var value = property.GetValue(record);
                            //var value = property.GetValue(property, null);

                            dataRow.Append(ConstructCell(value.ToString(), CellValues.String));
                        }

                        sheetData.AppendChild(dataRow);
                    }

                    worksheetPart.Worksheet.Save();
                }

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
